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

		public ProtectedFileEntry(FileInfo targetFileInfo)
		{
			Name = targetFileInfo.Name;
			TargetDirectory = targetFileInfo.DirectoryName;
			Attributes = targetFileInfo.Attributes;
			CreationTime = targetFileInfo.CreationTime;
			Size = targetFileInfo.Length;
			FileContent = DataAccess.GetFileContent(targetFileInfo);
			MD5Hash = Security.GetMd5Hash(FileContent);
		}
	}
}
