---
title: Using Blazor JavaScript Isolation with Library Manager
date: 2020-10-15T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---

One of the new features in .NET 5 for Blazor is isolated JavaScript.  
It means that you can have JavaScript that is only for a specific component.  
It is also a fantastic way for component developers to include JavaScript into their libraries so the developers using their library will not have to add the JavaScript themselves.  

There is one downside, the current implementation in .NET 5 requires the files to be placed int the wwwroot-folder.  
The implementation is not going to be as nice as the CSS Isolation implementation, where you can keep razor file and CSS in the same folder.  
I talked to Mads Kristensen about the possibility to use WebCompiler to solve this issue, but he suggested Library Manager might be a better solution (spoiler: He was right).  

So let's take one step back and first talk about isolated JavaScript.
Isolated JavaScript makes it possible to load JavaScript that will be scoped to that particular component.  
Which is nice of course, but where I really see a usage for this is when building (and packaging) components.
We can add JavaScript into our components without the end user (developer) having to add a reference to the JavaScript.  
The components are more self-contained, the same thing goes for Isolated CSS (but that is another story).

## Adding the JavaScript

Add a file in the same folder as the razor-file called thenameoftherazorfile.js so if you are adding the JS to index.razor the JavaScript-file would be called *index.razor.js*.

[!code-js[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground5/Pages/IsolatedJS.razor.js)]

The JavaScript needs to be written with the module syntax using export. 

## Calling the JavaScript

In the razor file, we must add  IJSRuntime
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground5/Pages/IsolatedJS.razor?Name=IJSRuntime)]

Then we need to add a reference to the JavaScript.
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground5/Pages/IsolatedJS.razor?Name=Code)]
We first have a message variable that shows the message coming back from the JavaScript.
Then we add a ```JSObjectReference``` and instantiate the object by passing "import" and the path to the JavaScript-file.

Then we need to add something that calls the JavaScript in this case a button.
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground5/Pages/IsolatedJS.razor?Name=Button)]

This won't work at this point because the JS file needs to be located in the wwwroot folder, but we want to have the script close to the component.

## Copy the JavaScript

1. Right-click on the project and select **Manage Client-Side libraries**
This will create a *libman.json* file.
2. Open *libman.json* and replace its content with:

[!code-json[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground5/libman.json)]

This will copy all JS files in the *pages* folder to *wwwroot*.  

3. Right-click on the *libman.json* and select **Enable Restore Client-Side Libraries on Build**
This way the copy will occur when you Build the project, and the files will be up to date.

The only down-side I have found so far is that if you make a change in the JavaScript-File and not in any file that needs compiling so the project is up-to-date, the JavaScript-file won't get copied (since there was no compiling made).

You can find the source code for this project [here](https://github.com/EngstromJimmy/BlazorPlayground/tree/master/BlazorPlayground/BlazorPlayground5)









