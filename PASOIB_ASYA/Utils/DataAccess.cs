﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	internal static class DataAccess
	{
		internal static string GetIdentificator()
		{
			string keyFilePath = Path.Combine(Application.CommonAppDataPath, Properties.Resources.KeyFile);
			string identificator = "";
			try
			{
				using (StreamReader keyFile = new StreamReader(keyFilePath))
				{
					identificator = keyFile.ReadLine();
				}
			}
			catch (FileNotFoundException e)
			{
				identificator = null;
			}

			return identificator;
		}

		internal static void SetIdentificator(string identificator)
		{
			string keyFilePath = Path.Combine(Application.CommonAppDataPath, Properties.Resources.KeyFile);
			using (StreamWriter keyFile = File.Exists(keyFilePath) ? new StreamWriter(keyFilePath) : File.AppendText(keyFilePath))
			{
				keyFile.WriteLine(Security.GetMd5Hash(identificator));
				System.Windows.Forms.MessageBox.Show(
					"The key was successfully saved!",
					"Info",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
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
				RemoveFileAttributes(fileName, 
					FileAttributes.ReadOnly 
					| FileAttributes.Archive 
					| FileAttributes.Compressed
					| FileAttributes.Hidden
					| FileAttributes.System);
			}
			byte[] fileContent = Convert.FromBase64String(content);
			File.WriteAllBytes(fileName, fileContent);
			File.SetCreationTime(fileName, creationTime);
			File.SetLastWriteTime(fileName, lastWriteTime);
			File.SetAttributes(fileName, attributes);
		}

		internal static void DeleteFile(string fileName)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			fileInfo.Delete();
		}

		internal static void DeleteFile(FileInfo fileInfo)
		{
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
			string path = Path.Combine(Application.CommonAppDataPath, protectedFile.Name + Properties.Resources.ProtectedFileExtension);
			using (StreamWriter fileOutput = new StreamWriter(path))
			{
				fileOutput.WriteLine(protectedFile.Name);
				fileOutput.WriteLine(protectedFile.TargetDirectory);
				fileOutput.WriteLine(protectedFile.Attributes);
				fileOutput.WriteLine(protectedFile.CreationTime);
				fileOutput.WriteLine(protectedFile.LastWriteTime);
				fileOutput.WriteLine(protectedFile.Size);
				fileOutput.WriteLine(protectedFile.MD5Hash);
				fileOutput.WriteLine(protectedFile.InitializationVector);

				fileOutput.Write(protectedFile.FileContent);
			}
		}

		internal static async Task SetData(string data)
		{
			string path = Path.Combine(Application.CommonAppDataPath, Properties.Resources.DataFile);
			using (StreamWriter dataFile = new StreamWriter(path, true))
			{
				await dataFile.WriteLineAsync(data);
			}
		}

		internal static List<string> GetData()
		{
			string path = Path.Combine(Application.CommonAppDataPath, Properties.Resources.DataFile);
			List<string> result = new List<string>();
			if(File.Exists(path))
			{
				using (StreamReader dataFile = new StreamReader(path))
				{
					while (!dataFile.EndOfStream)
					{
						result.Add(dataFile.ReadLine());
					}
				}
			}
			return result;
		}

		private static void RemoveFileAttributes(string fileName, FileAttributes attributes)
		{
			FileInfo file = new FileInfo(fileName);
			FileAttributes oldAttributes = File.GetAttributes(fileName);
			File.SetAttributes(fileName, oldAttributes & ~attributes);
		}
	}
}
