---
layout: post
title: Universal apps and NotificationsExtensions - Toasts (Part 3)
date: 2014-04-14 00:50:00
categories: [Windows-8,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>Here is how to handle toasts the easy way&nbsp;in Universal apps.<br /><br />First add the &ldquo;NotificationsExtensions.UniversalApps&rdquo; Nuget package.</p>
<p>See <a href="http://www.apeoholic.se/post/2014/04/14/Universal-apps-and-NotificationsExtensions">blog post</a> showing how.</p>
<p>Toast templates:<br /><a title="http://msdn.microsoft.com/en-us/library/windows/apps/hh761494.aspx" href="http://msdn.microsoft.com/en-us/library/windows/apps/hh761494.aspx">http://msdn.microsoft.com/en-us/library/windows/apps/hh761494.aspx</a></p>
<p>It is possible to send any toast template to Windows Phone 8.1 but it will always be shown as an modified version of ToastText02.</p>
<p>You can add a Toast notification like this:</p>
<pre class="brush: csharp;">IToastText02 toastContent = ToastContentFactory.CreateToastText02();
toastContent.TextHeading.Text = "Tosty!";
toastContent.TextBodyWrap.Text = "Toasts, best invention since.. ehmm toast";

ScheduledToastNotification toast;
toast = new ScheduledToastNotification(toastContent.GetXml(), DateTime.Now.AddSeconds(10));
toast.Id = "SomeID";
ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
</pre>
