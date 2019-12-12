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
	}
}
