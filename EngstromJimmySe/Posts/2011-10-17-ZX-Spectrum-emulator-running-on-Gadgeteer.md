---
layout: post
title: ZX Spectrum emulator running on Gadgeteer
date: 2011-10-17 00:29:00
categories: [.NET-Micro-Framework]
author: Jimmy Engström
tags: [Gadgeteer,ZX-Spectrum]
hide: false
---
<p>First off I would like to start with saying that the title on this blog post might be just a little exaggerated.</p>
<p>The Gadgeteer is running C# code that emulates the ZX Spectrum and so far it&rsquo;s true.</p>
<p>Basically the emulator works by running cycles, showing the screen and repeating.</p>
<p>To get the correct timing this should be done 50 times per second, which means that we have 20ms to complete one cycle and show the screen.</p>
<p>The Gadgeteer is far from fast enough to achieve that, right now it takes&nbsp;10 seconds&nbsp;to complete a cycle.</p>
<p>But this wasn&rsquo;t the point, I suspected it wouldn&rsquo;t be fast enough. The point was that is was possible \o/. <br />Within hours I managed to connect a screen to the Gadgeteer and make the necessary changes in the code to make it run.</p>
<p>For example I had to change List&lt;&gt; to an array, the .NET Micro framework doesn&rsquo;t support List&lt;&gt;, and I rewrote the screen rendering to make it faster.</p>
<p>&nbsp;</p>
<p>I find it fantastic that I can use my C# knowledge to create new hardware prototypes among all the other things like: xbox games, Windows Phone applications and games, Windows applications and games, and even write Iphone and Android applications.</p>
<p>There is no end to the possibilities =)</p>
<p>&nbsp;</p>
<p><a href="/PostImages/GadgetZX.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="GadgetZX" src="/PostImages/GadgetZX_thumb.png" alt="GadgetZX" width="244" height="216" border="0" /></a></p>
