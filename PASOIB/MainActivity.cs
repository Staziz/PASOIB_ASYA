using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SystemTrayNotification;

namespace PASOIB
{
	public partial class MainActivity : Form
	{
		private USBChecker USBChecker;
		private Authentication Authentication;
		private FilesSelection FilesSelection;
		private RealtimeData RealtimeData;
		private SystemTrayNotifyIcon m_SysTrayNotify;
		private Icon[] iconArray;
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

			m_SysTrayNotify = new SystemTrayNotification.SystemTrayNotifyIcon(this, true);
			iconArray = new Icon[18];
			for (int i = 1; i <= iconArray.Length; i++)
			{
				try
				{
					iconArray[i - 1] = new Icon($@"../../Animation Icons/Default/icon{i}.ico");
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message, "Error",
						 MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			m_SysTrayNotify.LoadIcons(iconArray);
			m_SysTrayNotify.Animate(-1, 50);
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

			KeepFilesOnRunTimeRadioButton.Checked = !Properties.Settings.Default.KeepFilesAlways;
			KeepFilesAlwaysRadioButton.Checked = Properties.Settings.Default.KeepFilesAlways;
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
			if (KeepFilesOnRunTimeRadioButton.Checked)
			{
				if (IsAuthenticated)
				{
					FilesSelection.RestoreProtectingFiles();
				}
				else
				{
					FilesSelection.RemoveProtectingFiles();
				}
			}
			((Control)RealtimeDataTab).Enabled = IsAuthenticated;
			UpdateEventLog();
			if (IsAuthenticated)
			{
				EventsListBox.TopIndex = -1;
			}
			((Control)SettingsTab).Enabled = IsAuthenticated;
			tabControl.SelectTab(IsAuthenticated ? 2 : 0);
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
							EventsListBox.TopIndex = EventsListBox.Items.Add(eventString);
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
				bool isFirstTime = Authentication.TryAuthentify(currentId, masterId, true);
				if (!Authentication.IsAuthenticated)
				{
					ShowErrorMessageBox("This is an incorrect identifier");
					return;
				}
				DialogResult secondAuthenticationFactor = new SMSAuthenticator().ShowDialog();
				IsAuthenticated = Authentication.IsAuthenticated && (secondAuthenticationFactor == DialogResult.OK);
				if (!IsAuthenticated)
				{
					ShowErrorMessageBox("Your code is incorrect");
				}
			}
			catch
			{
				ShowErrorMessageBox("Please select one row to proceed");
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
				ShowErrorMessageBox("Please select one row to proceed");
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
				ShowErrorMessageBox("Please select one row to proceed");
			}
		}

		private void MainActivity_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (KeepFilesOnRunTimeRadioButton.Checked)
			{
				FilesSelection.RemoveProtectingFiles();
			}
			Properties.Settings.Default.Save();
		}

		private void PrintEventListButton_Click(object sender, EventArgs e)
		{
			RealtimeData.PrintData();
		}

		private void ClearEventListButton_Click(object sender, EventArgs e)
		{
			RealtimeData.ClearData();
			UpdateEventLog();
		}

		private void KeepFilesOnRunTimeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.KeepFilesAlways = !(sender as RadioButton).Checked;
			Properties.Settings.Default.Save();
		}

		private void ChangePhoneNumberButton_Click(object sender, EventArgs e)
		{
			DialogResult secondAuthenticationFactor = new SMSAuthenticator(true).ShowDialog();
			if (secondAuthenticationFactor == DialogResult.OK)
			{
				ShowSuccessMessageBox($"Phone number was successfully changed to +7{Properties.Settings.Default.PhoneNumber}");
			}
		}

		private void ShowMessageBox(string title, string message, MessageBoxButtons buttons = 0, MessageBoxIcon icon = 0)
		{
			MessageBox.Show(message, title, buttons, icon);
		}

		private void ShowSuccessMessageBox(string message)
		{
			MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ShowErrorMessageBox(string message)
		{
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
