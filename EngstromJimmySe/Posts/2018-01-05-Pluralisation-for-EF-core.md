---
layout: post
title: Pluralization for Entity Framework Core
date: 2018-01-04 08:00:00
categories: [Entity Framework Core]
author: Jimmy Engström
tags: [Entity Framework Core]
hide: false
---


I recently started working with .NET Core and I didn't like that Microsoft removed the automatic pluralization/singularization of classes and collection in Entity Framework Core.
They did however give us the opportunity to hook in our own.

This is talked about in this [StackOverflow post](https://stackoverflow.com/questions/39281647/entityframework-core-database-first-approach-pluralizing-table-names/47410837#47410837)


What you need to do is to add a couple of files to your Entity Framework Core project.

I created a folder named "Pluralize" and added a PluralizationService.
I choose to modify the one Microsoft provided in previous versions of Entity Framework found [here](https://github.com/Microsoft/referencesource/blob/master/System.Data.Entity.Design/System/Data/Entity/Design/PluralizationService/EnglishPluralizationService.cs).  
You can of course just create your own.
These are the files I use:
<script src="https://gist.github.com/EngstromJimmy/813145615303a5e2f7544007279ba081.js"></script>

<script src="https://gist.github.com/EngstromJimmy/3427182e3fabc0983e12e8b98c46fb12.js"></script>

<script src="https://gist.github.com/EngstromJimmy/6a626fec9efa250be2bdedc5b790cf73.js"></script>

<script src="https://gist.github.com/EngstromJimmy/67dc5ec18da7ace4ac9812d643e755b7.js"></script>
This will automatically register MyPluralizer and it will be used the next time you update your Entity Framework model.

Hope this helps you and if you have any feedback, please contact me.





