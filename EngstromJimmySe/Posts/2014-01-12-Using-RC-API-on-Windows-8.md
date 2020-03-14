---
layout: post
title: Using RC API on Windows 8.1
date: 2014-01-12 23:09:00
categories: [Gadgets,Windows-8]
author: Jimmy Engström
tags: []
hide: false
---
<p>This is a short blog post on how to get RC API working on your Windows 8.1 Device.</p>
<h3>Setup</h3>
<p>Download RCAPI from Nuget</p>
<p><a href="/PostImages/image_thumb%5B1%5D.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image_thumb[1]" src="/PostImages/image_thumb%5B1%5D_thumb.png" alt="image_thumb[1]" width="244" height="139" border="0" /></a></p>
<p>&nbsp;</p>
<h3>Bluetooth</h3>
<p>To be able to communicate thru Bluetooth you need to edit Package.appxmanifest</p>
<p>Add the following lines:</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:e3e5b9ea-05db-4c0d-be21-4f05781a6fc7" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: xml;">&lt;Capabilities&gt;
    ....
    &lt;m2:DeviceCapability Name="bluetooth.rfcomm"&gt;
      &lt;m2:Device Id="any"&gt;
        &lt;m2:Function Type="name:serialPort" /&gt;
      &lt;/m2:Device&gt;
    &lt;/m2:DeviceCapability&gt;
  &lt;/Capabilities&gt;</pre>
</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h3>Pair with the device</h3>
<p>Go into settings (win + c, Settings) , Change PC Settings, PC and Devices, Bluetooth</p>
<p>&nbsp; <a href="/PostImages/image_18.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; margin: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_18.png" alt="image" width="244" height="192" border="0" /></a></p>
<p>&nbsp;</p>
<h3>The Car</h3>
<p>Instantiate the car and you are good to go, the car class connects to the correct Bluetooth device automagically.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:53d4732a-7417-4c52-95f3-7790a2bc931e" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">Ferrari458Italia ferrari = new Ferrari458Italia();</pre>
</div>
<p>To start sending commands to the car you need to call the ConnectAsync method and call the Start method.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:9bce4745-b578-4d42-9c0b-4efdd6e5b111" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">await ferrari.ConnectAsync();
ferrari.Start();</pre>
</div>
<h3>&nbsp;</h3>
<h3>Controlling steering and speed</h3>
<p>There are two properties controlling speed and steering.</p>
<p>Steering is &ndash;1 to 1 (left to right) and speed &ndash;1 to 1 (backward to forward).</p>
<p>In the sample projects I have used the <a href="http://vjoystick.codeplex.com/">Virtual Joystick project</a> available on Codeplex for speed and steering, there is a modified version in the Windows Store sample project.</p>
<p>&nbsp;</p>
<h3>Controlling the lights</h3>
<p>The lights are exposed through properties, to turn the light on use:</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:c9be15c4-d4ba-4967-8c87-fe19b70ed715" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">ferrari.HeadLightOn = true;</pre>
</div>
<p>The lights available on the Ferrari 458 Italia is Headlights,blinkers (left and right) and break.</p>
<p>To get the lights to blink it is possible to supply an array with a light enum so if you want the blinkers to blink left</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:dcdd68b7-e60c-479d-9bde-3bad79be95e4" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">ferrari.LightSequence = new byte[] { (byte)LightEnum.LeftBlinker, 0 };</pre>
</div>
<p>To get a more fun blinking sequence you might want to try something like this</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:ecf468ba-159d-4b43-a64c-9402e5e59cb1" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: diff;">ferrari.LightSequence = new byte[] { (byte)LightEnum.Head, (byte)LightEnum.RightBlinker, (byte)LightEnum.Break, (byte)LightEnum.LeftBlinker };</pre>
</div>
<p>&nbsp;</p>
<h3>Trimmer</h3>
<p>Trimmer property makes it possible to adjust the wheel orientation 0 to 15 and 8 is straight forward.</p>
