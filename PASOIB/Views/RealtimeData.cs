using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PASOIB
{
	internal class RealtimeData
	{
		internal List<string> FileEventsList;
		private readonly ReaderWriterLock IOLock;
		private readonly int WriteTimeoutMs;

		public event EventAddedHandler onEventAdded;
		public delegate void EventAddedHandler(object sender, EventArgs e);

		public event EventRemovedHandler onEventRemoved;
		public delegate void EventRemovedHandler(object sender, EventArgs e);

		public RealtimeData()
		{
			FileEventsList = DataAccess.GetData();
			IOLock = new ReaderWriterLock();
			WriteTimeoutMs = 1550;
		}

		internal async void AddChangeEvent(string source, string whatKind)
		{
			string eventString = $"({DateTime.Now}) | File : {source} \t\t {whatKind}";
			AddEventToList(eventString);
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				await DataAccess.SetData(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}

		internal async void AddRenameEvent(string oldName, string newName)
		{
			string eventString = $"({DateTime.Now}) | File : {oldName} renamed to\t {newName}";
			AddEventToList(eventString);
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				await DataAccess.SetData(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}

		internal async void AddSystemEvent(params string[] arguments)
		{
			string eventString = $"({DateTime.Now}) | {string.Join(" : ", arguments)}";
			AddEventToList(eventString);
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				await DataAccess.SetData(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}

		private void AddEventToList(string eventString)
		{
			FileEventsList.Add(eventString);
			onEventAdded(this, new EventArgs());
		}

		internal void PrintData()
		{
			Document document = CreateDocument();
			document.UseCmykColor = true;
			const bool unicode = true;

			PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode)
			{
				Document = document
			};

			pdfRenderer.RenderDocument();

			string filename = DataAccess.GetTargetFileByDialog(true);
			if (filename == null)
			{
				filename = DataAccess.DataFileReportDesktopPath;
			}
			pdfRenderer.PdfDocument.Save(filename);
			Process.Start(filename);
		}

		internal void ClearData()
		{
			onEventRemoved(this, new EventArgs());
			FileEventsList.Clear();
			DataAccess.DeleteFile(DataAccess.DataFileDefaultPath);
		}

		private Document CreateDocument()
		{
			Document document = new Document();
			Section section = document.AddSection();
			Paragraph paragraph = section.AddParagraph();

			paragraph.Format.Font.Color = Color.FromCmyk(100, 30, 20, 50);
			string text = DataAccess.GetDataString();
			paragraph.AddFormattedText(text, TextFormat.NotBold);

			return document;
		}
	}
}
