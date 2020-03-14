---
layout: post
title: download all videos from build 2013
date: 2013-07-08 11:37:00
categories: [Windows-8,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>I&rsquo;m currently watching all the videos from Build 2013 to be able to create a blog post with the best sessions from build.</p>
<p>If you also would like to watch all the videos here is a simple PowerShell script I found at <a href="http://geekswithblogs.net/mbcrump/archive/2011/09/15/download-all-the-build-videos-with-rss.aspx">Michael Crump&rsquo;s blog</a> with a small modification to get 2013 videos instead of 2011 and added more descriptive names.</p>
<p>&nbsp;</p>
<p>cd "e:\build13"</p>
<p>$pattern = "[{0},\:,\']" -f ([Regex]::Escape([String][System.IO.Path]::GetInvalidPathChars()))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />$pattern <br />[Environment]::CurrentDirectory=(Get-Location -PSProvider FileSystem).ProviderPath <br />$a = ([xml](new-object net.webclient).downloadstring("<a href="http://channel9.msdn.com/Events/Build/2013/RSS/wmvhigh&quot;))">http://channel9.msdn.com/Events/Build/2013/RSS/wmvhigh"))</a> <br />$a.rss.channel.item | foreach{&nbsp; <br />&nbsp;&nbsp;&nbsp; $url = New-Object System.Uri($_.enclosure.url) <br />&nbsp;&nbsp;&nbsp; $file = [Regex]::Replace($_.Title + " " + $url.Segments[-1] , $pattern, ' ') <br />&nbsp;&nbsp;&nbsp; $file <br />&nbsp;&nbsp;&nbsp; if (!(test-path $file)) <br />&nbsp;&nbsp;&nbsp; { <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (New-Object System.Net.WebClient).DownloadFile($url, $file) <br />&nbsp;&nbsp;&nbsp; } <br />}</p>
<p>&nbsp;</p>
<p>Just copy the code, paste it into a file called &ldquo;Build2013.ps1&rdquo;, create a directory (in my case &ldquo;E:\Build13&rdquo;) and change the path in the first line of the script.</p>
<p>Right click on the file and choose run with PowerShell.</p>
<p>&nbsp;</p>
<p>In case you get a problem similar like &ldquo;Build2013.ps1 cannot be loaded because running scripts is disabled on this system.&rdquo;</p>
<p>Start PowerShell as an administrator and run &ldquo;set-executionpolicy unrestricted&rdquo;, this is probably a bad thing to do for security.</p>
