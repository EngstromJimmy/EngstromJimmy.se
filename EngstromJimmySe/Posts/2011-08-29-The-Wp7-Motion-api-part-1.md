---
layout: post
title: The Wp7 Motion api part 1
date: 2011-08-29 23:35:00
categories: [Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>Augmented reality has really caught my eye, I just love how the computer generated items interact with the real world.</p>
<p>I have played with the SLAR toolkit which is a really awesome library, but its a little bit limited in what it can do since you need a marker to get it to work.</p>
<p>&nbsp;</p>
<p>How about augmented reality without markers? <br />In mango, developers are given access to two necessary components to make augmented reality a ehm.. reality.</p>
<p>Raw camera access (So we can show what the camera sees) <br />Compass (access to the compass)</p>
<p>With mango we also get a new sensor, the gyroscope (optional on mango phones).</p>
<p>&nbsp;</p>
<p>When I first tried using the compass it didn&rsquo;t work, that&rsquo;s because I was running the Mango Beta supplied by Microsoft.</p>
<p>The drivers for the compass is not included in that build, it is supplied by the phone manufacturer later on in the process.</p>
<p>&nbsp;</p>
<p>Let&rsquo;s go through the available sensors</p>
<p><strong> <br />Accelerometer</strong></p>
<p>An accelerometer measures acceleration forces. These could be static like measuring the constant pulling of gravity or more dynamic like moving (sudden starts and stops) or vibrating the accelerometer.</p>
<p>The normal use for an accelerometer is sensing if the phone is tilted (portrait or landscape) but can also be uses for example in games to steer something.</p>
<p>This sensor is available on all devices (including pre mango)</p>
<p>&nbsp;</p>
<p><strong>Compass</strong></p>
<p>A compass (or magnetometer) measures the strength and/or direction of magnetic fields.</p>
<p>Using the compass we can get our bearing relative to the geographic north.</p>
<p>Keep in mind that the Earths magnetic field are relatively weak and the compass will be easily manipulated by other fields.</p>
<p>To test an app using the compass I would advice you to go outside, inside there is much disturbance (in the force.. oh I mean &hellip; the magnetic fields).</p>
<p>The compass is optional in phones.</p>
<p>&nbsp;</p>
<p><strong>Gyroscope</strong></p>
<p>The gyroscope measures orientation changes, it will give you a more accurate measurement of how your device orientation has changed.</p>
<p>The gyro does not depend on gravity like the accelerometer, and unlike the accelerometer it will enable us to measure for example if you rotate your phone while placed on a flat surface.</p>
<p>Optional on Mango phones and missing on pre-mango.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>So how do we use this?</p>
<p>Microsoft has provided us with the Motion API which takes the available sensors and some magic to help us get more accurate and faster readings.</p>
<p>For the Motion API to be enabled you need at least Accelerometer and Compass (so you will be able to use it on pre-mango devices \o/ ).</p>
<p>&nbsp;</p>
<p>Here is my first video of an augmented reality app. <br />Its based on the code provided in the videos below in the resources section.</p>
<p>I also added a semi-transparent Bing map on top that the user can show or hide.</p>
<p>&nbsp;</p>
<div id="scid:5737277B-5D6D-4f48-ABFC-DD9C333F4C5D:5760dff0-79ff-4b62-9050-03c4384a6ea4" class="wlWriterEditableSmartContent" style="margin: 0px; display: inline; float: none; padding: 0px;">
<div>&nbsp;</div>
</div>
<p><iframe style="width: 510px; height: 369px;" src="//www.youtube.com/embed/NgF3SpY4LcM" frameborder="0" width="640" height="390"></iframe></p>
<p>&nbsp;</p>
<p>The videos below does a really good job describing how the Motion API works so I won&rsquo;t get into any details for now.</p>
<p>&nbsp;</p>
<p><strong>Resources <br /></strong>Great&nbsp; video explaining how things work <br /><a title="http://vimeo.com/27378156" href="http://vimeo.com/27378156">http://vimeo.com/27378156</a></p>
<p>Another great video to get started with augmented reality (with source code)</p>
<p><a title="http://vimeo.com/27377090" href="http://vimeo.com/27377090">http://vimeo.com/27377090</a></p>
