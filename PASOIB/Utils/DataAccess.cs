using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace PASOIB
{
	internal static class DataAccess
	{
		internal static string DesktopDefaultPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		internal static string DataFileDefaultPath => Path.Combine(Application.CommonAppDataPath, Properties.Resources.DataFile);

		internal static string DataFileReportDesktopPath => Path.Combine(DesktopDefaultPath, Properties.Resources.DataFileReport);

		internal static string GetProtectedFilePath(string fileName)
		{
			return Path.Combine(Application.CommonAppDataPath, fileName + Properties.Resources.ProtectedFileExtension);
		}

		internal static string GetIdentificator()
		{
			return Properties.Settings.Default.Identificator == "null" ? null : Properties.Settings.Default.Identificator;
		}

		internal static void SetIdentificator(string identificator)
		{
			Properties.Settings.Default.Identificator = Security.GetSHA512Hash(identificator);
			Properties.Settings.Default.Save();
		}

		internal static string GetFileContent(string fileName)
		{
			byte[] fileContent = File.ReadAllBytes(fileName);
			return Convert.ToBase64String(fileContent);
		}

		internal static string GetFileContent(FileInfo fileInfo)
		{
			byte[] fileContent = File.ReadAllBytes(fileInfo.FullName);
			return Convert.ToBase64String(fileContent);
		}

		internal static void SetFileContent(string fileName, string content)
		{
			byte[] fileContent = Convert.FromBase64String(content);
			File.WriteAllBytes(fileName, fileContent);
		}

		internal static void SetFileContent(string fileName, string content, FileAttributes attributes, DateTime creationTime, DateTime lastWriteTime)
		{
			if (File.Exists(fileName))
			{
				RemoveProtectingFileAttributes(fileName);
			}
			byte[] fileContent = Convert.FromBase64String(content);
			File.WriteAllBytes(fileName, fileContent);
			File.SetCreationTime(fileName, creationTime);
			File.SetLastWriteTime(fileName, lastWriteTime);
			File.SetAttributes(fileName, attributes);
		}

		internal static void DeleteFile(string fileName)
		{
			RemoveProtectingFileAttributes(fileName);
			File.Delete(fileName);
		}

		internal static void DeleteFile(FileInfo fileInfo)
		{
			RemoveProtectingFileAttributes(fileInfo.FullName);
			fileInfo.Delete();
		}

		internal static ProtectedFileEntry ReadProtectedFileContent(string name)
		{
			if (!name.EndsWith(Properties.Resources.ProtectedFileExtension))
			{
				name += Properties.Resources.ProtectedFileExtension;
			}
			using (StreamReader fileInput = new StreamReader(name))
			{
				string Name = fileInput.ReadLine();
				string DirectoryName = fileInput.ReadLine();
				FileAttributes Attributes = (FileAttributes)Enum.Parse(typeof(FileAttributes), fileInput.ReadLine());
				DateTime.TryParse(fileInput.ReadLine(), out DateTime CreationTime);
				DateTime.TryParse(fileInput.ReadLine(), out DateTime LastWriteTime);
				long.TryParse(fileInput.ReadLine(), out long Length);
				string MD5Hash = fileInput.ReadLine();
				string InitializationVector = fileInput.ReadLine();

				string FileContent = fileInput.ReadToEnd();
				return new ProtectedFileEntry(
					Name,
					DirectoryName,
					Attributes,
					CreationTime,
					LastWriteTime,
					Length,
					FileContent,
					MD5Hash,
					InitializationVector);
			}
		}

		internal static void WriteProtectedFileContent(ProtectedFileEntry protectedFile)
		{
			using (StreamWriter fileOutput = new StreamWriter(GetProtectedFilePath(protectedFile.Name)))
			{
				fileOutput.WriteLine(protectedFile.Name);
				fileOutput.WriteLine(protectedFile.TargetDirectory);
				fileOutput.WriteLine(protectedFile.Attributes);
				fileOutput.WriteLine(protectedFile.CreationTime);
				fileOutput.WriteLine(protectedFile.LastWriteTime);
				fileOutput.WriteLine(protectedFile.Size);
				fileOutput.WriteLine(protectedFile.SHA512Hash);
				fileOutput.WriteLine(protectedFile.InitializationVector);

				fileOutput.Write(protectedFile.FileContent);
			}
		}

		internal static async Task SetData(string data)
		{
			using (StreamWriter dataFile = new StreamWriter(DataFileDefaultPath, true))
			{
				await dataFile.WriteLineAsync(data);
			}
		}

		internal static List<string> GetData()
		{
			List<string> result = new List<string>();
			if(File.Exists(DataFileDefaultPath))
			{
				using (StreamReader dataFile = new StreamReader(DataFileDefaultPath))
				{
					while (!dataFile.EndOfStream)
					{
						result.Add(dataFile.ReadLine());
					}
				}
			}
			return result;
		}

		internal static string GetDataString()
		{
			string result = "";
			if (File.Exists(DataFileDefaultPath))
			{
				using (StreamReader dataFile = new StreamReader(DataFileDefaultPath))
				{
					while (!dataFile.EndOfStream)
					{
						result += $"{dataFile.ReadLine()}\n";
					}
				}
			}
			return result;
		}

		internal static string GetTargetFileByDialog(bool save = false)
		{
			Type type = save ? typeof(SaveFileDialog) : typeof(OpenFileDialog);
			using (var fileDialog = (FileDialog)type.GetConstructor(new Type[0]).Invoke(null))
			{
				fileDialog.InitialDirectory = DesktopDefaultPath;
				fileDialog.RestoreDirectory = true;
				fileDialog.AddExtension = true;
				fileDialog.DefaultExt = ".pdf";
				fileDialog.Filter = save ? "Pdf files|*.pdf|All files|*.*" : "All files|*.*|Pdf files|*.pdf";
				if (fileDialog.ShowDialog() == DialogResult.OK)
				{
					return fileDialog.FileName;
				}
				else
				{
					return null;
				}
			}
		}

		private static void RemoveFileAttributes(string fileName, FileAttributes attributes)
		{
			try
			{
				FileInfo file = new FileInfo(fileName);
				FileAttributes oldAttributes = File.GetAttributes(fileName);
				File.SetAttributes(fileName, oldAttributes & ~attributes);
			}
			catch
			{ }
		}

		private static void RemoveProtectingFileAttributes(string fileName)
		{
			RemoveFileAttributes(fileName,
					FileAttributes.ReadOnly
					| FileAttributes.Archive
					| FileAttributes.Compressed
					| FileAttributes.Hidden
					| FileAttributes.System);
		}
	}
}
