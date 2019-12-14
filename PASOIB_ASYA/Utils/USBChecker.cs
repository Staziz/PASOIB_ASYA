using System;
using System.Collections.Generic;
using System.IO;
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

		private readonly ManagementEventWatcher usbInsetrionWatcher = new ManagementEventWatcher();
		private readonly WqlEventQuery usbInsetrionQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
		private readonly WqlEventQuery usbDeviceInsetrionQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");

		private readonly ManagementEventWatcher usbRemovalWatcher = new ManagementEventWatcher();
		private readonly WqlEventQuery usbRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 3");
		private readonly WqlEventQuery usbDeviceRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");

		public USBChecker()
		{
			usbDevices = GetUSBDevices();

			usbInsetrionWatcher.EventArrived += new EventArrivedEventHandler(NativeUSBDeviceInsertedHandler);
			usbInsetrionWatcher.Query = usbInsetrionQuery;
			usbInsetrionWatcher.Start();

			usbRemovalWatcher.EventArrived += new EventArrivedEventHandler(NativeUSBDeviceRemovedHandler);
			usbRemovalWatcher.Query = usbRemovalQuery;
			usbRemovalWatcher.Start();
		}

		private List<USBDeviceInfo> GetUSBDevices()
		{
			List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

			using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
			{
				using (ManagementObjectCollection collection = searcher.Get())
				{
					foreach (var device in collection)
					{
						devices.Add(new USBDeviceInfo(
						device["DeviceID"].ToString(),
						device["PNPDeviceID"].ToString(),
						device["Name"].ToString(),
						device["Description"].ToString()
						));
					}
				}
			}
			return devices;
		}

		public string GetUSBDevicesFullPropertySet()
		{
			string result = "";

			ManagementClass processClass = new ManagementClass("Win32_USBHub");
			processClass.Options.UseAmendedQualifiers = true;
			PropertyDataCollection properties = processClass.Properties;

			using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
			{
				using (ManagementObjectCollection collection = searcher.Get())
				{
					foreach (var device in collection)
					{
						foreach (PropertyData property in properties)
						{
							result += $"{property.Name}: {(device[property.Name] == null ? " --- " : device[property.Name]).ToString()}\n";
						}
					}
				}
			}
			return result;
		}

		public string GetFriendlyNamedUSBDevices()
		{
			string result = "";
			foreach (DriveInfo drive in DriveInfo.GetDrives())
			{
				if (drive.DriveType == DriveType.Removable)
				{
					result += $"({drive.Name.Replace("\\", "")}) {drive.VolumeLabel}\n";
				}
			}
			return result;
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
			onUSBDeviceInserted(this, eventArgs); // To make mouse adapter, printer, etc. work set query to usbDeviceInsetrionQuery
		}

		private void NativeUSBDeviceRemovedHandler(object sender, EventArgs eventArgs)
		{
			usbDevices = GetUSBDevices();
			onUSBDeviceRemoved(this, eventArgs); // To make mouse adapter, printer, etc. work set query to usbDeviceInsetrionQuery
		}
	}
}
