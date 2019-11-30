using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PASOIB_ASYA
{
	internal class ProtectedFileEntry
	{
		private readonly string Key;
		private readonly string InitializationVector;

		internal readonly string Name;
		private readonly string TargetDirectory;
		private readonly FileAttributes Attributes;
		internal readonly DateTime CreationTime;
		internal readonly long Size;
		private readonly string MD5Hash;

		private readonly string FileContent;

		private FileSystemWatcher Watcher;

		public ProtectedFileEntry(FileInfo targetFileInfo)
		{
			Name = targetFileInfo.Name;
			TargetDirectory = targetFileInfo.DirectoryName;
			Attributes = targetFileInfo.Attributes;
			CreationTime = targetFileInfo.CreationTime;
			Size = targetFileInfo.Length;
			FileContent = DataAccess.GetFileContent(targetFileInfo);
			MD5Hash = Security.GetMd5Hash(FileContent);

			Watcher = new FileSystemWatcher(TargetDirectory)
			{
				Filter = Name,
				NotifyFilter = NotifyFilters.LastAccess
				| NotifyFilters.LastWrite
				| NotifyFilters.FileName
				| NotifyFilters.DirectoryName
				| NotifyFilters.Size
			};
			Watcher.Changed += OnChanged;
			Watcher.Created += OnChanged;
			Watcher.Deleted += OnChanged;
			Watcher.Renamed += OnRenamed;
			Watcher.EnableRaisingEvents = true;
		}

		private static void OnChanged(object source, FileSystemEventArgs e)
		{
			System.Windows.Forms.MessageBox.Show($"File: {e.FullPath} {e.ChangeType}");
			// TODO: Implement writing events to logs
		}

		private static void OnRenamed(object source, RenamedEventArgs e)
		{
			System.Windows.Forms.MessageBox.Show($"File: {e.OldFullPath} renamed to {e.FullPath}");
			// TODO: Implement writing events to logs
		}
	}
}
