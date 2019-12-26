using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PASOIB
{
	public partial class MainActivity : Form
	{
		private USBChecker USBChecker;
		private Authentication Authentication;
		private FilesSelection FilesSelection;
		private RealtimeData RealtimeData;
		private Settings Settings;
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

			Settings = new Settings();

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
			((Control)AuthenticationTab).Enabled = !IsAuthenticated;
			ShowConnectedDevices();
			((Control)FilesSelectionTab).Enabled = IsAuthenticated;
			UpdateProtectingFilesList();
			if (IsAuthenticated)
			{
				FilesSelection.RestoreProtectingFiles();
			}
			else
			{
				FilesSelection.RemoveProtectingFiles();
			}
			((Control)RealtimeDataTab).Enabled = IsAuthenticated;
			UpdateEventLog();
			((Control)SettingsTab).Enabled = IsAuthenticated;
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
						currentId = USBDevicesDataGrid.Rows[USBDevicesDataGrid.Rows.Count - 1].Cells[2].Value.ToString();
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

		private void UpdateProtectingFilesList()
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
						List<string> tempFileEventsList = RealtimeData.FileEventsList.ToList();
						tempFileEventsList.ForEach(eventString =>
						{
							EventsListBox.Items.Add(eventString);
						});
						tempFileEventsList.Clear();
					}
				}));
			}
			else
			{
				EventsListBox.Items.Clear();
				if (IsAuthenticated)
				{
					List<string> tempFileEventsList = RealtimeData.FileEventsList.ToList();
					tempFileEventsList.ForEach(eventString =>
					{
						EventsListBox.Items.Add(eventString);
					});
					tempFileEventsList.Clear();
				}
			}
		}

		private void ButtonSelect_Click(object sender, EventArgs e)
		{
			try
			{
				string currentId = USBDevicesDataGrid.SelectedRows[0].Cells[2].Value.ToString();
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
			string targerFileName = DataAccess.GetTargetFileByDialog();
			if (targerFileName == null)
			{
				return;
			}
			RealtimeData.AddSystemEvent("File is tracking now", targerFileName);
			FilesSelection.AddFile(new FileInfo(targerFileName));
			UpdateProtectingFilesList();
			UpdateEventLog();
		}

		private void RestoreFileButton_Click(object sender, EventArgs e)
		{
			try
			{
				string fileName = ProctectingFilesDataGrid.SelectedRows[0].Cells[0].Value.ToString();
				RealtimeData.AddSystemEvent("Restore started", fileName);
				FilesSelection.RestoreFile(fileName);
				RealtimeData.AddSystemEvent("Restore completed", fileName);
				UpdateEventLog();
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
				RealtimeData.AddSystemEvent("File is not tracking anymore", fileName);
				FilesSelection.DeleteFile(fileName);
				UpdateProtectingFilesList();
				UpdateEventLog();
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

		private void MainActivity_FormClosed(object sender, FormClosedEventArgs e)
		{
			FilesSelection.RemoveProtectingFiles();
		}

		private void PrintEventListButton_Click(object sender, EventArgs e)
		{
			RealtimeData.PrintData();
		}

	}
}
