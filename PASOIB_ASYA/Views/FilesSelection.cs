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

		public event ProtectedFileChanged onProtectedFileChanged;
		public delegate void ProtectedFileChanged(ProtectedFileEntry protectedFile, FileSystemEventArgs eventArgs);

		public event ProtectedFileRenamed onProtectedFileRenamed;
		public delegate void ProtectedFileRenamed(ProtectedFileEntry protectedFile, RenamedEventArgs eventArgs);

		public FilesSelection()
		{
			ProtectedFileEntries = new List<ProtectedFileEntry>();
			foreach (FileInfo fileInfo in new DirectoryInfo(Application.CommonAppDataPath)
				.EnumerateFiles($"*{Properties.Resources.ProtectedFileExtension}"))
			{
				ProtectedFileEntry protectedFile = DataAccess.ReadProtectedFileContent(fileInfo.FullName);
				protectedFile.onFileChanged += ProtectedFile_onFileChanged;
				protectedFile.onFileRenamed += ProtectedFile_onFileRenamed;
				ProtectedFileEntries.Add(protectedFile);
			}
		}

		private void ProtectedFile_onFileChanged(ProtectedFileEntry protectedFile, FileSystemEventArgs eventArgs)
		{
			onProtectedFileChanged(protectedFile, eventArgs);
		}

		private void ProtectedFile_onFileRenamed(ProtectedFileEntry protectedFile, RenamedEventArgs eventArgs)
		{
			onProtectedFileRenamed(protectedFile, eventArgs);
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
			protectedFile.onFileChanged += ProtectedFile_onFileChanged;
			protectedFile.onFileRenamed += ProtectedFile_onFileRenamed;
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


		public void RemoveProtectingFiles()
		{
			foreach (ProtectedFileEntry protectedFile in ProtectedFileEntries)
			{
				protectedFile.UpdateRemoveContent();
			}
		}

		public void RestoreProtectingFiles()
		{
			foreach (ProtectedFileEntry protectedFile in ProtectedFileEntries)
			{
				protectedFile.RestoreContent();
			}
		}

		public string GetFullPathByFileName(string fileName)
		{
			ProtectedFileEntry targetFile = GetProtectedFileByName(fileName);
			return targetFile == null ? "" : targetFile.FullPath;
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
