---
title: Blazor autofocus
date: 2020-04-04T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---

In my last blog post I created a component for an input textbox (with some added features).
I got a question on how you could add Focus on that textbox.

In HTML there is an attribute called ```autofocus``` which doesn't work since the components are loading after the DOM is complete.
The solution is to use JavaScript interop to set focus.
But to me that is broken, we have an attribute designed to solve the problem, in this case the technology (Blazor) broke that attribute (the same is true for Angular, React).
I want to repair the ```autofocus``` attribute.

Since we are inheriting from ```Microsoft.AspNetCore.Components.Forms.InputText``` we get access to a property called ```AdditionalAttributes``` which contains any additional attributes we put into our tag.  
If we add the ```autofocus```-attribute it will show up in that collection.

### Calling JavaScript

To be able to call JavaScript we need to inject a reference to ```IJSRuntime```
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=JavaScriptInterop)]

We need to call our JavaScript-method at the right time, that time is after we have rendered the component.

``` cs
protected override Task OnAfterRenderAsync(bool firstRender)
```

Then we check if the attribute exists and is set to ```True```

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Autofocus)]

### The JavaScript

To finish everything off you need to add the JavaScript.
I created a file in wwwroot/js/JavaScriptInterop.js containing

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=SetFocus)]

and last but not least you need to add a reference to the JavaScript file in pages/_host.cshtml.
(Right after the reference to blazor.server.js)


[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Pages/_Host.cshtml?name=AddJavaScriptInterop)]

Now you just need to add the ```autofocus``` attribute to set focus on that element.

``` html
<AzmInputText Type="Password" autofocus @bind-Value="@Model.OldPassword" />
```

You can find the source code for this post at https://github.com/EngstromJimmy/BlazorPlayground.