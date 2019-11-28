using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PASOIB_ASYA
{
	internal static class DataAccess
	{
		internal static void SetIdentificator(string identificator)
		{
			string keyFilePath = Path.GetFullPath($"~/{Properties.Resources.KeyFile}");
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

		internal static string GetIdentificator()
		{
			string keyFilePath = Path.GetFullPath($"~{Properties.Resources.KeyFile}");
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

		internal static string GetFileContent(FileInfo fileInfo)
		{
			using (StreamReader fileInput = new StreamReader(fileInfo.FullName))
			{
				return fileInput.ReadToEnd();
			}
		}

		internal static void SetData(List<string> data)
		{
			throw new NotImplementedException();
		}

		internal static List<string> GetData()
		{
			throw new NotImplementedException();
		}
	}
}
