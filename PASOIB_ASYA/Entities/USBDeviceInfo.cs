using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASOIB_ASYA
{
	class USBDeviceInfo
	{
		public string DeviceID { get; private set; }
		public string PnpDeviceID { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }

		public USBDeviceInfo(string deviceID, string pnpDeviceID, string name, string description)
		{
			DeviceID = deviceID;
			PnpDeviceID = pnpDeviceID;
			Name = name;
			Description = description;
		}
	}
}
