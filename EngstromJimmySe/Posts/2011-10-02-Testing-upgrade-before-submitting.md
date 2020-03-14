---
layout: post
title: Testing upgrade before submitting
date: 2011-10-02 11:57:36
categories: []
author: jimmy
tags: []
hide: false
---
<p>When I upgraded my Windows Phone 7 app (Stockholm Travel) some users reported problems.</p>  <p>The problems was a result of big changes, and made the app fail when reading from the Isolated Storage.</p>  <p>The problem here was when I tested the app in the emulator or in the phone it always deleted the previous version before deploying the new one, and by that clearing everything that was in the isolated storage.</p>  <p>&#160;</p>  <p>This is of course a very important scenario to test, but I didn’t know how.</p>  <p>&#160;</p>  <p>The I found <a href="http://wptools.codeplex.com/">Windows Phone Power Tools</a> which has the option to update the app in the phone leaving the Isolated Storage intact.</p>  <p>&#160;</p>  <p>So here is my tip if you save things to the isolated storage test the upgrade scenario.</p>  <p>1. Install Windows Phone Power Tools</p>  <p>2. Install the previous version of you app   <br />3. Tap around to get some data into isolated storage     <br />4. Upgrade to the new version    <br />5. Verify that the data is still there and everything works as expected.</p>
