using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
			string targerFileName = DataAccess.GetDialogTargetFile();
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

			// Create a MigraDoc document
			Document document = CreateDocument();
			document.UseCmykColor = true;

			// ===== Unicode encoding and font program embedding in MigraDoc is demonstrated here =====

			// A flag indicating whether to create a Unicode PDF or a WinAnsi PDF file.
			// This setting applies to all fonts used in the PDF document.
			// This setting has no effect on the RTF renderer.
			const bool unicode = true;

			// An enum indicating whether to embed fonts or not.
			// This setting applies to all font programs used in the document.
			// This setting has no effect on the RTF renderer.
			// (The term 'font program' is used by Adobe for a file containing a font. Technically a 'font file'
			// is a collection of small programs and each program renders the glyph of a character when executed.
			// Using a font in PDFsharp may lead to the embedding of one or more font programms, because each outline
			// (regular, bold, italic, bold+italic, ...) has its own fontprogram)
			const PdfFontEmbedding embedding = PdfFontEmbedding.Always;

			// ========================================================================================

			// Create a renderer for the MigraDoc document.
#pragma warning disable CS0618 // Тип или член устарел
			PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
			{

				// Associate the MigraDoc document with a renderer
				Document = document
			};
#pragma warning restore CS0618 // Тип или член устарел

			// Layout and render document to PDF
			pdfRenderer.RenderDocument();

			// Save the document...
			string filename = @"C:\Users\Клесарев Станислав\Desktop\_AAA___TEST\HelloWorld.pdf";
			pdfRenderer.PdfDocument.Save(filename);
			// ...and start a viewer.
			Process.Start(filename);

		}

		static Document CreateDocument()
		{
			// Create a new MigraDoc document
			Document document = new Document();

			// Add a section to the document
			Section section = document.AddSection();

			// Add a paragraph to the section
			Paragraph paragraph = section.AddParagraph();

			paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);
			string text;
			using (var fileStream = new StreamReader(@"C:\ProgramData\PASOIB_ASYA\PASOIB_ASYA\1.0.0.0\data.txt"))
			{
				text = fileStream.ReadToEnd();
			}
			// Add some text to the paragraph
			paragraph.AddFormattedText(text, TextFormat.Bold);

			return document;
		}

	}
}
