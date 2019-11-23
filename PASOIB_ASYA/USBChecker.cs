﻿using System;
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

		public USBChecker()
		{
			usbDevices = GetUSBDevices();
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

		public List<string> GetUSBDevicesInfo(bool refresh = false)
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
	}
}
