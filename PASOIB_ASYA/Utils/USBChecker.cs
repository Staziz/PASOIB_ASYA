using System;
using System.Collections.Generic;
using System.IO;
using System.Management;

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

		struct IncompleteUSBEntity
		{
			public string DiskLetter;
			public string DeviceVendor;
			public string PNPDeviceID;
		}

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
			var result = new List<USBDeviceInfo>();
			foreach (var drive in new ManagementObjectSearcher("select * from Win32_DiskDrive where InterfaceType='USB'").Get())
			{
				var USBDeviceDraft = new IncompleteUSBEntity();
				foreach (var partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" 
					+ drive["DeviceID"]
					+ "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
				{
					foreach (var disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
						  + partition["DeviceID"]
						  + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
					{
						USBDeviceDraft.DiskLetter = disk["Name"].ToString().Trim();
					}
				}
				USBDeviceDraft.DeviceVendor = drive["Model"].ToString();
				USBDeviceDraft.PNPDeviceID = drive["PNPDeviceID"].ToString();
				result.Add(new USBDeviceInfo(
					USBDeviceDraft.DiskLetter,
					GetUSBDeviceFriendlyNameByDiskLetter(USBDeviceDraft.DiskLetter),
					USBDeviceDraft.PNPDeviceID,
					USBDeviceDraft.DeviceVendor
				));
			}
			return result;
		}

		private string GetUSBDeviceFriendlyNameByDiskLetter(string diskLetter)
		{
			foreach (DriveInfo drive in DriveInfo.GetDrives())
			{
				if (drive.Name.Replace("\\", "") == diskLetter)
				{
					return drive.VolumeLabel;
				}
			}
			return null;
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
