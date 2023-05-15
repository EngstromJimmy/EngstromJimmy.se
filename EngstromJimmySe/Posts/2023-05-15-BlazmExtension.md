---
title: Supercharging Blazor Development with BlazmExtension: A New Visual Studio Extension
date: 2023-05-15T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---

First of all, yes the title is totally generated by ChatGPT =)

I've been running Blazor in production 7 days after it was released.  
I use it for work all day and then for my hobby projects in the evening.  
I clock in a lot of Blazor development hours and I'm always looking for ways to improve my workflow.
There are a few things that I've been missing in Visual Studio and I've been thinking about creating a Visual Studio extension for a while now.
So I looked at some of my pain points and how I could solve them with an extension.

## Creating a new Isolated CSS file
I wanted to be able to create a new Isolated CSS file directly from the Solution Explorer and I didn't want to have to type the name of the file.  
So I created a new Visual Studio extension called BlazmExtension that adds a new context menu item to the Solution Explorer.  
Just right-click on the component and select "Create Isolated CSS ".  
This will create a new CSS file with the appropriate name for that component.  

## Creating a new Isolated JavaScript file
I also wanted to be able to create a new Isolated JavaScript file directly from the Solution Explorer.  
Just right-click on the component and select "Create Isolated JavaScript".  
This will create a new JavaScript file with the same name as the component.  

## Move namespaces to _Imports
A common task when creating a new component is to add the namespace to the _Imports.razor file.
Simply select the namespaces you want to move and right-click and select "Move namespaces to _Imports".

## Extract to Component
Blazor is a very component-based framework and you often find yourself extracting parts of your code to a new component.
This is a very common task and I wanted to make it as easy as possible.
Simply select the code you want to extract and right-click and select "Extract to Component".
This will create a new component with the selected code and replace the selected code with the new component.

## Move code-behind to razor
This is my favorite feature of the extension.
Visual Studio makes it easy to move code from the razor file to the code-behind file.
But it doesn't have a feature to move code from the code-behind file to the razor file.
I prefer to have all my code in the razor file and I often find myself moving code from the code-behind file to the razor file.
Right-click on the component.razor.cs file and select "Move code-behind to razor".
This feature is in beta, I hope I have managed to cover all the edge cases but if you find any bugs please let me know.

## Conclusion
I hope you find this extension useful.
I will continue to add new features to the extension and I'm open to suggestions.
You can find the extension on the Visual Studio Marketplace:
[https://marketplace.visualstudio.com/items?itemName=EngstromJimmy.BlazmExtension](https://marketplace.visualstudio.com/items?itemName=EngstromJimmy.BlazmExtension)