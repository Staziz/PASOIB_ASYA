using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PASOIB_ASYA
{
	internal class RealtimeData
	{
		internal List<string> FileEventsList;

		public RealtimeData()
		{
			FileEventsList = DataAccess.GetData();
		}

		internal void AddChangeEvent(string source, string whatKind)
		{
			string eventString = $"({DateTime.Now}) | File : {source} \t\t {whatKind}";
			DataAccess.SetData(eventString);
			FileEventsList.Add(eventString);
		}

		internal void AddRenameEvent(string oldName, string newName)
		{
			string eventString = $"({DateTime.Now}) | File : {oldName} renamed to\t {newName}";
			DataAccess.SetData(eventString);
			FileEventsList.Add(eventString);
		}

		internal void AddSystemEvent(params string[] arguments)
		{
			string eventString = $"({DateTime.Now}) | {string.Join(" : ", arguments)}";
			DataAccess.SetData(eventString);
			FileEventsList.Add(eventString);
		}
	}
}
