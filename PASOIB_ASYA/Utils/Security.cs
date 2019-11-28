using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PASOIB_ASYA
{
	public static class Security
	{
		private static readonly MD5 md5Hash;

		static Security()
		{
			md5Hash = MD5.Create();
		}

		public static string GetMd5Hash(string input)
		{
			byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			StringBuilder sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}

		public static bool IsStringEqualsHash(string input, string hash)
		{
			string hashOfInput = GetMd5Hash(input);
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;
			return 0 == comparer.Compare(hashOfInput, hash);
		}

		static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}
			return encrypted;

		}

		static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			string plaintext = null;
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}

			}

			return plaintext;

		}

	}
}
