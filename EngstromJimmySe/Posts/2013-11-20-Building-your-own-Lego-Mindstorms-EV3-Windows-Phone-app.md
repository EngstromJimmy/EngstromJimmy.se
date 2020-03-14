---
layout: post
title: Building your own Lego Mindstorms EV3 Windows Phone app
date: 2013-11-20 19:14:00
categories: [Gadgets,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>I just love gadgets, especially those I can develop for.</p>
<p>I recently got the Lego Mindstorms EV3-kit and of course I wanted to make a Windows Phone app to control it =D.<br />Here is a tutorial on how to make your own.</p>
<h3>The basics</h3>
<p>The EV3 has 2 different types of ports, motors and sensors.<br />Motor ports are A, B, C and D, Sensor ports are 1, 2, 3 and 4.</p>
<h3>Check the firmware</h3>
<p>To be able to use the API you need to have a firmware version &gt;= 1.03, You can check the version on the brick from the Settings tab-&gt; Brick Info &ndash;&gt; Brick FW<br />To update the firmware run &ldquo;LEGO MINDSTORMS EV3 Home Edition&rdquo; and choose Tools &ndash;&gt; Firmware Update</p>
<p><a href="/PostImages/image_14.png"><img style="display: inline;" title="image" src="/PostImages/image_thumb_14.png" alt="image" width="320" height="304" /></a></p>
<h3>Enable Bluetooth</h3>
<p>To be able to connect to the brick you need to enable Bluetooth you can do that on the brick from the Settings tab-&gt; Bluetooth.<br />Enable Visibility and Bluetooth.</p>
<h3>Pair with the brick</h3>
<p>Pair your phone with the brick by going to Settings &ndash;&gt; Bluetooth tap on &ldquo;EV3&rdquo;, the brick will now ask Ii f its ok to pair and then show a pin code.<br />Accept the default pin &ldquo;1234&rdquo; and enter it on the phone.</p>
<p>We are now all set up to start coding.</p>
<p>I have a Nokia Lumia 920 that I got from //Build, I can&rsquo;t connect to the brick using that one, it might be a problem with all Lumia 920 developer phone (please let me know).<br />Luckily I also have a retail Lumia 920 and I have tested this code on a Lumia 1020, 720, 920 and HTC 8X and it works great (just not the //Build one).</p>
<h3>Start a new project</h3>
<p><a href="/PostImages/image_15.png"><img style="display: inline;" title="image" src="/PostImages/image_thumb_15.png" alt="image" width="640" height="442" /></a></p>
<p>&nbsp;</p>
<p>Right click on references and click Manage Nuget packages</p>
<p>Search for "EV3&rdquo;</p>
<p><a href="/PostImages/image_16.png"><img style="display: inline;" title="image" src="/PostImages/image_thumb_16.png" alt="image" width="640" height="427" /></a></p>
<p>Click install on &ldquo;Lego Mindstorms EV3 API&rdquo;</p>
<p><br />Enable Bluetooth by opening Properties/WMAppManifest.xml <br />Enable the capability ID_CAP_PROXIMITY</p>
<p><a href="/PostImages/image_17.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_17.png" alt="image" width="273" height="484" border="0" /></a></p>
<p>&nbsp;</p>
<p>The API has the ability to connect to the EV3 by Wi-Fi, Bluetooth and USB for this project I will focus on Bluetooth only.</p>
<p>In MainPage.xaml<br />Create a button named &ldquo;ConnectButton&rdquo; and give it the text &ldquo;Connect&rdquo;<br />Create a button named &ldquo;MotorAForwardButton&rdquo; and give it the text &ldquo;Motor A forward&rdquo;<br />Create a button named &ldquo;MotorStopButton&rdquo; and give it the text &ldquo;Stop&rdquo;</p>
<p>Double click on each button to create the event handler in the code behind.</p>
<p>In MailPage.Xaml.cs att the following code:</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:005870f6-4ce6-41bc-9ae3-cbb22dc76068" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">private Brick brick;
private async void ConnectButton_Click(object sender, RoutedEventArgs e)
{
    brick = new Brick(new BluetoothCommunication(), true);
    await brick.ConnectAsync();
}

private void MotorAForwardButton_Click(object sender, RoutedEventArgs e)
{
    brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A, 50);
}
        
private void StopStopButton_Click(object sender, RoutedEventArgs e)
{
    brick.DirectCommand.StopMotorAsync(OutputPort.All, false);
}

protected override void OnNavigatedFrom(NavigationEventArgs e)
{
    brick.Disconnect();
    base.OnNavigatedFrom(e);
}</pre>
</div>
<p>&nbsp;</p>
<p>I have kept this sample really simple so you can get a quick start.<br />You should always add error handling and you should disable the buttons unless you already connected and so on.<br />This is just to get you started.<br />I realize that this sample isn&rsquo;t that exciting, but now we know how to control motors, time to kick things into gear and build some fun stuff =D</p>
<h3>Related links</h3>
<p><a title="https://legoev3.codeplex.com/" href="https://legoev3.codeplex.com/">https://legoev3.codeplex.com/</a><br />The site for the EV3 API, with video instructions</p>
<p><a title="http://www.lego.com/en-us/mindstorms/downloads/software/ddsoftwaredownload/download-software/" href="http://www.lego.com/en-us/mindstorms/downloads/software/ddsoftwaredownload/download-software/">http://www.lego.com/en-us/mindstorms/downloads/software/ddsoftwaredownload/download-software/</a><br />Download for LEGO MINDSTORMS EV3 Home Edition</p>
