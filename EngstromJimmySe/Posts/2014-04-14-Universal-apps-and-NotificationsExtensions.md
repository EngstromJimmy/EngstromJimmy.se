---
layout: post
title: Universal apps and NotificationsExtensions (Part 1)
date: 2014-04-14 00:31:00
categories: [Windows-8,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>&nbsp;</p>
<p>This is a series of blog posts on how to do notifications in Universal apps.<br /><br /><br />Managing notifications can be a bit &ldquo;tricky&rdquo;, you need to edit xml (or write the xml as a string yourself).<br />Luckily Microsoft has provided an Universal app project in their sample code that helps with creating notifications, it uses nice interfaces and classes to create the notifications.<br />I took their help classes from the sample, compiled and uploaded it as a Nuget package to make it simple to do notifications.</p>
<p>Right click on the solution then choose &ldquo;Manage Nuget packages for solution&rdquo;</p>
<p>Search for <strong>NotificationsExtensions.UniversalApps</strong>, press install.</p>
<p><a href="/PostImages/image_23.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_23.png" alt="image" width="831" height="361" border="0" /></a></p>
<p>You need to make sure you add the package to both the Windows phone and the Windows Store project (you don&rsquo;t need to add it to the shared project).</p>
<p>To be able to do notifications you also need to enable Toasts, open edit Package.appxmanifest in the Windows phone and Windows 8 project and set Toast capable to &ldquo;yes&rdquo;.</p>
<p><a href="/PostImages/image_24.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_24.png" alt="image" width="465" height="83" border="0" /></a></p>
<p>Now you are good to go!</p>
<p>Microsoft has made the tiles and toast templates available on both platforms (Awesome!), they may look a bit different, see links in each blog post: <br /><a href="http://www.apeoholic.se/post/2014/04/14/Universal-Apps-and-Live-Tiles">Live Tiles</a></p>
<p><a href="http://www.apeoholic.se/post/2014/04/14/Universal-apps-and-Toasts">Toasts</a></p>
<p>&nbsp;</p>
<h3>Recources</h3>
<p>Microsofts code sample:</p>
<p><a href="http://code.msdn.microsoft.com/Alarm-toast-notifications-fe81fc74#content">http://code.msdn.microsoft.com/Alarm-toast-notifications-fe81fc74#content</a></p>
<p>Nuget version</p>
<p><a title="https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/" href="https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/">https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/</a></p>
