using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB
{
	internal class ProtectedFileEntry
	{
		internal readonly string Key;
		internal readonly string InitializationVector;

		internal readonly string Name;
		internal readonly string TargetDirectory;
		internal string FullPath => Path.Combine(TargetDirectory, Name);

		internal readonly FileAttributes Attributes;
		internal readonly DateTime CreationTime;
		internal readonly DateTime LastWriteTime;
		internal readonly long Size;
		internal string MD5Hash { get; private set; }

		internal string FileContent { get; private set; }

		public event FileChanged onFileChanged;
		public delegate void FileChanged(ProtectedFileEntry protectedFile, FileSystemEventArgs eventArgs);

		public event FileRenamed onFileRenamed;
		public delegate void FileRenamed(ProtectedFileEntry protectedFile, RenamedEventArgs eventArgs);

		private FileSystemWatcher Watcher;

		public ProtectedFileEntry(FileInfo targetFileInfo)
		{
			Name = targetFileInfo.Name;
			TargetDirectory = targetFileInfo.DirectoryName;
			Attributes = targetFileInfo.Attributes;
			CreationTime = targetFileInfo.CreationTime;
			LastWriteTime = targetFileInfo.LastWriteTime;
			Size = targetFileInfo.Length;

			FileContent = DataAccess.GetFileContent(targetFileInfo);
			MD5Hash = Security.GetMd5Hash(FileContent);

			Key = Security.GetKey(keyInit: MD5Hash);
			InitializationVector = Security.GetInitializationVector();

			FileContent = Security.EncryptFileAES(FileContent, Key, InitializationVector);

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
			DateTime LastWriteTime,
			long Length,
			string FileContent,
			string MD5Hash,
			string InitializationVector)
		{
			this.Name = Name;
			this.TargetDirectory = DirectoryName;
			this.Attributes = Attributes;
			this.CreationTime = CreationTime;
			this.LastWriteTime = LastWriteTime;
			this.Size = Length;

			this.Key = Security.GetKey(keyInit: MD5Hash);
			this.InitializationVector = InitializationVector;

			this.FileContent = FileContent;
			this.MD5Hash = Security.GetMd5Hash(
					Security.DecryptFileAES(
						this.FileContent,
						this.Key,
						this.InitializationVector)) == MD5Hash 
				? MD5Hash 
				: throw new ProtectedFileHashInconsistence(Name);

			Watcher = new FileSystemWatcher(TargetDirectory)
			{
				Filter = Name,
				NotifyFilter = NotifyFilters.LastAccess
				| NotifyFilters.LastWrite
				| NotifyFilters.FileName
				| NotifyFilters.Size
			};
			Watcher.Changed += OnChanged;
			Watcher.Created += OnChanged;
			Watcher.Deleted += OnChanged;
			Watcher.Renamed += OnRenamed;
			Watcher.EnableRaisingEvents = true;
		}

		public void RestoreContent()
		{
			string restoredContent = Security.DecryptFileAES(FileContent, Key, InitializationVector);
			DataAccess.SetFileContent(FullPath, restoredContent, Attributes, CreationTime, LastWriteTime);

			restoredContent = DataAccess.GetFileContent(FullPath);
			if (Security.GetMd5Hash(restoredContent) != MD5Hash)
			{
				throw new ProtectedFileHashInconsistence(Name);
			}
		}

		public void Delete()
		{
			Watcher.Dispose();
			DataAccess.DeleteFile(Path.Combine(Application.CommonAppDataPath, Name + Properties.Resources.ProtectedFileExtension));
		}
		
		public void UpdateRemoveContent()
		{
			if (File.Exists(FullPath))
			{
				FileContent = DataAccess.GetFileContent(FullPath);
				MD5Hash = Security.GetMd5Hash(FileContent);
				FileContent = Security.EncryptFileAES(FileContent, Key, InitializationVector);
				DataAccess.DeleteFile(FullPath);
			}
		}

		private void OnChanged(object source, FileSystemEventArgs e)
		{
			onFileChanged(this, e);
		}

		private void OnRenamed(object source, RenamedEventArgs e)
		{
			onFileRenamed(this, e);
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
