---
layout: post
title: The Wp7 Motion api part 2
date: 2011-09-30 17:19:00
categories: [Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>What does the Motion API do?</p>
<p><br />Well basically it combines the different sensors into one sensor.</p>
<p>&nbsp;</p>
<p><strong>Accelerometer + Gyroscope <br /></strong>The accelerometer can tell the orientation of the phone by measuring the gravitational forces. <br />The gyroscope measures the changes in the orientation which means when you start the gyro it won&rsquo;t be able to tell you what orientation the phone has but it can tell when and how much the orientation changes. <br />The motion API combines these two values to get the phone's orientation with the accelerometers and uses that as a baseline and then adjust these values with changes from the Gyroscope. <br />The gyro has a tendency to drift over time so the accelerometer will be used to adjust the gyroscope from time to time.</p>
<p>&nbsp;</p>
<p><strong>Compass + Gyroscope <br /></strong>The compass is a slow sensor and is used the same way as the accelerometer as a baseline for the gyro.</p>
<p>The Motion API uses the compass to get the heading (North) and then uses the gyro changes to adjust the bearing. <br />Since the gyro has a tendency to drift (as I mentioned before) the compass will be used to adjust these values over time.</p>
<p>The compass is also very sensitive to magnetic fields and jumps around a lot, the gyro will smooth these readings out.</p>
<p>&nbsp;</p>
<p>The gyro do not contribute with any &ldquo;new&rdquo; values, the accelerometer and compass will do just fine when it come to retrieving the phone's orientation and which way it is facing however it will speed up these readings and make them a whole lot smoother.</p>
<p>The gyro is also more precise for smaller movements.</p>
<p>&nbsp;</p>
<p>I&rsquo;m definitely seeing to that my next phone will have a gyroscope, it makes the augmented reality experience a whole lot better.</p>
