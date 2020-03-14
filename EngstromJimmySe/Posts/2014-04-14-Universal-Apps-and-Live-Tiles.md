---
layout: post
title: Universal apps and NotificationsExtensions - Live Tiles (Part2)
date: 2014-04-14 00:45:00
categories: [Windows-8,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>Here is how to handle live tiles the easy way&nbsp;in Universal apps.</p>
<p>First add the &ldquo;NotificationsExtensions.UniversalApps&rdquo; Nuget package.</p>
<p>See <a href="http://www.apeoholic.se/post/2014/04/14/Universal-apps-and-NotificationsExtensions">blog post</a> showing how.</p>
<p><br />Tile templates comparison:<br /><a title="http://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx" href="http://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh761491.aspx</a></p>
<p><br />This is how to update your tile with a scheduled update.</p>
<pre class="brush: csharp;">//Create wide tile update
ITileWide310x150Text09 tileContent = TileContentFactory.CreateTileWide310x150Text09();
tileContent.TextHeading.Text = "Wide Tile Text";
tileContent.TextBodyWrap.Text = "More text on the tile";

//Always add a 150x150 tile update also  
ITileSquare150x150Text04 squareContent = TileContentFactory.CreateTileSquare150x150Text04();
squareContent.TextBodyWrap.Text = "More text on the tile";
tileContent.Square150x150Content = squareContent;


ScheduledTileNotification futureTile = new ScheduledTileNotification(tileContent.GetXml(), DateTime.Now.AddSeconds(15));
TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(futureTile);</pre>
<p>&nbsp;</p>
<p>To update your tile right away you can use these lines instead of the last two above:</p>
<pre class="brush: csharp;">TileNotification tileNotification=new TileNotification(tileContent.GetXml());
TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
</pre>
<h3>&nbsp;</h3>
<h3>Recources</h3>
<p>Microsofts code sample:</p>
<p><a href="http://code.msdn.microsoft.com/Alarm-toast-notifications-fe81fc74#content">http://code.msdn.microsoft.com/Alarm-toast-notifications-fe81fc74#content</a></p>
<p>Nuget version</p>
<p><a title="https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/" href="https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/">https://www.nuget.org/packages/NotificationsExtensions.UniversalApps/</a></p>
