---
title: Make a Blazor input component
date: 2020-03-28T00:00:00.000+00:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---

Creating a reusable Blazor component can speed up development and makes it easier to avoid repeating your code.

In the Blazor framework, we have a bunch of really useful components for handling form data.
One of them is ```<InputText>``` it will render a ```<input>``` tag in the end.  
But ```<InputText>``` will also add som classes depending on your form validation.

This is not going to be a deep-dive into form validation.

Our component should be reusable and avoid having to repeat code.

I love ```DataAnnotations``` they make sure that the class itself takes control over the data.

I have used a little more "advanced" sample to show you how powerful it can be.  
Let's build a UI for changing a password.
It would have 3 different fields, old password, new password, and new password again (confirm password).

## The data model

The class would look something like this.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/ChangePasswordViewModel.cs?name=PasswordClass)]

Notice that I am using the data annotations ```RegularExpression```, ```Required```, and ```Compare``` (to name a few), they will generate errors if the data is not within the parameters.

## The Component

The component should inherit from 

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Inherits)]

That way it will automatically add ```.valid``` and ```.invalid``` classes depending on the validation.

### Parameters
The component will show a label, error message, success message, description, and placeholder.
I like when things are simple and specifying these values on the data model (with data annotations) is so much simpler and makes the terminology the same everywhere you are using the class.
However it is always a good idea to make it possible to override the values.
So the component need a couple of parameters.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Parameters)]

### Reflection

Now onto the real magic, getting all the values from the data annotations using reflection.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Reflection)]

It is of course possible to create you own attributes and add them as well.

### Label and textbox
To show the label and the textbox I just added this code.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=LabelAndInput)]

It is partly taken from the Blazor implementation for ```InputText```.
If the textbox gains focus I make sure validation errors start showing (actually they will start to show when the textbox looses focus again.)

### Description

To show the description I have used a small-tag and also CSS classes found in Bootstrap.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Description)]

### Error and success

To show any validation error I have used a div-tag and also CSS classes found in Bootstrap.  
I also make sure that I have made some kind of edit or focused the textbox before I show the error message.  
But what we really want is happy users and users are happy if we also tell them when they do something good.
It will give them a Seratonin boost, and it can be as simple as adding a success-message.  
[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Components/AzmInputText.razor?name=Description)]

## The CSS

To get the full Bootstrap experience we need to remove a couple of CSS rules from the default CSS.
I removed these styles.

[!code-csharp[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/wwwroot/css/site.css?name=RemoveCSS)]

and add the following styles

[!code-csharp[](https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/wwwroot/css/AzmTextInput.css)]

I have copied the CSS from Bootstrap for this example, there is a much better way of solving that without copying using SASS but that is an upcoming blog post =)

## Usage

Alright everything it all done now it is time to use the component.
In /pages/AzmInputTextDemo.razor

[!code-csharp[]https://raw.githubusercontent.com/EngstromJimmy/BlazorPlayground/master/BlazorPlayground/BlazorPlayground/Pages/AzmInputTextDemo.razor)]

Nice, clean and reusable.

You can find the source code for this post at https://github.com/EngstromJimmy/BlazorPlayground.