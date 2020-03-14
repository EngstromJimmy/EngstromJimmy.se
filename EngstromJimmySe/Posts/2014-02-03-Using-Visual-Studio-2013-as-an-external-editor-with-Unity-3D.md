---
layout: post
title: Using Visual Studio 2013 as an external editor with Unity 3D
date: 2014-02-03 22:11:00
categories: [Windows-8]
author: Jimmy Engström
tags: [Unity3D]
hide: false
---
<p>Unity is really hot right now.<br />Out of the box unity comes with MonoDevelop, even though I like MonoDevelop I like CodeRush even more, and I have noticed that MonoDevelop doesn't always do the things that I want.<br />The solution is of course to use Visual Studio instead.</p>
<p>1. Start unity and choose Edit &ndash;&gt; Preferences&hellip;<br />2. Select External tools</p>
<p>In the External Script Editor drop down you may notice that Visual Studio 2013 is not part of the items.<br />(earlier versions will be available if you have them installed).</p>
<p><a href="/PostImages/image_21.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_21.png" alt="image" width="242" height="98" border="0" /></a></p>
<p><br />3. Choose browse&hellip; and browse to &ldquo;C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe&rdquo; <br />Now &ldquo;Microsoft Visual Studio 2013&rdquo; will appear in the drop down and you are all set, from now on Visual Studio will launch when you edit script files.</p>
<p>&nbsp;</p>
<p><a href="/PostImages/image_22.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_22.png" alt="image" width="520" height="443" border="0" /></a></p>
