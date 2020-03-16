---
layout: post
title: Getting started with Xamarin and Samsung Gear/Galaxy
date: 2019-07-30T06:00:00.000+00:00
categories:
- Xamarin
author: Jimmy Engström
tags:
- Xamarin, Tizen
hide: false

---
   
A couple of years ago I bought a Samsung Gear S3 watch (now rebranded as Samsung Galaxy Watch).   
It was one feature in particular that I thought was the most important one, I should be able to develop for it.   
I had heard that Xamarin was working on Tizen templates so the choice was easy.   

It took a couple of years until Xamarin support for the watch came out and by then I had other ongoing development projects.   
But I recently decided to revisit this and see how hard it would be to develop a simple Hello World application, it wasn&#39;t as straight forward as I would have hoped, and I decided to write this post to help others get started.   


### Getting Visual Studio up and running    

I like to run the latest stuff so I&#39;m running Visual Studio 2019 Preview at the time of writing.   
Make sure you have Mobile development with .NET installed (if not run Visual Studio installer again and add it)  
 &nbsp;   
[![clip_image001.png][1]][1]   

### Tizen SDK    
 
To get access to all the templates you need to install the Tizen SDK, Visual Studio will do this for you when you install the    
Tizen Extension and you have to install Java JRE 8 (later versions won&#39;t work).   
Download and install [Java SE Runtime Environment 8 ][2](you&#39;ll have to create an Oracle account if you don&#39;t have one)  
 1. Start Visual Studio  
 2. Choose the menu item Extensions and then Manage extensions  
 3. Search for &quot;Visual Studio Tools for Tizen&quot; and click download   
 &nbsp;   
   
[![clip_image002.png][3]][3]  
4. Restart Visual Studio    
   
Now you should have a menu Tools -&gt;Tizen  
 5. Start Tools -&gt; Tizen -&gt; Tizen Package Manager   
 &nbsp;   
   
[![clip_image003.png][4]][4]   
This will start the installation of the Tizen SDK.  
 6. Click Install new Tizen SDK  
 7. Create and browse to an empty folder where you want your SDK to be installed.   
 &nbsp;   
   
[![clip_image004.png][5]][5]   
[![clip_image005.png][6]][6]  
 8. When the installation is done open Tools -&gt; Tizen -&gt; Tizen Package Manager again (if it didn&#39;t start)   
 9. I have a Samsung Gear S3 running Tizen 4.0.0.4 So I want to install 4.0 Wearable  
Click Install to the right of 4.0 Wearable   
 &nbsp;   
   
[![clip_image006.png][7]][7]  
 10. We also need ***Samsung Certificate Extension***  which is located under Extension SDK  
[![clip_image007.png][8]][8]   
   
&nbsp;   
&nbsp;   
Now the Tizen SDK is installed   


### Setting up developer mode on your watch

Time to get the watch into developer mode.   
 1. On your watch go to settings  
 2. Go to About watch    
   
[![clip_image008.png][9]][9]   
&nbsp;  
 3. Go to software version  
 [![clip_image009.png][10]][10]   
   
&nbsp;  
 4. Find software version and tap it 5 times    
   
[![clip_image010.png][11]][11]   
&nbsp;   

### Setting up WIFI
   
The easiest way during development is probably to use the emulator, but I want my app in my watch straight away.  
 1. On you watch go to Setting s  
 2. Select Connections  
 3. Turn Off Bluetooth    
   
[![clip_image011.png][12]][12]   
&nbsp;  
 4. Turn on WIFI and connect to your WIFI network    
   
[![clip_image012.png][13]][13]   
&nbsp;  
 5. When you connect you will also be able to see your IP number if you scroll down.  
 Take a note of it we will use it later.  
 Remember having WIFI tuned on will drain your battery so make sure you have a charger near by.    
   
### Putting it together

Ok we have a developer unlocked and WIFI connected watch and we have Visual Studio all set up, let&#39;s put it together.  
 1. Go back to Visual Studio  
 2. Click Tools -&gt; Tizen -&gt; Tizen Device Manager   
 &nbsp;   
   
[![clip_image013.png][14]][14]  
 3. Click the Remote Device Manager button  
 4. Click the add button   
 &nbsp;   
   
[![clip_image014.png][15]][15]   
&nbsp;   
&nbsp;  
 5. Enter your information and click add   
 &nbsp;   
   
[![clip_image015.png][16]][16]  
 6. Click the Connection button (if this doesn&#39;t work, restart your watch)   
 &nbsp;   
   
[![clip_image016.png][17]][17]   

 &nbsp;   
[![clip_image017.png][18]][18]   

### Your first app

Now we have a connection to our watch, let&#39;s write our first app.   
 1. In Visual Studio, create a new project use the template Tizen Wearable Xaml App   
[![clip_image018.png][19]][19]  
 2. In the solution explorer select MainPage.xaml  
 3. Look for &quot;Welcome to Xamarin.Forms!&quot; and change it to something else &quot;Hello World from Tizen&quot;.  
 4. In the solution explorer right click on your project select properties.  
 5. Goto Tools-&gt;Tizen -&gt; Tizen Certificate Manager  
[![clip_image019.png][20]][20]  
 6. Just press ok if you don&#39;t have any previous profiles  
 7. Click the +  
 8. Choose Samsung    
 [![clip_image020.png][21]][21]   
9. Choose Mobile/Wearable    
[![clip_image021.png][22]][22]  
 10. Name your profile  
 [![clip_image022.png][23]][23]  
 11. Create a new author certificate    
   
[![clip_image023.png][24]][24]  
 12. Enter a name and password (Our company name is Azm Dev)    
   
[![clip_image024.png][25]][25]  
 13. Sign in with your Samsung Account (if you don&#39;t have one, create one)  
 14. Create a new Distributor certificate    
   
[![clip_image025.png][26]][26]  
 15. Close Tizen Certificate Manager  
 16. Goto tools -&gt; Options -&gt; Tizen -&gt; Certification    
   
Make sure &quot;Sign the .TPK file using the following option&quot; is checked   
It should find your profile automatically   
 &nbsp;   
[![clip_image026.png][27]][27]   
&nbsp;  
 17. Click OK  
 18. Check the deployment is your watch  
 &nbsp; 
 [![clip_image027.png][28]][28]  
 19. Now press Ctrl + F5 (Run without debugging)  
 20. Check your watch you now have &quot;MyApp&quot; (or the name you used) installed.    
   
&nbsp;   
[![clip_image028.png][29]][29]
&nbsp;   
&nbsp;   
As I mentioned I am using Visual Studio 2019 Preview, and it is missing the important &quot;use preview framework&quot; checkbox.   
After many hours of debugging I came to the conclusion that you cannot run Visual Studio 2019 Preview and have .NET Core 3 preview SDKs installed, that will make the apps break.   
So I uninstalled the .NET Core 3 SDKs and things started to work.  

Hope this post has helped you and please let me know if I missed something or if I can help on any other way.   
&nbsp;   
&nbsp;   
&nbsp;   
&nbsp;   
Helpful links   
[https://developer.tizen.org/development/visual-studio-tools-tizen/installing-visual-studio-tools-tizen?langredirect=1 ][30]   
     

[1]: /PostImages/vrabm1bc.xu4.png "clip_image001.png"
[2]: https://www.oracle.com/technetwork/java/javase/downloads/jre8-downloads-2133155.html
[3]: /PostImages/ifzp5pw0.qin.png "clip_image002.png"
[4]: /PostImages/1illzw1e.4g4.png "clip_image003.png"
[5]: /PostImages/ozkclujk.jtu.png "clip_image004.png"
[6]: /PostImages/kkg5k3kd.bsr.png "clip_image005.png"
[7]: /PostImages/yo13nkp0.30s.png "clip_image006.png"
[8]: /PostImages/e0fbpc2n.gng.png "clip_image007.png"
[9]: /PostImages/qde10ovh.2i1.png "clip_image008.png"
[10]: /PostImages/bw052qg5.hlk.png "clip_image009.png"
[11]: /PostImages/kklcdpho.o4d.png "clip_image010.png"
[12]: /PostImages/lfic1itl.yd2.png "clip_image011.png"
[13]: /PostImages/5vqswern.si1.png "clip_image012.png"
[14]: /PostImages/rnkkthzo.khd.png "clip_image013.png"
[15]: /PostImages/aucudi43.piw.png "clip_image014.png"
[16]: /PostImages/2zt3tfxr.srs.png "clip_image015.png"
[17]: /PostImages/qwaz32hg.pqu.png "clip_image016.png"
[18]: /PostImages/wp21jcyb.nzc.png "clip_image017.png"
[19]: /PostImages/ydjxgphs.khe.png "clip_image018.png"
[20]: /PostImages/1twju14e.rh2.png "clip_image019.png"
[21]: /PostImages/pycit5dj.d1t.png "clip_image020.png"
[22]: /PostImages/d2tatgdx.e4x.png "clip_image021.png"
[23]: /PostImages/5j2ncynq.1sb.png "clip_image022.png"
[24]: /PostImages/n0swajhr.pwd.png "clip_image023.png"
[25]: /PostImages/kagflyvv.si1.png "clip_image024.png"
[26]: /PostImages/erui1aqp.lmc.png "clip_image025.png"
[27]: /PostImages/i53dr0mb.g3d.png "clip_image026.png"
[28]: /PostImages/ucyqjz5z.p0d.png "clip_image027.png"
[29]: /PostImages/1s44zvu0.z3b.png "clip_image028.png" 
[30]: https://developer.tizen.org/development/visual-studio-tools-tizen/installing-visual-studio-tools-tizen?langredirect=1