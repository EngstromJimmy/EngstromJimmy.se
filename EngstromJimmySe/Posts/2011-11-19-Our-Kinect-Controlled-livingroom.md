---
layout: post
title: Our Kinect Controlled living room
date: 2011-11-19 17:44:00
categories: [Gadgets,Kinect]
author: Jimmy Engström
tags: []
hide: false
---
<p>Recently I created a project for a Swedish Kinect contest at <a href="http://www.migbi.se/iseeyou/kolla-in-experiment.aspx">Migbi.se</a> this was my second entry, my first one (and third place winner) was my <a href="http://apeoholic.se/post/Kinect-2b-Robosapien-3d-3c3.aspx">Robosapien project.</a></p>
<p>I have always been fascinated by home automation, I bought my first X-10 system ten years ago.</p>
<p>My friends thought I was insane, &ldquo;-You can just get up an shut the light off".</p>
<p>But that&rsquo;s not the point, it&rsquo;s not because I&rsquo;m lazy it&rsquo;s all about removing obstacles, what if when I enter a room the lights turns on, when I go to bed everything turns off.</p>
<p>Saves energy, saves time, removes obstacles.</p>
<p>&nbsp;</p>
<p>Peter Forss made a really cool <a href="http://www.migbi.se/arkiv/2011/9/19/kilight.aspx">entry</a> to the contest, his project turns on and off lights depending on where he is in the room.</p>
<p>This inspired me, I wanted to do something with Kinect and home automation.</p>
<p>&nbsp;</p>
<p>I had previously built a home automation system that can control our home (lights, infrared devices etc) so the only thing I needed to do is hook up the Kinect. <br />I wanted to be able to control what lights to turn on just by pointing at them.</p>
<p>So here is my attempt to control our living room with a Kinect.</p>
<p>&nbsp;</p>
<div id="scid:5737277B-5D6D-4f48-ABFC-DD9C333F4C5D:a3c6d8f7-43cc-42a0-ab14-c691e771f234" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div>&nbsp;</div>
<iframe src="//www.youtube.com/embed/PzvIsBau_88" frameborder="0" width="640" height="390"></iframe>
<div style="width: 448px; clear: both; font-size: .8em;">Kinected living room</div>
</div>
<p>&nbsp;</p>
<p><strong>How it works</strong></p>
<p>I added all my light in an array with the lights X and Z position relative to the kinect sensor (in meters).</p>
<p>For each light, I calculate the angle from where I am in the room to the light and compare it to the angle between me (my body&rsquo;s centre) and my hand.</p>
<p>&nbsp;</p>
<p>Then I check for the light on gesture (hand under shoulder moved to over shoulder) or light off gesture (hand over shoulder moved to below shoulder).</p>
<p>&nbsp;</p>
<p>These gestures sends a command to my home automation system to executes the correct command.</p>
<p>It uses a <a href="http://telldus.com/products/tellstick">Tellstick</a> to control the lights, the beauty of that device is that it can control close to any type of protocol (I use Nexa or in some cases the cheapest possible plug-in lamp module I could find, it also works with X10).</p>
<p>&nbsp;</p>
<p>In this video I only control lights and screen, but it is possible to control infrared devices like tv or home cinema.</p>
<p>&nbsp;</p>
<p>Please feel free to send me an email if you have any questions.</p>
