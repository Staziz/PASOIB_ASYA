using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASOIB_ASYA
{
	internal class FilesSelection
	{
		internal List<ProtectedFileEntry> ProtectedFileEntries;

		public FilesSelection()
		{
			ProtectedFileEntries = new List<ProtectedFileEntry>();
		}

		public ProtectedFileEntry AddFile(FileInfo fileInfo)
		{
			ProtectedFileEntries.Add(new ProtectedFileEntry(fileInfo));
			return ProtectedFileEntries.Last();
		}

	}
}
