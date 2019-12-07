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
			if (GetProtectedFileByName(fileInfo.Name) != null)
			{
				MessageBox.Show(
					"This file has been already added",
					"Warning",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
					);
				return null;
			}
			ProtectedFileEntry protectedFile = new ProtectedFileEntry(fileInfo);
			ProtectedFileEntries.Add(protectedFile);
			DataAccess.WriteProtectedFileContent(protectedFile);
			return ProtectedFileEntries.Last();
		}

		public void RestoreFile(string fileName)
		{
			ProtectedFileEntry targetProtectedFile = GetProtectedFileByName(fileName);
			try
			{
				targetProtectedFile.RestoreContent();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, e.Source);
			}
		}

		public void DeleteFile(string fileName)
		{
			ProtectedFileEntry targetProtectedFile = GetProtectedFileByName(fileName);
			targetProtectedFile.Delete();
			MessageBox.Show(
					$"The file {targetProtectedFile.FullPath} is deleting and\n" +
					$"will NOT be tracked anymore",
					"Warning",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
					);
			ProtectedFileEntries.Remove(targetProtectedFile);
		}

		private ProtectedFileEntry GetProtectedFileByName(string fileName)
		{
			try
			{
				return ProtectedFileEntries.First(protectedFile => protectedFile.Name == fileName);
			}
			catch (Exception)
			{
				return null;
			}
		}

	}
}
