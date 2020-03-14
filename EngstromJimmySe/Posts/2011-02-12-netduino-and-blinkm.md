---
layout: post
title: netduino and blinkm
date: 2011-02-12 00:47:52
categories: []
author: jimmy
tags: []
hide: false
---
<p>Today I played around with a Blinkm, an RGB led that can be programmed from the Netduino.</p>  <p>There are some examples on how to connect the Blinkm to an Arduino but I wasn’t able to find a good guide or good sample code.</p>  <p>First of all the Blinkm cannot be connected to the Netduinos analog pins 2-5, some samples uses pin 2-3 for power but the Netduino doesn’t have enough voltage in those pins to power up the Blinkm.</p>  <p>Secondly, you’ll need a couple (2) of pull up resistors on c and d pin on the Blink.&#160; <br />If you aren’t familiar with the term it’s just normal resistors connected to +.</p>
