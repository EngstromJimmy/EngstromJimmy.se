---
layout: post
title: Setting up source control for a HoloLens Unity project
date: 2016-09-19 08:00:00
categories: [HoloLens]
author: Jimmy Engström
tags: [HoloLens]
hide: false
---


### Don&#39;t source control generated files

When source controlling your Unity HoloLens project there is no reason to save the generated code since it is generated =)   
Unity won&#39;t replace some of the generated files so if you for example change icons/tiles in the Unity project, those part will not be replaced when generating the code again.   
A good practice is to export to new folders every time.   
&nbsp;   

### .Gitignore

There are only a couple of folders worth adding to source control.   
When setting up your project for the first time, just add the .gitignore file from here:   
[https://github.com/github/gitignore/blob/master/Unity.gitignore][1]   
That way only the important files will be controlled.   
&nbsp;   
You can also do this when creating a new project on GitHub.   
&nbsp;   
[![clip_image001.png][2]][2]   
&nbsp;   
&nbsp;   

### Setting up your project    
Go to Edit -&gt; Project Settings -&gt; Editor    
To make source control work hassle free, you should make sure version control has visible meta files (or hidden meta files, if you don&#39;t want to see them in Windows Explorer).   
It will add a meta file for each asset in you project, this will make sure that only the asset and the meta files gets tagged as changed if you change an asset, otherwise the whole folder would be tagged as changed.    
Also make sure Asset serialization -&gt; Mode is set to &quot;Force Text&quot; this will make your source control handle diffs (text is easier to handle than binary-files.   
Using the Hololens toolkit [http://www.apeoholic.se/hololens/2016/07/27/setting-up-a-hololens-unity-project.html][3] will change these settings for you.   
&nbsp;   
[![clip_image002.png][4]][4]   


[1]: https://github.com/github/gitignore/blob/master/Unity.gitignore
[2]: /PostImages/2016/09/yzuxsdvl.lse.png "clip_image001.png"
[3]: http://www.apeoholic.se/hololens/2016/07/27/setting-up-a-hololens-unity-project.html
[4]: /PostImages/2016/09/zpbh3byk.jhh.png "clip_image002.png"
[5]: https://developer.microsoft.com/sv-se/windows/holographic/best_practices_for_working_with_unity_and_visual_studio