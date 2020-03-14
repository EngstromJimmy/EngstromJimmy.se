---
layout: post
title: translating an application bar in wp7
date: 2011-04-11 21:31:00
categories: [Windows-Phone]
author: Jimmy Engström
tags: [WP7]
hide: false
---
<p>When using the Applicationbar in WP7 I noticed that it can&rsquo;t be translated like all the other controls.</p>
<p>Therefore I built a simple helper class to help with the translations.</p>
<p>The usage is simple, just add the translations in a resource file (like you normally would) and then set the text property on the buttons or menu items to the name in the resource file. <br />Change the access modifier to public. <br /> <br />The Resources: <br /> <br /><a href="/PostImages/image_3.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_3.png" alt="image" width="474" height="178" border="0" /></a></p>
<p><br />The xaml: <br /> <br /><a href="/PostImages/image_4.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border-width: 0px;" title="image" src="/PostImages/image_thumb_4.png" alt="image" width="475" height="210" border="0" /></a></p>
<p>&nbsp;</p>
<p>Now in the page loaded event add:<span style="color: #2b91af;"> <br />ApplicationBarHelper</span><span style="color: #000000;">.LocalizeAppBar(<span style="color: #0000ff;">new</span><span style="color: #000000;">&nbsp; <span style="color: #2b91af;">AppResource</span><span style="color: #000000;"> (), ApplicationBar);</span></span></span></p>
<p><span style="color: #000000;"><span style="color: #000000;"><span style="color: #000000;"> <br /></span></span></span></p>
<p>Your application bar will now be automagically translated.</p>
<p><br />Update 2011-09-30 <br />Found a small bug where &ldquo;No Translation&rdquo; was shown the second time the page was shown (and the translation was already done). <br />I have updated the sample code to fix that problem. </p>
<p><a href="/file.axd?file=2011/4/AppbarHelperSample.zip">AppbarHelperSample.zip (79.13 kb)</a></p>
