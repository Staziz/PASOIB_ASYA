﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	public partial class MainActivity : Form
	{
		private USBChecker USBChecker;
		private Authentication Authentication;
		private FilesSelection FilesSelection;
		private bool IsAuthenticated
		{
			get => Authentication.IsAuthenticated;
			set
			{
				Authentication.IsAuthenticated = value;
				VisualLock.ChangeState((VisualLock._State)(IsAuthenticated ? 1 : 0));
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
			Authentication = new Authentication();

			FilesSelection = new FilesSelection();

			USBChecker.onUSBDeviceInserted += USBChecker_onUSBDeviceInserted;
			USBChecker.onUSBDeviceRemoved += USBChecker_onUSBDeviceRemoved;
			IsAuthenticated = false;
			ShowConnectedDevices();
		}

		private void MainActivity_Shown(object sender, EventArgs e)
		{
			Authentication.ShowGreeting();
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
			// TODO: Add tabs initialization/disposing here
			((Control)tabAuthentication).Enabled = !IsAuthenticated;
			((Control)tabFilesSelection).Enabled = IsAuthenticated;
			UpdateProtectingFiles(IsAuthenticated);
			((Control)tabRealtimeData).Enabled = IsAuthenticated;
			((Control)tabReports).Enabled = IsAuthenticated;
		}

		private void ShowConnectedDevices()
		{
			if (USBDevicesDataGrid.InvokeRequired)
			{
				USBDevicesDataGrid.Invoke(new Action(() =>
				{
					USBDevicesDataGrid.Rows.Clear();
					USBChecker.GetUSBDevicesInfo(true).ForEach(usbDeviceInfo =>
					{
						System.Reflection.PropertyInfo[] properties = typeof(USBDeviceInfo).GetProperties();
						USBDevicesDataGrid.Rows.Add(properties.Select(property => property.GetValue(usbDeviceInfo)).ToArray());
					});
				}));
			}
			else
			{
				USBDevicesDataGrid.Rows.Clear();
				USBChecker.GetUSBDevicesInfo(true).ForEach(usbDeviceInfo =>
				{
					System.Reflection.PropertyInfo[] properties = typeof(USBDeviceInfo).GetProperties();
					USBDevicesDataGrid.Rows.Add(properties.Select(property => property.GetValue(usbDeviceInfo)).ToArray());
				});
			}
		}

		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			try
			{
				string currentId = USBDevicesDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				string masterId = DataAccess.GetIdentificator();
				Authentication.TryAuthentify(currentId, masterId);
				IsAuthenticated = Authentication.IsAuthenticated;
				if (!IsAuthenticated)
				{
					MessageBox.Show(
						"This is an incorrect identifier",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
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

		private void AddFileButton_Click(object sender, EventArgs e)
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					FilesSelection.AddFile(new FileInfo(openFileDialog.FileName));
				}
			}
			UpdateProtectingFiles(true);
		}

		private void UpdateProtectingFiles(bool isAuthenticated = false)
		{
			ProctectingFilesDataGrid.Rows.Clear();
			if (isAuthenticated)
			{
				FilesSelection.ProtectedFileEntries.ForEach(protectedFileEntry =>
				{
					ProctectingFilesDataGrid.Rows.Add(protectedFileEntry.Name, protectedFileEntry.CreationTime, protectedFileEntry.Size);
				});
			}
		}
	}
}
