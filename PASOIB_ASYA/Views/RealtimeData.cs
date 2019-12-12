using System;
using System.Collections.Generic;
using System.Threading;

namespace PASOIB_ASYA
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
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				string eventString = $"({DateTime.Now}) | File : {source} \t\t {whatKind}";
				await DataAccess.SetData(eventString);
				FileEventsList.Add(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}

		internal async void AddRenameEvent(string oldName, string newName)
		{
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				string eventString = $"({DateTime.Now}) | File : {oldName} renamed to\t {newName}";
				await DataAccess.SetData(eventString);
				FileEventsList.Add(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}

		internal async void AddSystemEvent(params string[] arguments)
		{
			try
			{
				IOLock.AcquireWriterLock(WriteTimeoutMs);
				string eventString = $"({DateTime.Now}) | {string.Join(" : ", arguments)}";
				await DataAccess.SetData(eventString);
				FileEventsList.Add(eventString);
			}
			finally
			{
				IOLock.ReleaseLock();
			}
		}
	}
}
