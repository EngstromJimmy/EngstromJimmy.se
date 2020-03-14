---
layout: post
title: How to use BingMapsDirectionsTask
date: 2011-09-30 17:04:00
categories: [Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>Mango introduces a new way to show directions called BingMapsDirectionsTask.</p>
<p>The usage is very simple:</p>
<p>&nbsp;</p>
<p>using Microsoft.Phone.Tasks;</p>
<p><br />BingMapsDirectionsTask directions = new BingMapsDirectionsTask(); <br />directions.Start= new LabeledMapLocation("start",new System.Device.Location.GeoCoordinate(59.3362,18.0710); <br />directions.End = new LabeledMapLocation("stop",new System.Device.Location.GeoCoordinate(59.3360, 18.0679); <br />directions.Show(); <br /> <br />Quite simple huh? But there is a catch, the above code won&rsquo;t work if you are using a regions format that uses comma instead of dot as a decimal separator. <br />Swedish is one of those. I have tried some different ways of solving that by doing a reverse geocoding with the bing services but it didn&rsquo;t help. <br />I haven&rsquo;t done a deep analysis of this but what I think happens is that the BingMapsDirectionsTask wont recognize the GeoCoordinates as a correct point and then uses the text I have supplied (in this case "start" and "stop") to try to find the address instead. But in this demo I don&rsquo;t have the correct address, and IF I did it wouldn&rsquo;t understand the special character of the swedish language (&aring;&auml;&ouml;) which will result in a box asking which address is the correct one, even though I know the correct GPS coordinates.</p>
<p>I don&rsquo;t want to ask the user, the user won't know. <br />My guess is that Microsoft will fix this soon, but perhaps not in Mango when it releases. <br /> <br />What can we do? There is a quite simple solution to solve this. Before you call the directions.Show() you can set the current culture to en-US and set it back. <br />This is how I solved it: <br /> <br />string realCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name; <br />try <br />{ <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; BingMapsDirectionsTask directions = new BingMapsDirectionsTask(); <br />&nbsp;&nbsp;&nbsp; directions.Start= new new LabeledMapLocation("start",new System.Device.Location.GeoCoordinate(59.3362,18.0710);&nbsp;&nbsp;&nbsp;&nbsp; directions.End = new LabeledMapLocation("stop",new System.Device.Location.GeoCoordinate(59.3360, 18.0679); <br />&nbsp;&nbsp;&nbsp; Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); <br />&nbsp;&nbsp;&nbsp; directions.Show(); <br />} <br />catch { } <br />finally <br />{ <br />&nbsp;&nbsp;&nbsp; Thread.CurrentThread.CurrentCulture = new CultureInfo(realCulture); <br />}</p>
<p>It will however still have problems with Swedish characters in LabeledMapLocation labels so you might want to avoid to supply special characters. In this particular case the important thing to me is that the direction task is working.</p>
<pre>&nbsp;</pre>
