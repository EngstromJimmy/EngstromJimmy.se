---
title: Blazor - Reload the browser on disconnect
date: 2020-03-14T00:00:00.000+00:00
categories:
- Blazor
author: Jimmy Engström
tags:
- Blazor

---

In most cases, Blazor will reconnect to your server on the same circuit as before.
But there are moments when reconnection is not possible and you'll need to reload your web browser to get the site to work again.
If the server recycles the app pool you will need to manually reload the page(hopefully very rare).

While developing and running your site without debugging and on IIS Express, using automatic reload speeds the development process.
Just save your file and switch to the web browser which will automatically refresh when everything is compiled and ready.

There is a way to reload your browser automatically.
A while back Dan Roth posted a solution on Github, I need to google for it every time I set up a new site so I thought I would share it on my blog instead.

Paste the following script into your _host.cshtml.
This uses the JS DOM mutation observer API to detect when the "reload" button is visible and automatically reloads your page.

[!code-JavaScript[ReloadBlazor](posts/snippets/2020-04-14 Reload Blazor/ReloadBlazor.md "How to reload Blazor")]

Read more here https://github.com/dotnet/aspnetcore/issues/10325
