---
layout: post
title: Kinect Extensions
date: 2011-07-03 02:12:00
categories: [Gadgets,Kinect]
author: Jimmy Engström
tags: []
hide: false
---
<p>The Kinect SDK doesn&rsquo;t have any built-in gesture system, it is however quite easy to use joints and check how they relate to each other.</p>
<p>&nbsp;</p>
<p>For example: <br />if&nbsp; (data.Joints[JointID .HandRight].Position.Y &gt;&nbsp; data.Joints[JointID.ShoulderRight].Position.Y)</p>
<p>&nbsp;</p>
<p>That would trigger if I hold my right hand over my right shoulder. <br />It is still a bit hard to read and I wanted to simplify both reading and writing the code to check different joints, so I created a couple of extension methods to help out.</p>
<p>&nbsp;</p>
<p>Code that does the same as above would look like this using my extensions:<span style="color: #0000ff;"> <br />var</span>&nbsp; joints=data.Joints; <br />if&nbsp; (joints[JointID .HandRight].<strong><span style="color: #00ff00;">HigherThan</span></strong>(joints[JointID.ShoulderRight]))</p>
<p>&nbsp;</p>
<p>So far I have implemented:</p>
<p>HigherThan <br />LowerThan</p>
<p>BetweenVertically <br />BetweenHorizontally <br />ToTheLeftOf <br />ToTheRightOf</p>
<p>&nbsp;</p>
<p>Hope these extensions will help =)</p>
<pre><span style="font-family: segoe ui;">&nbsp;</span></pre>
<p><a href="/file.axd?file=2011/7/JointExtensions.zip">JointExtensions.zip (436.00 bytes)</a></p>
