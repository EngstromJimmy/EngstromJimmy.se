---
layout: post
title: Windows phone 8.1 and Bluetooth LE – Getting started
date: 2014-05-04 17:03:00
categories: [Gadgets,Windows-Phone]
author: Jimmy Engström
tags: []
hide: false
---
<p>With Windows phone 8.1 Microsoft also released the ability to communicate with Bluetooth Low Energy devices. <br />This is really exciting for Windows phone developers, this way we can start developing apps that can talk to devices without draining the battery dry.</p>
<p>Sadly this is not available in the developer preview of Windows phone 8.1, but will be available when Windows Phone 8.1 is released for general availability.</p>
<h3>Pairing</h3>
<p>The first step is always to pair with the device you want to connect to.<br />This is easy to do by going to Settings &ndash;&gt; Bluetooth on your phone and tapping on the device you wish to pair with, just as you would do with a&nbsp; &ldquo;ordinary&rdquo; Bluetooth device.</p>
<h3>&nbsp;</h3>
<h3>Capabilities</h3>
<p>To be able to communicate with Bluetooth Low energy (or Bluetooth Smart, as it&rsquo;s also called) you need to add a capability to your app.<br />This can&rsquo;t be done from a GUI, you need to edit the package.appmanifest manually and add the following lines of code just above &lt;/Package&gt;.</p>
<pre class="brush: xml;">&lt;Capabilities&gt;
  &lt;m2:DeviceCapability Name="bluetooth.genericAttributeProfile"&gt;
    &lt;m2:Device Id="any"&gt;
      &lt;m2:Function Type="serviceId:1803"/&gt;
    &lt;/m2:Device&gt;
  &lt;/m2:DeviceCapability&gt;
&lt;/Capabilities&gt;
</pre>
<p>Now you are are set to start coding =)</p>
<p>&nbsp;</p>
<h3>Iterate through devices</h3>
<p>To keep this as simple as possible, I&rsquo;ll just show you how to iterate through devices and pick up a predefined one.</p>
<pre class="brush: csharp;">BluetoothLEDevice currentDevice { get; set; }
string deviceName = "Philips AEA1000";
protected async override void OnNavigatedTo(NavigationEventArgs e)
{
    foreach (DeviceInformation di in await DeviceInformation.FindAllAsync(BluetoothLEDevice.GetDeviceSelector()))
    {
        BluetoothLEDevice bleDevice = await BluetoothLEDevice.FromIdAsync(di.Id);
        if (bleDevice.Name == deviceName)
        {
            currentDevice = bleDevice;
            break;
        }
    }
}
</pre>
<h3>Find out what your device can do</h3>
<p>GATT (Generic Attribute Profile) provides profile discovery and description services for <a href="http://en.wikipedia.org/wiki/Bluetooth_Low_Energy">Bluetooth Low Energy</a> protocol, it basically makes it possible to ask your device what it can do. The documentation for this is very thorough and shows how to communicate.</p>
<p>Here is how to get a list of the GATTServices your device supports.</p>
<pre class="brush: csharp;">List&lt;string&gt; serviceList = new List&lt;string&gt;();
foreach (var service in currentDevice.GattServices)
{
    switch (service.Uuid.ToString())
    {
        case "00001811-0000-1000-8000-00805f9b34fb":
            serviceList.Add("AlertNotification");
            break;
        case "0000180f-0000-1000-8000-00805f9b34fb":
            serviceList.Add("Battery");
            break;
        case "00001810-0000-1000-8000-00805f9b34fb":
            serviceList.Add("BloodPressure");
            break;
        case "00001805-0000-1000-8000-00805f9b34fb":
            serviceList.Add("CurrentTime");
            break;
        case "00001818-0000-1000-8000-00805f9b34fb":
            serviceList.Add("CyclingPower");
            break;
        case "00001816-0000-1000-8000-00805f9b34fb":
            serviceList.Add("CyclingSpeedAndCadence");
            break;
        case "0000180a-0000-1000-8000-00805f9b34fb":
            serviceList.Add("DeviceInformation");
            break;
        case "00001800-0000-1000-8000-00805f9b34fb":
            serviceList.Add("GenericAccess");
            break;
        case "00001801-0000-1000-8000-00805f9b34fb":
            serviceList.Add("GenericAttribute");
            break;
        case "00001808-0000-1000-8000-00805f9b34fb":
            serviceList.Add("Glucose");
            break;
        case "00001809-0000-1000-8000-00805f9b34fb":
            serviceList.Add("HealthThermometer");
            break;
        case "0000180d-0000-1000-8000-00805f9b34fb":
            serviceList.Add("HeartRate");
            break;
        case "00001812-0000-1000-8000-00805f9b34fb":
            serviceList.Add("HumanInterfaceDevice");
            break;
        case "00001802-0000-1000-8000-00805f9b34fb":
            serviceList.Add("ImmediateAlert");
            break;
        case "00001803-0000-1000-8000-00805f9b34fb":
            serviceList.Add("LinkLoss");
            break;
        case "00001819-0000-1000-8000-00805f9b34fb":
            serviceList.Add("LocationAndNavigation");
            break;
        case "00001807-0000-1000-8000-00805f9b34fb":
            serviceList.Add("NextDstChange");
            break;
        case "0000180e-0000-1000-8000-00805f9b34fb":
            serviceList.Add("PhoneAlertStatus");
            break;
        case "00001806-0000-1000-8000-00805f9b34fb":
            serviceList.Add("ReferenceTimeUpdate");
            break;
        case "00001814-0000-1000-8000-00805f9b34fb":
            serviceList.Add("RunningSpeedAndCadence");
            break;
        case "00001813-0000-1000-8000-00805f9b34fb":
            serviceList.Add("ScanParameters");
            break;
        case "00001804-0000-1000-8000-00805f9b34fb":
            serviceList.Add("TxPower");
            break;
        default:
            break;
    }
}
MessageDialog md = new MessageDialog(String.Join("\r\n", serviceList));
md.ShowAsync();
</pre>
<h3><br />Time for some fun, Lets make it beep!</h3>
<p>In my case I have a Key finder (key fob) and it implements (among other services) the Immediate Alert Service, which makes it possible to make it beep.<br />The GATT specification shows us how to communicate with the ImmediateAlertService<br />Download the <a href="https://www.bluetooth.org/docman/handlers/downloaddoc.ashx?doc_id=239390">PDF here</a>.</p>
<p><a href="/PostImages/image_25.png"><img style="display: inline;" title="image" src="/PostImages/image_thumb_25.png" alt="image" width="640" height="162" /></a><br /><br /><br />The documentation shows us that if we want to set the alert level we need to do that with &ldquo;Write without Response&rdquo;.<br />The different values for Alert Level can be <a href="https://developer.bluetooth.org/gatt/characteristics/Pages/CharacteristicViewer.aspx?u=org.bluetooth.characteristic.alert_level.xml">found here</a>.</p>
<p>Value 0, meaning &ldquo;No Alert&rdquo;</p>
<p>Value 1, meaning &ldquo;Mild Alert&rdquo;</p>
<p>Value 2, meaning &ldquo;High Alert&rdquo;<br /><br /></p>
<p>This snippet will make the key finder (key fob) sound a high alert.</p>
<pre class="brush: csharp;">var immediateAlertService = currentDevice.GetGattService(GattServiceUuids.ImmediateAlert);
var characteristics = immediateAlertService.GetCharacteristics(GattCharacteristicUuids.AlertLevel).First();
byte[] data = new byte[1];
data[0] = (byte)2;
await characteristics.WriteValueAsync(data.AsBuffer(), GattWriteOption.WriteWithoutResponse);
</pre>
<p>&nbsp;</p>
<p>In my next blog post I will go through more of the things you can do with a key finder (key fob).</p>
