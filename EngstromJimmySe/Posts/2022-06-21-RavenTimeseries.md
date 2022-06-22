---
title: Implementing RavenDB time series in a Blazor project
date: 2022-06-21T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---
 
[On our stream](https://www.youtube.com/watch?v=Z2EZXY6G5ZU&list=PLVtyebq5FL-mEn_uvi9ER6NBnb8o3h3fF), we're working on a project called NextTechEvent. 
It's a site where speakers, attendees, and organizers will be able to find a conference to send CFPs to, attend, or find a date that works for organizing an event.
As a speaker, sometimes you get to travel all over the world and it's not always clear if it's summer, winter, or what kind of weather you could expect in the country we are traveling to.

It all started when we got accepted to speak at TechBash in November.
What kind of weather is it in Pennsylvania in November?
The sane thing to do would be to go to a weather site and figure it out.
The developer's way of doing it is to look for a weather API to implement on the site.
After researching 30 APIs or so I stumbled on the Azure Maps API.
I had no idea this was integrated into Azure.
We were using Bing APIs to geolocate the venues and add extra information that way but having the API in Azure was a perfect solution.

## Creating a class to store the data

We use Raven to store our conferences and the ability to add time series for the weather information. 
We want to store a value for each day of the conference, so a time series felt like the perfect choice for this.
The first thing we need to to is defining a class with the data we want to store in the time series, it can store double values (up to 32).

```csharp
public class WeatherData
{
    [TimeSeriesValue(0)]
    public double Minimum { get; set; }
    [TimeSeriesValue(1)]
    public double Maximum { get; set; }
    [TimeSeriesValue(2)]
    public double Average { get; set; }
}
```

## Register the time series

In program.cs, we set up our connection to Raven, and there we also register the time series.

```csharp
 builder.Services.AddSingleton<IDocumentStore>(ctx =>
 {
     var store = new DocumentStore
     {
         Urls = new string[] { "..." },
         Database = "NextTechEvent",
         Certificate = new X509Certificate2(Convert.FromBase64String(config["RavenCert"]), config["RavenPassword"])
     };

     store.Initialize();
     store.TimeSeries.Register<Conference, WeatherData>();
  	 // Add index here later
     return store;
 });
```

## Storing the data
Getting the weather data is outside of the scope of this blog post so let's assume that we got some weather data back from Azure Maps.

To add the the current weather data to the time series, we need to create a new instance of the class we defined above.
The we can add the data to the time series.
```csharp
var tsf = session.TimeSeriesFor<WeatherData>(item);
foreach (var temp in weatherroot.results)
{
    tsf.Append(temp.date.Date, new WeatherData
    {
        Minimum = Convert.ToDouble(temp.temperature.minimum.value),
        Maximum = Convert.ToDouble(temp.temperature.maximum.value),
        Average = Convert.ToDouble(temp.temperature.average.value)
    });
}
```

## Getting the time series
Ok, this might be an important part as well, how do we get the weather information?
It wasn't too complicated to do that
```csharp
 using IAsyncDocumentSession session = _store.OpenAsyncSession();
 TimeSeriesEntry<WeatherData>[] val = await session.TimeSeriesFor<WeatherData>(conferenceId).GetAsync();
```

## Searching the time series

The last part is to be able to search the data, so let's say I want to submit a call for paper for a conference where the temperature is over 25 degrees Celcius.
To be able to do that we need to create an index.
To create an index add a ```AbstractMultiMapTimeSeriesIndexCreationTask```.

```csharp
 public class ConferencesByWeather : AbstractMultiMapTimeSeriesIndexCreationTask
{
    public ConferencesByWeather()
    {

        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        AddMap<Conference>(
            "WeatherDatas",
            timeSeries => from ts in timeSeries
                            let conference = LoadDocument<Conference>(ts.DocumentId)
                            from entry in ts.Entries
                            select new ConferenceWeather()
                            {
                                Minimum = entry.Values[0],
                                Maximum = entry.Values[1],
                                Average = entry.Values[2],
                                Timestamp = entry.Timestamp,
                                ConferenceId = ts.DocumentId,
                                Name = conference.Name,
                                CfpStartDate = conference.CfpStartDate,
                                CfpEndDate = conference.CfpEndDate,
                                EventStart = conference.EventStart,
                                EventEnd = conference.EventEnd
                            });
    }
}
```
And make sure to create that index by adding it to where we set up our database in program.cs.
```csharp
    store.ExecuteIndexAsync(new ConferencesByWeather());
```

Now we can query that index by running the following code:
``` csharp
public async Task<List<ConferenceWeather>> GetConferencesByWeatherAsync(double averageTemp)
{
    using IAsyncDocumentSession session = _store.OpenAsyncSession();

    return await session.Query<ConferenceWeather>("ConferencesByWeather").Where(c => c.Average > averageTemp).ToListAsync();
}
```

You can take a look at the full sample here:
https://github.com/CodingAfterWork/NextTechEvent






