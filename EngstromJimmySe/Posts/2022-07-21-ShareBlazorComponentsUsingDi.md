---
title: Share Blazor components using dependency injection
date: 2022-07-20T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---
Using Blazor, it's possible to share different components and layouts.
But in some cases, like with log out, for example, we need different implementations depending on the hosting model. If those components are in the main layout, for example, it's kind of hard to share that layout (mainLayout for example) between Blazor Server and Blazer WebAssembly.
Most of us probably choose one hosting model and just runs with it, but I wanted to make a site where everything was possible to share, including the Mainlayout.
What better way to do that than using dependency injection?
I ended up using the DynamicComponent component and simply adding the injected component type into the type parameter.

## Add an Interface
First, we need a simple interface we can use for dependency injection
```csharp
public interface ILoginStatus
{
}
```
We don't need the interface to implement anything so we can leave it empty.

## Shared MainLayout
The mainlayout looks like this:
``` html
@using Components.RazorComponents
@inherits LayoutComponentBase
@inject ILoginStatus status
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <DynamicComponent Type="@status.GetType()"/>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

```


## Blazor server implementation
For the Blazor Server implementation, we add a file called LoginStatusServer.razor we implement the ILoginStatus interface.

``` html
@implements ILoginStatus
<AuthorizeView>
    <Authorized>
        <a href="logout">Log out</a>
    </Authorized>
    <NotAuthorized>
        <a href="login?redirectUri=/">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```
Blazor server project we simply specify the dependency injection like this:
```csharp
builder.Services.AddTransient<ILoginStatus,LoginStatusServer>();
```

## Blazor WebAssembly implementation
In the Blazor WebAssembly (client) project we add a new component called LoginStatusWasm.razor which is the WebAssembly implementation of the control.
The component specific for WebAssembly looks like this:
```html
@using Components.RazorComponents
@implements ILoginStatus
<AuthorizeView>
    <Authorized>
        Wasm<a href="logout">Log out</a>
    </Authorized>
    <NotAuthorized>
        WASM<a href="login?redirectUri=/">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```
Blazor WebAssembly project we simply specify the dependency injection like this:
```csharp
builder.Services.AddTransient<ILoginStatus, LoginStatusWasm>();
```

This is a simple way to be able to share the MainLayout file between Blazor Server and Blazor WebAssembly but still have the power to change the implementation just a little bit.

date: 2022-07-20T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---
Using Blazor, it's possible to share different components and layouts.
But in some cases, like with log out, for example, we need different implementations depending on the hosting model. If those components are in the main layout, for example, it's kind of hard to share that layout (mainLayout for example) between Blazor Server and Blazer WebAssembly.
Most of us probably choose one hosting model and just runs with it, but I wanted to make a site where everything was possible to share, including the Mainlayout.
What better way to do that than using dependency injection?
I ended up using the DynamicComponent component and simply adding the injected component type into the type parameter.

## Add an Interface
First, we need a simple interface we can use for dependency injection
```csharp
public interface ILoginStatus
{
}
```
We don't need the interface to implement anything so we can leave it empty.

## Shared MainLayout
The mainlayout looks like this:
``` html
@using Components.RazorComponents
@inherits LayoutComponentBase
@inject ILoginStatus status
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <DynamicComponent Type="@status.GetType()"/>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

```


## Blazor server implementation
For the Blazor Server implementation, we add a file called LoginStatusServer.razor we implement the ILoginStatus interface.

``` html
@implements ILoginStatus
<AuthorizeView>
    <Authorized>
        <a href="logout">Log out</a>
    </Authorized>
    <NotAuthorized>
        <a href="login?redirectUri=/">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```
Blazor server project we simply specify the dependency injection like this:
```csharp
builder.Services.AddTransient<ILoginStatus,LoginStatusServer>();
```

## Blazor WebAssembly implementation
In the Blazor WebAssembly (client) project we add a new component called LoginStatusWasm.razor which is the WebAssembly implementation of the control.
The component specific for WebAssembly looks like this:
```html
@using Components.RazorComponents
@implements ILoginStatus
<AuthorizeView>
    <Authorized>
        Wasm<a href="logout">Log out</a>
    </Authorized>
    <NotAuthorized>
        WASM<a href="login?redirectUri=/">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```
Blazor WebAssembly project we simply specify the dependency injection like this:
```csharp
builder.Services.AddTransient<ILoginStatus, LoginStatusWasm>();
```

This is a simple way to be able to share the MainLayout file between Blazor Server and Blazor WebAssembly but still have the power to change the implementation just a little bit.
