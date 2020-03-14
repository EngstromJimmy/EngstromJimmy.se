---
layout: post
title: Getting windows azure accelerator for web roles to work
date: 2012-03-22 23:23:00
categories: [Other]
author: Jimmy Engström
tags: []
hide: false
---
<p>&ldquo;The Windows Azure Accelerator for Web Roles makes it quick and easy for you to deploy one or more websites across multiple Web Role instances using Web Deploy.&rdquo;</p>
<p>That&rsquo;s how the git hub project page describes the project.</p>
<p>Kristofer Liljeblad from Microsoft showed me a demo of this on a conference (&Oslash;redev) we both attended.</p>
<p>Really awesome stuff, this project makes it possible to deploy one or multiple sites within one web role.</p>
<p>I intend to use this for a number of small sites, mostly WCF projects for my windows phone apps.</p>
<p>It should be noted that perhaps it is not the best option for really large sites.</p>
<p>&nbsp;</p>
<p>The project is available on github:<br /><a title="https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles" href="https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles">https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles</a></p>
<p>&nbsp;</p>
<p>What I noticed when installing this is that the VSIX files (providing Visual studio templates) no longer where included and the setup file for version 1.1 where missing, and since the project now looks to be completely different, any guides currently available won&rsquo;t do the trick.</p>
<p>&nbsp;</p>
<h3>Prerequisites</h3>
<p>There are a few thing you&rsquo;ll need to have on your computer to be able to use Azure.<br />I&rsquo;m quite new to Azure so I needed to install them.</p>
<p>1. <strong>Windows Azure SDK</strong><br />Download and install from <a title="http://www.windowsazure.com/sv-se/develop/downloads/" href="http://www.windowsazure.com/develop/downloads/ ">http://www.windowsazure.com/develop/downloads/ </a></p>
<p>and click on the .net link.<br />This will download and open Web platform installer with Azure already selected.</p>
<p>Click install and let the installer do its magic.</p>
<p>2. <strong>SQL Server</strong></p>
<p>To be able to debug your Windows Azure apps you&rsquo;ll need SQL server (express is enough) on your machine.</p>
<p>It is possible to connect to an SQL server on another machine but it will have to know about your user (i.e connected to the same domain), since I&rsquo;m not connected to a domain it was less work to install SQL server.</p>
<p>&nbsp;</p>
<h3>Setting up the project</h3>
<p>1. <strong>Download the source</strong></p>
<p>The latest source should be available from here:<br /><a title="https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles/zipball/master" href="https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles/zipball/master">https://github.com/WindowsAzure-Accelerators/wa-accelerator-webroles/zipball/master</a></p>
<p>2. <strong>Extract the zip</strong> <br />and open the AzureMultiTenantApp.sln in Visual Studio</p>
<p>The solution contains three projects</p>
<p><a href="/PostImages/image_5.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_5.png" alt="image" width="244" height="75" border="0" /></a></p>
<p>&nbsp;</p>
<p>First open the <strong>AzureMultiTenantApp.Web</strong> located under AzureMultiTanantApp.Cloud\Roles.</p>
<p><strong>Configuration</strong><br />Here we can setup the configuration, in my case I only want one instance and a small VM.</p>
<p><a href="/PostImages/image_6.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_6.png" alt="image" width="244" height="93" border="0" /></a></p>
<p>&nbsp;</p>
<p><strong>Settings<br /></strong>You probably want to change the <em>AdminUserPassword</em> to something a bit more tricky =)</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h3>storage and Connectionstring</h3>
<p>Create a new storage in the Azure management portal.</p>
<p><a title="https://windows.azure.com/default.aspx" href="https://windows.azure.com/default.aspx">https://windows.azure.com/default.aspx</a></p>
<p>Storage accounts &ndash;&gt; new storage account</p>
<p>Let us call it &ldquo;storagename&rdquo; and select the region where you want your data stored.</p>
<p>&nbsp;</p>
<p><a href="/PostImages/image_7.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_7.png" alt="image" width="334" height="191" border="0" /></a></p>
<p>&nbsp;</p>
<p>Now it is time to construct a connectionstring, a connectionstring to azurestorage looks like this:</p>
<pre>DefaultEndpointsProtocol=https;AccountName=NAME;AccountKey=KEY</pre>
<pre>The key can be found in the Azure management portal, select the storage and to the right side you will find it.</pre>
<pre>&nbsp;</pre>
<pre><a href="/PostImages/image_8.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_8.png" alt="image" width="310" height="128" border="0" /></a></pre>
<pre>&nbsp;</pre>
<pre>You can use either one of them.</pre>
<pre>&nbsp;</pre>
<pre>We need to add this connectionstring in two places</pre>
<pre>First we need to add a new connectionstring in the file ServiceConfiguration.Cloud.cscfg </pre>
<pre>&lt;Setting name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" value="DefaultEndpointsProtocol=https;AccountName=NAME;AccountKey=KEY" /&gt;</pre>
<pre>&nbsp;</pre>
<pre>Secondly add the same connectionstring to the DataConnectionString-setting in the same file.</pre>
<pre>&nbsp;</pre>
<pre>In the ServiceDefinition.csdef file under the Imports tag add:<br />&lt;Import moduleName="Diagnostics" /&gt;
</pre>
<h3>Publish time</h3>
<p>Finally time to publish =)</p>
<p>Right click on <em>AzureMultiTenantApp.Cloud</em> and select publish</p>
<p>&nbsp;</p>
<p><a href="/PostImages/image_9.png"><img style="background-image: none; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_9.png" alt="image" width="311" height="210" border="0" /></a></p>
<p>&nbsp;</p>
<p>Select Sign in to download credentials</p>
<p><br />Sign in with your live ID and follow the instructions</p>
<p>&nbsp;</p>
<p>Select a subscription end press next</p>
<p>&nbsp;</p>
<p><a href="/PostImages/image_10.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_10.png" alt="image" width="244" height="110" border="0" /></a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Enter a name for your Hosted Service and choose the location.</p>
<p>&nbsp;</p>
<p>Make sure that the storage name we created before is selected.</p>
<p>Check the Enable remote desktop for all roles and then click on settings, enter name and password and make sure the expiration date is set to something far away.</p>
<p>Also check the Enable Web Deploy for all web roles checkbox.</p>
<p>&nbsp;</p>
<p>Click next, read the summary and then publish.</p>
<p>&nbsp;</p>
<p>Publishing will take approximately 15-20 min</p>
<p>&nbsp;</p>
<p>And we are done, now you can surf to YOURHOSTEDSERVICENAME.cloudapp.net and login to your new portal =)</p>
<p>&nbsp;</p>
<p><a href="/PostImages/image_12.png"><img style="background-image: none; margin: 0px; padding-left: 0px; padding-right: 0px; display: inline; padding-top: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_12.png" alt="image" width="244" height="209" border="0" /></a></p>
