using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	public partial class MainActivity : Form
	{
		private USBChecker USBChecker;
		private bool _isAuthenticated;
		private bool IsAuthenticated
		{
			get => _isAuthenticated;
			set
			{
				_isAuthenticated = value;
				visualLock.ChangeState((VisualLock._State)(IsAuthenticated ? 1 : 0));
				UpdateTabControlState();
			}
		}

		public MainActivity()
		{
			InitializeComponent();
		}

		private void MainActivity_Load(object sender, EventArgs e)
		{
			USBChecker = new USBChecker();
			USBChecker.onUSBDeviceInserted += USBChecker_onUSBDeviceInserted;
			USBChecker.onUSBDeviceRemoved += USBChecker_onUSBDeviceRemoved;
			IsAuthenticated = false;
			ShowConnectedDevices();
		}

		private void USBChecker_onUSBDeviceInserted(USBChecker usbChecker, EventArgs eventInsertedArgs)
		{
			ShowConnectedDevices();
		}

		private void USBChecker_onUSBDeviceRemoved(USBChecker usbChecker, EventArgs eventRemovedArgs)
		{
			ShowConnectedDevices();
		}

		private void UpdateTabControlState()
		{
			((Control)tabAuthentication).Enabled = !IsAuthenticated;
			((Control)tabFilesSelection).Enabled = IsAuthenticated;
			((Control)tabRealtimeData).Enabled = IsAuthenticated;
			((Control)tabReports).Enabled = IsAuthenticated;
		}

		private void ShowConnectedDevices()
		{
			if (dataGridUSBDevices.InvokeRequired)
			{
				dataGridUSBDevices.Invoke(new Action(() =>
				{
					dataGridUSBDevices.Rows.Clear();
					USBChecker.GetUSBDevicesInfo(true).ForEach(usbDeviceInfo =>
					{
						var properties = typeof(USBDeviceInfo).GetProperties();
						dataGridUSBDevices.Rows.Add(properties.Select(property => property.GetValue(usbDeviceInfo)).ToArray());
					});
				}));
			}
			else
			{
				dataGridUSBDevices.Rows.Clear();
				USBChecker.GetUSBDevicesInfo(true).ForEach(usbDeviceInfo =>
				{
					var properties = typeof(USBDeviceInfo).GetProperties();
					dataGridUSBDevices.Rows.Add(properties.Select(property => property.GetValue(usbDeviceInfo)).ToArray());
				});
			}
		}

		private void buttonSelect_Click(object sender, EventArgs e)
		{
			IsAuthenticated = !IsAuthenticated;
			ShowConnectedDevices();
		}
	}
}
