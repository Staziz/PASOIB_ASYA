using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	internal class FilesSelection
	{
		internal List<ProtectedFileEntry> ProtectedFileEntries;

		public FilesSelection()
		{
			ProtectedFileEntries = new List<ProtectedFileEntry>();
			foreach (FileInfo fileInfo in new DirectoryInfo(Application.CommonAppDataPath)
				.EnumerateFiles($"*{Properties.Resources.ProtectedFileExtension}"))
			{
				ProtectedFileEntries.Add(DataAccess.ReadProtectedFileContent(fileInfo.FullName));
			}
		}

		public ProtectedFileEntry AddFile(FileInfo fileInfo)
		{
			ProtectedFileEntry protectedFile = new ProtectedFileEntry(fileInfo);
			ProtectedFileEntries.Add(protectedFile);
			DataAccess.WriteProtectedFileContent(protectedFile);
			return ProtectedFileEntries.Last();
		}

	}
}
