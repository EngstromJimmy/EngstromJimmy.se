---
title: Implementing authentication with Auth0 in a Blazor Server project
date: 2022-06-30T00:00:00.000+01:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor
# image: /PostImages/2020-03-21-UsingHighchartsWithBlazor/highcharts.PNG

---
 

## Setting up Auth0

1. Goto [Auth0](https://auth0.com/) and signup  
Auth0 is free to use for up to 7000 users and if we have more than 7000 users hopefully our site is generating some money that can pay for a plan.
2. Click the **Create application** button
3. Now it's time to name our application.  
 Then it's time to select what kind of application type we are using.
 This depends on what version of Blazor we are going to run. Since we are using Blazor server in this post we are going to use the regular web application.
Select **Regular Web application** and click **select**.
4. Next, we're going to choose what technology are we using for our project. We got Apache, .Net, Django, Go, and a lot of other choices, but we don't have a choice for Blazor specifically, at least not at the time of writing. We're just going to skip this by selecting **skip integration**.
5. Now we will set up our application, there are a couple of values we need to save and use later so make sure to write down the *domain*, and *Client Id*, we will use those in a bit.
6. If we scroll down, there are possibilities to change the logo of the logo but we will skip that for now.
We need to set up the Application login URI which is our application URL (localhost for now) and the port number.
Starting with .NET 6 the port number change so make sure you add the port number your application is using.  
Allowed Callback URLs:https://localhost:PORTNUMBER/callback  
Allowed Logout URLs:https://localhost:PORTNUMBER/  
Allowed Callback URLs are the URL Auth0 will make a call to after the user authentication and Allowed Logout URLs are where the user should be redirected after logout.  
Now press **Save changes**.

## Setting up Blazor Server

We are done with configuring Auth0, now it's time to configure our Blazor application.
There are many ways to store secrets in .NET (file that is not checked in, Azure Key vault, etc. use the one that you are most familiar with.

1. We will keep it very simple and store it in our *appsetting.json*, make sure you don't check the secrets into source control.  
Add the following code to ApplicationSettings.json:

 ``` javascript
  "Auth0": {
    "Authority": "Get this from the domain for the application at Auth0",
    "ClientId": "Get this from Auth0 setting",
  },
```

Blazor server is an ASP.NET site with some added Blazor functionality which means we can use a Nuget package to get some of the functionality out of the box.

2. Add a reference to the Nuget Package **Auth0.AspNetCore.Authentication**
3. Open *Program.cs* and add the following code:

```csharp
builder.Services
    .AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Authority"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

```

4. Also add the following that will give us the ability to secure our site.

``` csharp
app.UseAuthentication();
app.UseAuthorization();
```

5. Add the following usings

``` csharp
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
```

6. Blazor Server communication is done over SignalR and OpenID and OpenAuth rely on HTTP. This is the only thing I don't like about Blazor that I sometimes need to build pages outside of Blazor. But that's ok =)
Minimal APIs are a great way to do that by simply adding two get methods.
In Program.cs add the following code:

```csharp
app.MapGet("login", async (string redirectUri, HttpContext context) =>
{
    var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
         .WithRedirectUri(redirectUri)
         .Build();

    await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

```

When our site redirects to "login" kick off the login functionality.
7. We need to add a similar functionality for logout, add the following code:

``` csharp
app.MapGet("logout", async (HttpContext context) =>
{
    var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
         .WithRedirectUri("/")
         .Build();

    await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

```

The configuration is all set now we need something to secure.

## Securing Blazor Server

Blazor uses app.razor for routing, to enable securing Blazor we need to add a couple of components in the app component.
We need to add a CascadingAuthenticationState which will send the authentication state to all the components that are listening for it.
We also need to change the route view to be an AuthorizeRouteView which can have different views depending on whether or not you are authenticated.

1. In the end the app.razor component should look like this:

``` html
<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(App).Assembly">
        <Found Context="routeData">
            <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)">
                  <Authorizing>
                    <p>Determining session state, please wait...</p>
                </Authorizing>
                <NotAuthorized>
                    <h1>Sorry</h1>
                    <p>You're not authorized to reach this page. You need to log in.</p>
                </NotAuthorized>
            </AuthorizeRouteView>
            <FocusOnNavigate RouteData="@routeData" Selector="h1" />
        </Found>
        <NotFound>
            <PageTitle>Not found</PageTitle>
            <LayoutView Layout="@typeof(MainLayout)">
                <p role="alert">Sorry, there's nothing at this address.</p>
            </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>


```

Now only two things remain, a page that we can secure and display a login link.

2. Add the following code where you want to show a login link.

``` html
<AuthorizeView>
    <Authorized>
        <a href="logout">Log out</a>
    </Authorized>
    <NotAuthorized>
        <a href="login?redirectUri=/">Log in</a>
    </NotAuthorized>
</AuthorizeView>
```

3. Add the authorize attribute to the component you wish to secure.

``` csharp
@attribute [Authorize]
```

This is all it takes, some configuration and then we are all set.
The power of Auth0 is that we can register our users directly on their site and also use other providers (social connections) like Twitter, Facebook, twitch, and many many more.

You can take a look at the full sample here:
https://github.com/CodingAfterWork/NextTechEvent








