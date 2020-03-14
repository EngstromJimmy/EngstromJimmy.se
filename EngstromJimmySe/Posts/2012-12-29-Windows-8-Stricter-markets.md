---
layout: post
title: Windows 8 Stricter markets
date: 2012-12-29 22:33:00
categories: [Windows-8]
author: Jimmy Engström
tags: []
hide: false
---
<p><strong>Background</strong> <br />Some markets in Windows 8 Store has stricter requirements than others.</p>
<p>Normally submitting to these markets will take a bit longer and has more things that you as a developer needs to think about compliance wise.</p>
<p>&nbsp;</p>
<p>Windows Phone has an awesome choice &ldquo;Distribute to all markets except those with stricter content rules&rdquo; but that choice is not available in Windows 8 Store.</p>
<p>&nbsp;</p>
<p>According to Windows phone store (and available for Windows 8) the markets with stricter content rules are:</p>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="64">Bahrain</td>
</tr>
<tr>
<td>China</td>
</tr>
<tr>
<td>Egypt</td>
</tr>
<tr>
<td>Indonesia</td>
</tr>
<tr>
<td>Iraq</td>
</tr>
<tr>
<td>Jordan</td>
</tr>
<tr>
<td>Kazakhstan</td>
</tr>
<tr>
<td>Kuwait</td>
</tr>
<tr>
<td>Lebanon</td>
</tr>
<tr>
<td>Libya</td>
</tr>
<tr>
<td>Malaysia</td>
</tr>
<tr>
<td>Oman</td>
</tr>
<tr>
<td>Pakistan</td>
</tr>
<tr>
<td>Qatar</td>
</tr>
<tr>
<td>Saudi Arabia</td>
</tr>
<tr>
<td>Tunisia</td>
</tr>
<tr>
<td>United Arab Emirates</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<p><strong>My solution</strong> <br />I have created a simple java script that uncheck the markets that have stricter content rules.</p>
<p>1. Right click on the link below and add as favourite.</p>
<p>This link: <a href="javascript:(function(x) {for (var i = 0; i &lt; x.length; i++) {y = document.getElementById('marketCheckBox' + x[i]);if (y){y.checked = false;}}alert('Markets with stricter rules should now be unchecked');})([34, 58, 63, 64, 15, 43, 69, 71, 78, 81, 48, 85, 51, 52, 53, 55, 56]);">Remove markets with stricter content rules</a></p>
<p>2. Go to the Selling Details for your Windows 8 app.</p>
<p>3. Press Select All (Which will select all markets)</p>
<p>4. Click the bookmark you just created</p>
<p>5. Internet Explorer will warn you, just select &ldquo;run content&rdquo; you might need to click the bookmark again.</p>
<p><br />Edit: Updated the script with a nicer looking one thanks to Peter Forss</p>
