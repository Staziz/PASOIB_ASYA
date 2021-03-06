﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASOIB_ASYA
{
	internal class USBDeviceInfo
	{
		public string DiskDrive { get; private set; }
		public string Name { get; private set; }
		public string DeviceID { get; private set; }
		public string Description { get; private set; }

		public readonly string USBControllerDeviceID;

		public USBDeviceInfo(string diskDrive, string name, string deviceID, string description)
		{
			DiskDrive = diskDrive;
			Name = name;
			DeviceID = deviceID;
			USBControllerDeviceID = null;
			Description = description;
		}
	}
}
