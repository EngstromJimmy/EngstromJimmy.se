---
layout: post
title: Blazor - Changing the title without JavaScript
date: 2020-03-11T00:00:00.000+00:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
hide: false

---

Blazor is a fantastic way to develop interactive sites without the use of JavaScript.  
But that is not always entirely true, in some cases, you do need JavaScript.  
One example is changing the Title of a web page, since the title-tag is part of the head-tag, and the head tag is part of the ````_host.cshtml```` file it is hard to change from within a component/page.  

Luckily there are ways of doing that without the need for JavaScript.

I decided to add the title into an AppState-class, simply because I will probably need to access that from every page anyways.

1. Create a class called ```AppStateService``` containing:
```csharp
        public class AppStateService: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            private string title;
    
            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }
```

2. **In Startup**  
    Add the service to dependency injection.
```csharp
        services.AddScoped<AppStateService>();
```

3. **Add HeadSection.Razor**  
Add a Razor-component called HeadSection.razor and add the following code:

```csharp
        @using System.ComponentModel
        @inject AppStateService appstate
        
        <!--Whatever tags you want-->
        <title>@appstate.Title</title>
        
        @code {
            protected override async Task OnInitializedAsync()
            {
                appstate.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
                {
                    InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                };
                await base.OnInitializedAsync();
            }
        }
```

4. **In Pages/_host.cshtml**

    Replace your head tag with
```html
        <head>
            <base href="~/" />
            <component type="typeof(HeadSection)" render-mode="ServerPrerendered"/>
        </head>
```

5. Now in your component inject the AppStateService
```csharp
        @inject AppStateService appstate
```

    and set the title

```csharp
        @code {
            protected override async Task OnInitializedAsync()
            {
                appstate.Title = "Your title here";
            }
        }
```
Even though calling a JavaScript to update the title might be less code, the solution above will also allow you to add some SEO data (since the HeadSection-component is ServerPrerendered).

