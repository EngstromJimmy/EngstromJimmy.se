---
layout: post
title: Download all the videos from Build 2014
date: 2014-04-06 04:51:00
categories: [.NET-Micro-Framework,Gadgets,Windows-8,Windows-Phone]
author: Jimmy Engström
tags: [Build]
hide: false
---
<p>Build 2014 was packed with announcements and fun stuff.<br />Still have a lot of videos to watch =)<br /><br />Here is an updated version of my script I previously blogged about <a href="http://apeoholic.se/post/2013/07/08/watching-all-videos-from-build-2013">here.</a></p>
<p>cd "d:\build14"</p>
<p>$pattern = "[{0},\:,\']" -f ([Regex]::Escape([String][System.IO.Path]::GetInvalidPathChars()))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />$pattern <br />[Environment]::CurrentDirectory=(Get-Location -PSProvider FileSystem).ProviderPath <br />$a = ([xml](new-object net.webclient).downloadstring("<a href="http://s.ch9.ms/Events/Build/2014/RSS/mp4high&quot;))"><span style="color: #2e92cf; font-family: Segoe UI;"><span style="color: #000000; font-family: Verdana;">http://s.ch9.ms/Events/Build/2014/RSS/mp4high</span>"))</span></a> <br />$a.rss.channel.item | foreach{&nbsp; <br />&nbsp;&nbsp;&nbsp; $url = New-Object System.Uri($_.enclosure.url) <br />&nbsp;&nbsp;&nbsp; $file = [Regex]::Replace($_.Title + " " + $url.Segments[-1] , $pattern, ' ') <br />&nbsp;&nbsp;&nbsp; $file <br />&nbsp;&nbsp;&nbsp; if (!(test-path $file)) <br />&nbsp;&nbsp;&nbsp; { <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (New-Object System.Net.WebClient).DownloadFile($url, $file) <br />&nbsp;&nbsp;&nbsp; } <br />}</p>
<p>&nbsp;</p>
<p>Just copy the code, paste it into a file called &ldquo;Build2014.ps1&rdquo;, create a directory (in my case &ldquo;d:\Build14&rdquo;) and change the path in the first line of the script.</p>
<p>Right click on the file and choose run with PowerShell.</p>
<p>&nbsp;</p>
<p>In case you get a problem similar like &ldquo;Build2014.ps1 cannot be loaded because running scripts is disabled on this system.&rdquo;</p>
<p>Start PowerShell as an administrator and run &ldquo;set-executionpolicy unrestricted&rdquo;, this is probably a bad thing to do for security.<br /><br /><br /></p>
