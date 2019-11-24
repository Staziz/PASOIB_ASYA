using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace PASOIB_ASYA
{
	class USBChecker
	{
		private List<USBDeviceInfo> usbDevices;

		public event USBDeviceInsertedHandler onUSBDeviceInserted;
		public EventArgs eventInsertedArgs = null;
		public delegate void USBDeviceInsertedHandler(USBChecker usbChecker, EventArgs eventInsertedArgs);

		public event USBDeviceRemovedHandler onUSBDeviceRemoved;
		public EventArgs eventRemovedArgs = null;
		public delegate void USBDeviceRemovedHandler(USBChecker usbChecker, EventArgs eventRemovedArgs);

		private readonly ManagementEventWatcher ubsInsetrionWatcher = new ManagementEventWatcher();
		private readonly WqlEventQuery ubsInsetrionQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");

		private readonly ManagementEventWatcher ubsRemovalWatcher = new ManagementEventWatcher();
		private readonly WqlEventQuery ubsRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");

		public USBChecker()
		{
			usbDevices = GetUSBDevices();

			ubsInsetrionWatcher.EventArrived += new EventArrivedEventHandler(NativeUSBDeviceInsertedHandler);
			ubsInsetrionWatcher.Query = ubsInsetrionQuery;
			ubsInsetrionWatcher.Start();

			ubsRemovalWatcher.EventArrived += new EventArrivedEventHandler(NativeUSBDeviceRemovedHandler);
			ubsRemovalWatcher.Query = ubsRemovalQuery;
			ubsRemovalWatcher.Start();
		}

		private List<USBDeviceInfo> GetUSBDevices()
		{
			List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

			ManagementObjectCollection collection;
			using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
				collection = searcher.Get();

			foreach (var device in collection)
			{
				devices.Add(new USBDeviceInfo(
				device["DeviceID"].ToString(),
				device["PNPDeviceID"].ToString(),
				device["Name"].ToString(),
				device["Description"].ToString()
				));
			}

			collection.Dispose();
			return devices;
		}

		public List<string> GetUSBDevicesInfoList(bool refresh = false)
		{
			if (refresh)
			{
				usbDevices = GetUSBDevices();
			}

			var result = new List<string>();
			foreach (var usbDevice in usbDevices)
			{
				var usbDeviceInfo = $"Device ID: {usbDevice.DeviceID}, " +
					$"PNP Device ID: {usbDevice.PnpDeviceID}, " +
					$"Name: {usbDevice.Name}" +
					$"Description: {usbDevice.Description}";
				result.Add(usbDeviceInfo);
			}
			return result;
		}

		public List<USBDeviceInfo> GetUSBDevicesInfo(bool refresh = false)
		{
			if (refresh)
			{
				usbDevices = GetUSBDevices();
			}

			return usbDevices;
		}

		private void NativeUSBDeviceInsertedHandler(object sender, EventArgs eventArgs)
		{
			usbDevices = GetUSBDevices();
			onUSBDeviceInserted(this, eventArgs);
		}

		private void NativeUSBDeviceRemovedHandler(object sender, EventArgs eventArgs)
		{
			usbDevices = GetUSBDevices();
			onUSBDeviceRemoved(this, eventArgs);
		}
	}
}
