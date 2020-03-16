---
layout: post
title: Setting up a HoloLens Unity project
date: 2016-07-27 10:00:00
categories: [HoloLens]
author: Jimmy Engström
tags: [HoloLens,Azure,Unity]
hide: false
---
You can create apps for HoloLens by using UWP (ordinary 2D apps), you can also make 3D apps by using tools like Unity.   
This post will cover what you need to do to setup a Unity project to work on HoloLens.   

&nbsp;   
I have had the opportunity to work with HoloLens for a while now and I should share some of my tips and tricks.   

### The Tools

You need Unity installed on your computer, follow the instructions here:   
[http://unity3d.com/pages/windows/hololens][1]   
&nbsp;   
While you&#39;re at it, I would also recommend installing Visual Studio 2015 and the HoloLens emulator (not needed for this blog post).   
[https://developer.microsoft.com/en-us/windows/holographic/install_the_tools][2]   
  
### Setting things up

Let&#39;s take a look at what you need to do to set everything up.   
I will show a really simple way to do that.    
  
#### Create new project

Start with creating a new Unity project.   
[![clip_image001.png][3]][3]   
&nbsp;   
Name it something, in my case I named it DemoProject   
&nbsp;   
[![clip_image002.png][4]][4]   
&nbsp;   
&nbsp;   
Unity will now create our world.   
  
### HoloToolkit

Microsoft also provides HoloToolkit, a library containing a lot of useful components you can use when building HoloLens apps, you also get a couple of menu items that automatically make the changes you need.   
You can download it from HoloToolkit.azurewebsites.net (or from github).   
This will show a list of files to be imported, just click Import and the installation will take care of everything,   
&nbsp;   
[![clip_image003.gif][5]][5]   
&nbsp;   
Now you should see a menu item called HoloToolkit.   
[![clip_image004.png][6]][6]   
&nbsp;   
First delete the camera and then add the *Camera.prefab*  in the HoloToolkit/Utilities/Prefabs folder, this camera is customized for holographic development.   
In the HoloLens emulator you can move around using the aswd keys.   
To enable the same behavior in the Unity player you can add *ManualCameraControl.cs*  (HoloToolkit/Utilities/Scripts) to your camera.   
To fix the scene (set the correct position of the camera amongst other things) click &quot;Apply HoloLens Scene Settings&quot;.   
Now save your scene and place it in a folder called Scenes (or whatever location you prefer).   
Now click the &quot;Apply HoloLens Project Settings&quot; it will make sure the near plane is set to a good value and make sure Holographic is available in the project.   
You will get a couple of questions you can just select yes and then restart the project (Unity will do that automatically).   
&nbsp;   
Now you are all done, and it&#39;s time to create your holograms, but that will be the subject of another blog post.   
&nbsp;   
If you want to know in detail what changes these scripts made , here is an excellent [blog post][7] .   
You can also read more [here][8]   
&nbsp;   

[1]: http://unity3d.com/pages/windows/hololens
[2]: https://developer.microsoft.com/en-us/windows/holographic/install_the_tools
[3]: /PostImages/2016/07/clip_image001.png "clip_image001.png"
[4]: /PostImages/2016/07/clip_image002.png "clip_image002.png"
[5]: /PostImages/2016/07/clip_image003.gif "clip_image003.gif"
[6]: /PostImages/2016/07/clip_image004.png "clip_image004.png"
[7]: http://sharpgis.net/post/2016/04/10/Creating-your-very-first-holographic-app-in-Unity
[8]: https://developer.microsoft.com/en-us/windows/holographic/unity_development_overview#configuring_a_unity_project_for_hololens