---
layout: post
title: gadgeteer, first impressions
date: 2011-10-17 00:00:00
categories: [.NET-Micro-Framework,Gadgets]
author: Jimmy Engström
tags: [Gadgeteer]
hide: false
---
<p>Got my <a href="http://www.netmf.com/gadgeteer/">Gadgeteer</a> compatible <a href="http://www.ghielectronics.com/catalog/product/297">FEZ Spider kit</a> a couple of days ago.</p>
<p>For those not familiar with Gadgeteer, it is an open source toolkit for building small electronic devices using .NET Micros Framework. <br />Microsoft is behind this project and GHI is the first manufacturer to release compatible hardware.</p>
<p>I have used Netduino before, the &ldquo;problem&rdquo; with Netduino is that it is extremely basic, you really need to know electronics.</p>
<p>Since I read a lot of these things in school I thought it would be a piece of cake getting stared with Netduino but reality soon came knocking.</p>
<p>Apparently nearly everything I learned in school about these things are gone, quite easy to read up on but still an obstacle between me and my new hardware toy <img class="wlEmoticon wlEmoticon-smilewithtongueout" style="border-style: none;" src="/PostImages/wlEmoticon-smilewithtongueout_1.png" alt="Ler med tungan ute" />.</p>
<p><br />Gadgeteer is a fast prototyping kit that uses standard 10 pin sockets that are impossible to turn the wrong way. <br />It makes it really simple and removes obstacles between you and your finished prototype. <br />What I like about the Gadgeteer is that it has very little integrated functions, if you want Ethernet for example you need to connect the Ethernet module, there is not Ethernet built-in on the motherboard.</p>
<p>It has 14 connectors and every connector has a letter beside it. <br />The letter indicates what kind of module you can connect to that socket.</p>
<p>&nbsp;</p>
<p><strong>Installation</strong></p>
<p>Its really simple to get started, GHI has an <a href="http://www.tinyclr.com/forum/21/4268/">install-package</a> that include everything you need to make your first application, or perhaps gadget is a more accurate description.</p>
<p>&nbsp;</p>
<p><strong>Start Coding</strong></p>
<p>Now you are ready to start your first Gadgeteer project.</p>
<p>In Visual Studio you will find a new template section called Gadgeteer, to start making an app simply select &ldquo;.NET Gadgeteer Application&rdquo;.</p>
<p>What I saw next really made me happy, in Visual Studio you&rsquo;ll get a designer window.</p>
<p>You only need to drag in the modules you wish to use and connect them to a compatible socket.</p>
<p>The designer even tells you which sockets that are ok.</p>
<p>But it doesn&rsquo;t stop there! <br />Instead of connecting them manually you can right click and select &ldquo;connect all modules&rdquo; and the designer does the job for you.</p>
<p>These kind of help functions really makes me happy, I want to concentrate on coding not other things.</p>
<p>&nbsp;</p>
<p><strong>Some initial problems</strong> <br />I started of by adding a Multi color LED and wrote <br />led.TurnBlue();</p>
<p>And the LED did just that, it turned Green.. Say what now!? <br />Apparently there is a <a href="http://www.tinyclr.com/forum/21/4275/">bug</a>, in the LED&rsquo;s firmware, but GHI is working on the problem.</p>
<p><br />Next I tried to make a camera app, press a button, take a picture and show it on the screen.</p>
<p>However the buttons didn&rsquo;t trigger the pressed event this is also an known <a href="http://www.tinyclr.com/forum/21/4276/">issue</a>.</p>
<p>So the first two things I tried fail which actually made me a bit concerned.</p>
<p>GHI seems to be on top of things and is really active on their forums so I hope they will come up with a great solution.</p>
<p>Despite the initial problems I would say, buy this kit =) <br />There is a special feeling when you code runs on a device (like a phone for example). <br />There's an even more special feeling when your code runs on a device you just put together =)</p>
