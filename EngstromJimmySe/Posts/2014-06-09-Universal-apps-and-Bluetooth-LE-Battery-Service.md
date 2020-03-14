---
layout: post
title: Universal apps and Bluetooth LE – Battery Service
date: 2014-06-09 00:32:00
categories: []
author: Jimmy Engström
tags: []
hide: false
---
<p>Some devices exposes a battery service that can supply us with the current (no pun intended) battery level.<br />I started this blog series working with only Windows phone in mind, but then I realized if it is possible to achieve the same results with an universal app of course that&rsquo;s the route I should take.</p>
<h3>Capabilities</h3>
<p>To be able to communicate with Bluetooth low energy (or Bluetooth Smart, as it&rsquo;s also called) you need to add a capability to your app.<br />This can&rsquo;t be done from a GUI, you need to edit the package.appmanifest manually and add the following lines of code just above &lt;/Package&gt;.<br />Don&rsquo;t forget to do that in both your Windows 8 and Windows Phone projects.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:4205f830-1325-4e2c-abb9-b824f0e40b9c" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: xml;">  &lt;Capabilities&gt;
    &lt;m2:DeviceCapability Name="bluetooth.genericAttributeProfile"&gt;
      &lt;m2:Device Id="any"&gt;
        &lt;m2:Function Type="name:battery"/&gt;
      &lt;/m2:Device&gt;
    &lt;/m2:DeviceCapability&gt;
  &lt;/Capabilities&gt;</pre>
</div>
<p>Now you are are all set to start coding =)</p>
<p>&nbsp;</p>
<h3>Battery Level Service</h3>
<p>The battery service must implement read, and notify is optional.<br />What that means is that you can always assume that you will be able to read the battery level (if your device implements the battery service, but you have to check if it supports Notify&nbsp; (a good developer should always check <img class="wlEmoticon wlEmoticon-smilewithtongueout" style="border-style: none;" src="/PostImages/wlEmoticon-smilewithtongueout_4.png" alt="Ler med tungan ute" /> ).</p>
<p><a href="/PostImages/image_26.png"><img style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border: 0px;" title="image" src="/PostImages/image_thumb_26.png" alt="image" width="534" height="135" border="0" /></a></p>
<p>The value it returns is a byte with a value from 0 to 100 representing a percentage of the current charge (0 being fully discharged).</p>
<h3>The property</h3>
<p>This is just a standard property with a backing store.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:34ca603f-865b-4789-8256-405dece90f0f" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;"> private int _BatteryLevel;
        public int BatteryLevel
        {
            get
            {
                return _BatteryLevel;
            }
            set
            {
                _BatteryLevel = value;
                OnPropertyChanged();
            }
        }</pre>
</div>
<p>The interesting part is how we handle OnPropertyChanged to try to avoid &ldquo;The application called an interface that was marshalled for a different thread&rdquo;.<br />I found a very neat piece of code <a href="http://www.zagstudio.com/blog/1398#.U5TjdLuKBaR"><span style="text-decoration: underline;">here</span></a>.<br /><br /><br />My implementation looks like this:</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:a9987372-a9ba-418a-b669-6c697f927735" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">        public event PropertyChangedEventHandler PropertyChanged;

        private readonly CoreDispatcher _dispatcher;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (_dispatcher == null || _dispatcher.HasThreadAccess)
            {
                var eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
            else
            {
                IAsyncAction doNotAwait =
                    _dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    () =&gt; OnPropertyChanged(propertyName));
            }
        }</pre>
</div>
<p>&nbsp;</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:8dcf45d2-4245-44b8-b223-bf12093863fc" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;"> public BatteryServicePage()
        {
            if (!DesignMode.DesignModeEnabled)
            {
                _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            }
          ........
        }</pre>
</div>
<h3><br />Reading a value</h3>
<p>I have written a simple method that reads a value from the service and if it supports notification it will also start a subscription on those notifications.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:66d14b3f-6680-4322-a015-6b26c857e2a9" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;"> public async Task&lt;byte[]&gt; GetValue(Guid gattCharacteristicUuids)
        {
            try
            {
                var gattDeviceService = await GattDeviceService.FromIdAsync(Device.Id);
                if (gattDeviceService != null)
                {
                    var characteristics = gattDeviceService.GetCharacteristics(gattCharacteristicUuids).First();

                    //If the characteristic supports Notify then tell it to notify us.
                    try
                    {
                        if (characteristics.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                        {
                            characteristics.ValueChanged += characteristics_ValueChanged;
                            await characteristics.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);
                        }
                    }
                    catch { }

                    //Read
                    if (characteristics.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Read))
                    {
                        var result = await characteristics.ReadValueAsync(BluetoothCacheMode.Uncached);

                        if (result.Status == GattCommunicationStatus.Success)
                        {
                            byte[] forceData = new byte[result.Value.Length];
                            DataReader.FromBuffer(result.Value).ReadBytes(forceData);
                            return forceData;
                        }
                        else
                        {
                            await new MessageDialog(result.Status.ToString()).ShowAsync();
                        }
                    }
                }
                else 
                {
                    await new MessageDialog("Access to the device has been denied =(").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }</pre>
</div>
<p>&nbsp;</p>
<p>You can simply call the method like this:</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:8f58217a-f6d0-4414-a7eb-8ca40f917034" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: text;">BatteryLevel = Convert.ToInt32((await GetValue(GattCharacteristicUuids.BatteryLevel))[0]);</pre>
</div>
<p>&nbsp;</p>
<p>You also need a callback method that can handle the notifications.</p>
<div id="scid:f32c3428-b7e9-4f15-a8ea-c502c7ff2e88:be838c71-2013-4adc-b1fb-1f48c16beafe" class="wlWriterEditableSmartContent" style="float: none; margin: 0px; display: inline; padding: 0px;">
<pre class="brush: c#;">  void characteristics_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data = new byte[args.CharacteristicValue.Length];
            Windows.Storage.Streams.DataReader.FromBuffer(args.CharacteristicValue).ReadBytes(data);

           //Update properties
            if (sender.Uuid == GattCharacteristicUuids.BatteryLevel)
            {
                BatteryLevel = Convert.ToInt32(data[0]);
            }
        }</pre>
</div>
<p>&nbsp;</p>
<p>Now your app can retrieve battery level from a Bluetooth LE device. How awesome is that?</p>
<p><a href="/PostImages/2014/06/BatteryDemo.zip">BatteryDemo.zip (289.18 kb)</a></p>
