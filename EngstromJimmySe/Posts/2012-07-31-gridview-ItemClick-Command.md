---
layout: post
title: How to use ItemClick in a Gridview with MVVM
date: 2012-07-31 04:26:00
categories: [Windows-8]
author: Jimmy Engström
tags: []
hide: false
---
<p>I have a gridview and I wanted to make something happen when I click an item.</p>
<p>My first though was binding my view model to the SelectedItem Property and on the setter make something happen, that&rsquo;s easy enough.</p>
<p>But I didn&rsquo;t want the item to get highlighted, so basically what I really wanted was to use the ItemClick property, I needed a way to use ItemClick with MVVM.</p>
<p>Searching the web I found a solution <a href="http://geoffwebbercross.blogspot.se/2012/05/windows-8-metro-gridview-itemclick.html">GridView ItemClick Command Attached Property</a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>To get this to work, create a class <span style="background: white; color: #2b91af;">GridViewItemClickCommand.cs </span>and just paste the code from Geoff&acute;s site (same as below).</p>
<pre class="brush: c-sharp; first-line: 1; tab-size: 4; toolbar: false; ">using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace AAWP.Commanding
{
    public class GridViewItemClickCommand
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), 

            typeof(GridViewItemClickCommand), new PropertyMetadata
  (null,CommandPropertyChanged));


        public static void SetCommand(DependencyObject attached, ICommand value)
        {
            attached.SetValue(CommandProperty, value);
        }


        public static ICommand GetCommand(DependencyObject attached)
        {
            return (ICommand)attached.GetValue(CommandProperty);
        }


        private static void CommandPropertyChanged(DependencyObject d, 
DependencyPropertyChangedEventArgs e)
        {
            // Attach click handler
            (d as GridView).ItemClick += gridView_ItemClick;
        }


        private static void gridView_ItemClick(object sender, 
ItemClickEventArgs e)
        {
            // Get GridView
            var gridView = (sender as GridView);


            // Get command
            ICommand command = GetCommand(gridView);


            // Execute command
            command.Execute(e.ClickedItem);
        }
    }
}
</pre>
<p>Create a new class that implement the ICommand Interface (Just as you normally would do).</p>
<pre class="code">&nbsp;</pre>
<pre class="brush: c-sharp; first-line: 1; tab-size: 4; toolbar: false; ">public class MyAwesomeCommand: ICommand
        {

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                //Make something happen
                
            }
        }</pre>
<pre class="code">&nbsp;</pre>
<p>&nbsp;</p>
<p>In your view model create a property of the type <span style="background: white; color: #2b91af;">MyAwesomeCommand</span></p>
<pre class="code"><span style="background: white; color: black;">&nbsp;</span></pre>
<pre class="brush: c-sharp; first-line: 1; tab-size: 4; toolbar: false; ">public MyAwesomeCommand MyAwesomeCommandItemClickCommand
        {
            get;
            set;
        }</pre>
<pre class="code">&nbsp;</pre>
<p>&nbsp;</p>
<p>Create an instance of the command (in the view model&rsquo;s constructor)</p>
<pre class="code"><span style="background: white; color: black;"><span style="background: white; color: black;">MyAwesomeCommandItemClickCommand</span>= </span><span style="background: white; color: blue;">new </span><span style="background: white; color: #2b91af;">MyAwesomeCommand </span><span style="background: white; color: black;">();</span></pre>
<p>&nbsp;</p>
<p>In the view we need to add a namespace</p>
<pre class="code"><span style="background: white; color: red;">xmlns</span><span style="background: white; color: blue;">:</span><span style="background: white; color: red;">cmd</span><span style="background: white; color: blue;">="using:AAWP.Commanding"</span></pre>
<p>&nbsp;</p>
<p>And on the grid we have to set three things (beside ItemsSource of course)</p>
<pre class="code"><span style="background: white; color: red;">IsItemClickEnabled</span><span style="background: white; color: blue;">="True" <br /></span><span style="background: white; color: red;">SelectionMode </span><span style="background: white; color: blue;">="None" <br /></span><span style="background: white; color: red;">cmd</span><span style="background: white; color: blue;">:</span><span style="background: white; color: red;">GridViewItemClickCommand.Command</span><span style="background: white; color: blue;">="{</span><span style="background: white; color: #a31515;">Binding </span><span style="background: white; color: red;">MyAwesomeCommandItemClickCommand</span><span style="background: white; color: blue;">}"</span></pre>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>I&rsquo;m not a believer in the 100% MVVM pattern in some cases the code gets hard to read and&nbsp; follow and I think readability is the most important thing. But I do believe it is possible to come close to 100% especially with these kind of really awesome solutions. <br />Thanks Geoff for sharing.</p>
