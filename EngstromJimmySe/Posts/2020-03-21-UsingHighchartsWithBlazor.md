---
title: Using Highcharts with Blazor
date: 2020-03-21T00:00:00.000+00:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG
---


There are loads of Blazor 3rd party vendors, but it is still very early and some features are missing.
Before we started porting our sites to Blazor we used Highcharts and we decided that we want to continue using Highcharts for a little bit longer (until the vendors add what we need).

I have seen other projects trying to port Highcharts to .NET classes (or at least for the configuration) but the downside is that you can't use the documentation to figure out how to create a chart.
I wanted my solution to be simple to use (if you already used Highcharts or want to use their documentation), no need to convert from JSON to .NET.
I didn't want to involve NPM (one of the things I love most about Blazor is that I don't need NPM).

## Javascript

Since Highcharts is a JavaScript-library we need to do JavaScript calls, I have created a script that will download Highcharts from their site (you don't have to include it yourself or download the scripts), it can of course easily be modified to use a local file instead of CDN.

The JavaScript quickly became a bit complicated (I wanted it to download everything the page needed so you only include one JavaScript-file).
It will check if the file is already loaded, and it will make sure that ```HighChart``` is defined (need to be done in case you have more than one chart on the same page).

[!code-javascript[](https://raw.githubusercontent.com/EngstromJimmy/HighchartsUsingBlazor/master/HighchartsUsingBlazor/Scripts/JSInterop.js)]

and add the JavaScript to your ```pages/_host.cshtml```
[!code-html[](https://raw.githubusercontent.com/EngstromJimmy/HighchartsUsingBlazor/master/HighchartsUsingBlazor/Pages/_Host.cshtml?name=AddJavaScript)]

## Component
The component creates a div with a unique name and calls the javascript with the supplied JSON
[!code-csharp[](https://raw.githubusercontent.com/EngstromJimmy/HighchartsUsingBlazor/master/HighchartsUsingBlazor/Components/Highchart.razor)]


## Usage
To use the component you'll need to supply the component with a configuration for the chart, and here is the beautiful part, you supply the component with the same JSON you can find from the documentation at http://www.highchart.com.  
No need to change anything.

[!code-csharp[](https://raw.githubusercontent.com/EngstromJimmy/HighchartsUsingBlazor/master/HighchartsUsingBlazor/Pages/Index.razor)]

You can find the source code for this post at https://github.com/EngstromJimmy/HighchartsUsingBlazor.