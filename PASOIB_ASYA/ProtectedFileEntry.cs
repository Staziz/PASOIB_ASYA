using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	internal class ProtectedFileEntry
	{
		internal readonly string Key;
		internal readonly string InitializationVector;

		internal readonly string Name;
		internal readonly string TargetDirectory;
		internal readonly FileAttributes Attributes;
		internal readonly DateTime CreationTime;
		internal readonly long Size;
		internal readonly string MD5Hash;

		internal readonly string FileContent;

		private FileSystemWatcher Watcher;

		public ProtectedFileEntry(FileInfo targetFileInfo)
		{
			Name = targetFileInfo.Name;
			TargetDirectory = targetFileInfo.DirectoryName;
			Attributes = targetFileInfo.Attributes;
			CreationTime = targetFileInfo.CreationTime;
			Size = targetFileInfo.Length;

			Key = Security.GetKey();
			InitializationVector = Security.GetInitializationVector();

			FileContent = Security.EncryptFileAES(DataAccess.GetFileContent(targetFileInfo), Key, InitializationVector);
			MD5Hash = Security.GetMd5Hash(FileContent);
			//DataAccess.SetFileContent(Path.Combine(Application.CommonAppDataPath, "written.txt"), FileContent);
			//FileContent = DataAccess.GetFileContent(targetFileInfo);


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

		public ProtectedFileEntry(
			string Name, 
			string DirectoryName, 
			FileAttributes Attributes, 
			DateTime CreationTime, 
			long Length,
			string FileContent,
			string MD5Hash,
			string InitializationVector)
		{
			this.Name = Name;
			this.TargetDirectory = DirectoryName;
			this.Attributes = Attributes;
			this.CreationTime = CreationTime;
			this.Size = Length;
			this.FileContent = FileContent; // TODO Write to file and compare
			//DataAccess.SetFileContent(Path.Combine(Application.CommonAppDataPath, "read.txt"), FileContent);
			this.Key = DataAccess.GetIdentificator();
			this.InitializationVector = InitializationVector;
			//Security.DecryptFileAES(FileContent, this.Key, this.InitializationVector)
			this.MD5Hash = Security.GetMd5Hash(FileContent) == MD5Hash 
				? MD5Hash 
				: throw new ProtectedFileHashInconsistence(Name);


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

	[System.Serializable]
	public class ProtectedFileHashInconsistence : Exception
	{
		public ProtectedFileHashInconsistence() { }
		public ProtectedFileHashInconsistence(string message) : base(message) { }
		public ProtectedFileHashInconsistence(string message, Exception inner) : base(message, inner) { }
		protected ProtectedFileHashInconsistence(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}  
}
