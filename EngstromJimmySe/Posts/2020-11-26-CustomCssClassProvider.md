---
title: Custom validation class attributes
date: 2020-11-26T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---
 
By simply using EditForm, Input-components, and DataAnnotationValidator, Blazor will automatically add classes to the components when it is valid and when it is not.
By default, these classes ```.valid``` and ```.invalid```.
In .NET 5 we get a way to customize these class names ourselves.
Using Bootstrap the default class names are: .is-valid and .is-invalid and must also have the class .form-control to get the right styles.
The component we will build next will help ut get the right bootstrap styling on all our form components.
We can create our own FieldCssClassProvider to customize what classes that Blazor will use.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/Blazm.Components/master/Blazm.Components/Blazm.Components/Forms/BootstrapFieldCssClassProvider.cs)]

The BootstrapFieldCssClassProvider needs an EditContext to work.
The code will check if the form (or EditContext to be specific) is valid and whether or not it has been modified.
Based on that it returns the correct CSS classes.
It returns form-control for all elements, that way we don’t have to add that to every element in the form.
We could validate an untouched form to valid or invalid but we don’t want it to show that the form is ok just because it hasn’t changed yet.
We need to get the EditContext from our EditForm and then set the FieldCssClassProvider on the EditContext like this:
``` cs
CurrentEditContext.SetFieldCssClassProvider(provider);
```
But we are going to do that in a bit more elegant way (IMHO).
The EditForm is exposing its EditContext as a CascadingValue.
That means we can build a component that we can just put inside of our EditForm and that way access the EditContext.

[!code-cs[](https://raw.githubusercontent.com/EngstromJimmy/Blazm.Components/master/Blazm.Components/Blazm.Components/Forms/CustomCssClassProvider.cs)]

This is a generic component that takes a type, in this case, the type of the Provider.
We specified that the type must inherit from FieldCssClassProvider and must av a constructor without parameters.
The component is inheriting from ComponentBase which makes it possible to place the component inside of a Blazor Component.
We have a Cascading parameter that will be populated from the EditForm.
We throw an exception if the EditContext for some reason is missing (for example if you place the component outside of an EditForm.
And then we set the FieldCssClassProvider on the EditContext.
To use the component you just have to add the code below inside of your EditForm (Not all the code is shown below).
``` html
<EditForm>
    <CustomCssClassProvider ProviderType="BootstrapFieldCssClassProvider"/>
</EditForm>
```
We simply provide our CustomCssClassProvider component with the ProviderType BootstrapFieldCssClassProvider.

This is now part of Blazm and you can browse the source code [here](https://github.com/EngstromJimmy/Blazm.Components/tree/master/Blazm.Components/Blazm.Components/Forms)





