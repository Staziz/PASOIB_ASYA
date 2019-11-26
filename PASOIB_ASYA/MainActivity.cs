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

		private void MainActivity_Shown(object sender, EventArgs e)
		{
			string message = "";
			string capture = "";
			if (DataAccess.GetIdentificator() == null)
			{
				message = "Please select the USB device you want to set as a key for the program";
				capture = "Preparing for work...";
			}
			else
			{
				message = "Please select the USB device you want to use to enter the program";
				capture = "Preparing for work...";
			}

			DialogResult dialogResult = MessageBox.Show(
					message,
					capture,
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Asterisk,
					MessageBoxDefaultButton.Button1);
			if (dialogResult == DialogResult.Cancel)
			{
				Application.Exit();
			}
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
						System.Reflection.PropertyInfo[] properties = typeof(USBDeviceInfo).GetProperties();
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

		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			try
			{
				string currentId = dataGridUSBDevices.SelectedRows[0].Cells[0].Value.ToString();
				string masterId = DataAccess.GetIdentificator();
				if (masterId == null)
				{
					DataAccess.SetIdentificator(currentId);
					IsAuthenticated = true;
				}
				else
				{
					if (Hasher.IsStringEqualsHash(currentId, masterId))
					{
						IsAuthenticated = true;
					}
					else
					{
						MessageBox.Show(
							"This is an incorrect identifier",
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
			}
			catch
			{
				MessageBox.Show(
					"Please select one row to proceed",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			
		}
	}
}
