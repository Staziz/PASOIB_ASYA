using System;
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
		private RealtimeData RealtimeData;
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
			USBChecker.onUSBDeviceInserted += USBChecker_onUSBDeviceInserted;
			USBChecker.onUSBDeviceRemoved += USBChecker_onUSBDeviceRemoved;

			Authentication = new Authentication();

			FilesSelection = new FilesSelection();
			FilesSelection.onProtectedFileChanged += FilesSelection_onProtectedFileChanged;
			FilesSelection.onProtectedFileRenamed += FilesSelection_onProtectedFileRenamed;

			RealtimeData = new RealtimeData();

			IsAuthenticated = false;
		}

		private void FilesSelection_onProtectedFileChanged(ProtectedFileEntry protectedFile, FileSystemEventArgs eventArgs)
		{
			RealtimeData.AddChangeEvent(eventArgs.FullPath, eventArgs.ChangeType.ToString());
			UpdateEventLog();
		}

		private void FilesSelection_onProtectedFileRenamed(ProtectedFileEntry protectedFile, RenamedEventArgs eventArgs)
		{
			RealtimeData.AddRenameEvent(eventArgs.OldFullPath, eventArgs.FullPath);
			UpdateEventLog();
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
			ShowConnectedDevices();
			((Control)tabFilesSelection).Enabled = IsAuthenticated;
			UpdateProtectingFiles();
			((Control)tabRealtimeData).Enabled = IsAuthenticated;
			UpdateEventLog();
			((Control)tabReports).Enabled = IsAuthenticated;
		}

		private void ShowConnectedDevices()
		{
			bool isAuthenticated = false;
			string currentId = null;
			string masterId = DataAccess.GetIdentificator();
			if (USBDevicesDataGrid.InvokeRequired)
			{
				USBDevicesDataGrid.Invoke(new Action(() =>
				{
					USBDevicesDataGrid.Rows.Clear();
					USBChecker.GetUSBDevicesInfo(true).ForEach(usbDeviceInfo =>
					{
						System.Reflection.PropertyInfo[] properties = typeof(USBDeviceInfo).GetProperties();
						USBDevicesDataGrid.Rows.Add(properties.Select(property => property.GetValue(usbDeviceInfo)).ToArray());
						currentId = USBDevicesDataGrid.Rows[USBDevicesDataGrid.Rows.Count - 1].Cells[0].Value.ToString();
						Authentication.TryAuthentify(currentId, masterId);
						isAuthenticated = isAuthenticated ? isAuthenticated : Authentication.IsAuthenticated;
					});
					if (!isAuthenticated)
					{
						IsAuthenticated = false;
					}
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

		private void UpdateProtectingFiles()
		{
			ProctectingFilesDataGrid.Rows.Clear();
			if (IsAuthenticated)
			{
				FilesSelection.ProtectedFileEntries.ForEach(protectedFileEntry =>
				{
					ProctectingFilesDataGrid.Rows.Add(protectedFileEntry.Name, protectedFileEntry.CreationTime, protectedFileEntry.Size);
				});
			}
		}

		private void UpdateEventLog()
		{
			if (EventsListBox.InvokeRequired)
			{
				EventsListBox.Invoke(new Action(() =>
				{
					EventsListBox.Items.Clear();
					if (IsAuthenticated)
					{
						RealtimeData.FileEventsList.ForEach(eventString =>
						{
							EventsListBox.Items.Add(eventString);
						});
					}
				}));
			}
			else
			{
				EventsListBox.Items.Clear();
				if (IsAuthenticated)
				{
					RealtimeData.FileEventsList.ForEach(eventString =>
					{
						EventsListBox.Items.Add(eventString);
					});
				}
			}
		}

		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			try
			{
				string currentId = USBDevicesDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				string masterId = DataAccess.GetIdentificator();
				Authentication.TryAuthentify(currentId, masterId, true);
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
			UpdateProtectingFiles();
		}

		private void RestoreFileButton_Click(object sender, EventArgs e)
		{
			try
			{
				RealtimeData.AddSystemEvent("Restore started");
				string fileName = ProctectingFilesDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				FilesSelection.RestoreFile(fileName);
				RealtimeData.AddSystemEvent("Restore completed");
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

		private void DeleteFileButton_Click(object sender, EventArgs e)
		{
			try
			{
				string fileName = ProctectingFilesDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				FilesSelection.DeleteFile(fileName);
				UpdateProtectingFiles();
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
