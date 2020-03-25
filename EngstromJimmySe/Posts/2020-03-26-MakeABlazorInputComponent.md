---
title: Make a Blazor input component
date: 2020-03-26T00:00:00.000+00:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG
hide:true
---

Creating a reusable Blazor component can speed up development and makes it easier to avoid repeating your code.

In the Blazor framework, we have a bunch of really useful components for handling form data.
One of them is ```<InputText>``` it will render a ```<input>``` tag in the end.
But ```<InputText>``` will also add som classes depending on your form validation.

This is not going to be a deep-dive into form validation so at this point it's great if you are at least a little bit familiar with form validation.

Our component should be reusable and avoid having to repeat code.

I love ```DataAnnotations``` they make sure that the class itself takes control over the data.

Let's use a little more "advanced" sample to show you how powerful it can be.
Let's build a UI for changing a password.
It would have 3 different fields, old password, new password, and new password again (confirm password).

The class would look something like this.





[!code-csharp[](https://raw.githubusercontent.com/EngstromJimmy/HighchartsUsingBlazor/master/HighchartsUsingBlazor/Pages/Index.razor)]

You can find the source code for this post at https://github.com/EngstromJimmy/HighchartsUsingBlazor.