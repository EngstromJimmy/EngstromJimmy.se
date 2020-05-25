---
title: Blazor Open link in new window
date: 2020-05-25T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---

Opening a link in a new window can be fairly easy by adding ```target="_blank"``` but in our case we needed to run a couple of lines of code to get the link (which is only valid a short amount of time).
In Blazor you can use ```NavigationManager``` to navigate to a new page, but you can't open a new window or tab.

There are two problems we need to overcome.

1. Open link in new window/tab
2. Avoid pop-up blocker

To be able to open in a new window/tab you'll need to involve JavaScript.
So the first problem is pretty easy to solve.

The second problem is a bit harder (and to be honest I don't know if I have solved it).  
To battle pop-up blockers I open a new window containing som text like "Redirecting to..." and then the JavaScript makes sure to redirect to the right link.  
Since we are opening a "pop-up" at the same site and then redirect to a new one the pop-up blockers should be ok with it (It has worked fine during my tests).

To solve this I decided to add a little piece of JavaScript that simply opens a new window/tab, shows a redirect message and redirects to the supplied URL.

[!code-js[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/wwwroot/js/JavaScriptInterop.js?Name=OpenInNewWindow)]

To call the JavaScript function I have created an extension method that extends the NavigationManager and adds a ```NavigateToNewWindowAsync``` method.
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Extensions/NavigationManagerExtensions.cs)]
The only thing I dislike with this implementation is that I also need to supply an ```IJSInterop``` object to the method.
I didn't find a good way to work around that.
I also choose to add it directly to the same namespace as ```NavigationManager``` so I don't have to add another using statement to make it accessible.

And last but not least to call this method I need to inject ```NavigationManager``` and ```IJSRuntime```.
[!code-js[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Pages/OpenInNewWindow.razor)]

Hope this helps, I found a lot of different solutions while researching this, and this is a mix of them.
