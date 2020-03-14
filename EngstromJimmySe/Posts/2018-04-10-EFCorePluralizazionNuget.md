---
layout: post
title: Pluralization for Entity Framework Core Nuget
date: 2018-04-10T08:00:00.000+00:00
categories:
- Entity Framework Core
author: Jimmy Engström
tags:
- Entity Framework Core
hide: false

---
In one of the projects I work on we use database first, but with EF core the class names was terrible, no pluralization, no singularization.<br/>
[See previous post](www.apeoholic.se/entity%20framework%20core/2018/01/04/Pluralisation-for-EF-core.html)

I wanted to simplify this more so I created a nuget package so now the only thing you have to do is:

1. Add the [nuget package](https://www.nuget.org/packages/EntityFrameworkCore.Pluralize)<br/>
2. Add a class (Name suggestion:PluralizeDesignTimeServices.cs)<br/>
   <script src="https://gist.github.com/Apeoholic/bda9c9b1815321ff99d173ca0b99cebf.js"></script>
3. Run dotnet ef scaffold...... and everything will be named correctly =)

If some translations are missing, please do a PR or contact me and I will add them.