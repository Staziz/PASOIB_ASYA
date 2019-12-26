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

		public RealtimeData()
		{
			FileEventsList = DataAccess.GetData();
			IOLock = new ReaderWriterLock();
			WriteTimeoutMs = 1550;
		}

		internal async void AddChangeEvent(string source, string whatKind)
		{
			string eventString = $"({DateTime.Now}) | File : {source} \t\t {whatKind}";
			FileEventsList.Add(eventString);
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
			FileEventsList.Add(eventString);
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
			FileEventsList.Add(eventString);
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
