using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PASOIB_ASYA
{
	public static class Security
	{
		public static string GetMd5Hash(string input)
		{
			using (MD5 md5Hash = MD5.Create())
			{
				byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
				StringBuilder sBuilder = new StringBuilder();
				for (int i = 0; i < data.Length; i++)
				{
					sBuilder.Append(data[i].ToString("x2"));
				}
				return sBuilder.ToString();
			}
		}

		public static bool IsStringEqualsHash(string input, string hash)
		{
			string hashOfInput = GetMd5Hash(input);
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;
			return 0 == comparer.Compare(hashOfInput, hash);
		}

		public static string EncryptFileAES(string plainText, string Key, string IV)
		{
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(Key);
				aesAlg.IV = Encoding.UTF8.GetBytes(IV);
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(plainText);
						}
						return Encoding.UTF8.GetString(msEncrypt.ToArray());
					}
				}
			}
		}

		public static string DecryptFileAES(string cipherText, string Key, string IV)
		{
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Encoding.UTF8.GetBytes(Key);
				aesAlg.IV = Encoding.UTF8.GetBytes(IV);
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msDecrypt = new MemoryStream(Encoding.UTF8.GetBytes(cipherText)))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							return srDecrypt.ReadToEnd();
						}
					}
				}
			}
		}

	}
}
