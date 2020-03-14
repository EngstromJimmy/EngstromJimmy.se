---
layout: post
title: Windows 8 on a HP TouchSmart TX2
date: 2011-09-15 15:16:00
categories: [Windows-8]
author: Jimmy Engström
tags: []
hide: false
---
<p>I hade some difficulties installing Windows 8 Developer preview on my machine.</p>
<p>The setup complained about <a href="http://channel9.msdn.com/Forums/Coffeehouse/windows-8-install-says-dvdcd-driver-is-missing">cd/dvd driver is missing</a>, after some binging I found that the same error in Windows 7 was a result of a corrupt ISO, this did however not apply for me, my checksum was correct.</p>
<p>Since I wanted to rule out a burning issue I created a bootable USB-stick by using Windows 7 USB/DVD download tool found on <a href="http://wudt.codeplex.com/">codeplex</a>. <br />This didn&rsquo;t help still got the same error. <br /> <br />So what I ended up doing was installing Windows 8 from within Windows 7 (already installed on my laptop) (Really nice experience).</p>
<p>&nbsp;</p>
<p>When the installation was done I noticed that the touch worked great, really responsive but two things didn&rsquo;t work: Tap and Flick.</p>
<p>I downloaded the <a href="http://www.ntrig.com/Content.aspx?Page=Downloads_Drivers">Windows 7 n-trig drivers</a> and tried to install them but the installer doesn&rsquo;t work since I didn&rsquo;t have Windows 7 (the installer checked for that).</p>
<p>Using an application called <a href="http://legroom.net/software/uniextract">Universal Extractor</a> I unpacked the installation files and the ran DPInst as an administrator.</p>
<p>After that the touch experience works just as expected.</p>
<p>I find Windows 8 a lot faster than Windows 7 it gives just that little extra an old tired laptop needs.</p>
<p>&nbsp;</p>
<p>If you have any questions feel free to email me.</p>
<p>&nbsp;</p>
<p><strong>Resources</strong></p>
<p>Windows 8 developer preview</p>
<p><a href="http://msdn.microsoft.com/en-us/windows/apps/br229516">Website</a></p>
<p>&nbsp;</p>
<p>Universal extractor</p>
<p><a href="http://legroom.net/software/uniextract">Website</a></p>
<p>&nbsp;</p>
<p>Windows 7 USB/DVD download tool (possibly not needed)</p>
<p><a href="http://wudt.codeplex.com/">Website</a></p>
<p>&nbsp;</p>
<p>Windows 7 n-trig drivers</p>
<p><a href="http://www.ntrig.com/Content.aspx?Page=Downloads_Drivers">Website</a></p>
