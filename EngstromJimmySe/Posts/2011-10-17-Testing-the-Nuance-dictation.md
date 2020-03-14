---
layout: post
title: Testing the Nuance speech kit
date: 2011-10-17 00:10:00
categories: [Windows-Phone]
author: Jimmy Engström
tags: [Speech,WP7,Windows-Phone]
hide: false
---
<p>Nuance recently released a windows phone 7 SDK for their text to speech and dictation services.</p>
<p>I have been looking for some kind of text to speech that can handle Swedish and also being able to control things with voice commands in Swedish.</p>
<p>I noticed that Nuance supported that so I decided to sign up as a developer.</p>
<p>Windows Phone 7 already supports TTS for reading sms and also some voice control for searching and opening applications but only support the major languages (Swedish not included).</p>
<p>I have an application idea for the Swedish market that could use voice control (no I&rsquo;m not saying what it is <img class="wlEmoticon wlEmoticon-smilewithtongueout" style="border-style: none;" src="/PostImages/wlEmoticon-smilewithtongueout_2.png" alt="Ler med tungan ute" /> ).</p>
<p>The SDK includes some sample code that makes it easy to get started.</p>
<p>What I didn&rsquo;t find anywhere was instructions on how to get this working for languages other than English, and I couldn&rsquo;t read the help files for some reason.</p>
<p>&nbsp;</p>
<p>So here is what you need to do:</p>
<p>For dictation support: Replace all the _oemconfig.defaultLanguage() with a string containing your preferred language (sv_SE for Swedish).</p>
<p>For TTS: Add a voice that supports your language (Alva for Swedish)</p>
<p>That is it, now you can play with the app.</p>
<p>I think it works ok, but not as good as I hoped.</p>
<p>&nbsp;</p>
<p><strong>NDEV Mobile</strong></p>
<p><a title="http://dragonmobile.nuancemobiledeveloper.com/public/index.php" href="http://dragonmobile.nuancemobiledeveloper.com/public/index.php">http://dragonmobile.nuancemobiledeveloper.com/public/index.php</a></p>
<p>&nbsp;</p>
<p><strong>Voices</strong> (this page is for another product but seems to be the same as the Mobile SDK</p>
<p><a title="http://www.nuance.com/vocalizer5/languages/" href="http://www.nuance.com/vocalizer5/languages/">http://www.nuance.com/vocalizer5/languages/</a></p>
