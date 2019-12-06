using System;
using System.Collections.Generic;
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
				byte[] data = md5Hash.ComputeHash(Encoding.Unicode.GetBytes(input));
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
			string cipherText = null;
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Convert.FromBase64String(Key);
				aesAlg.IV = Convert.FromBase64String(IV);
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							swEncrypt.Write(plainText);
						}
						cipherText = Convert.ToBase64String(msEncrypt.ToArray());
					}
				}
			}
			return cipherText;
		}

		public static string DecryptFileAES(string cipherText, string Key, string IV)
		{
			string plainText = null;
			using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
			{
				aesAlg.Key = Convert.FromBase64String(Key);
				aesAlg.IV = Convert.FromBase64String(IV);
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
				using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{
							plainText = srDecrypt.ReadToEnd();
						}
					}
				}
			}
			return plainText;
		}

		public static string GetKey(string humanKey = null)
		{
			using (AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider())
			{
				aesCryptoProvider.GenerateKey();
				var keyString = aesCryptoProvider.Key;
				if (humanKey == null)
				{
					humanKey = DataAccess.GetIdentificator();
				}
				return XORStrings(humanKey, keyString);
			}
		}

		public static string GetInitializationVector()
		{
			using (AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider())
			{
				aesCryptoProvider.GenerateIV();
				return Convert.ToBase64String(aesCryptoProvider.IV);
			}
		}

		public static string XORStrings(string key, byte[] input)
		{
			List<byte> result = new List<byte>();
			for (int i = 0; i < input.Length; i++)
			{
				result.Add(Convert.ToByte(input[i] ^ key[i % key.Length]));
			}
			return Convert.ToBase64String(result.ToArray());
		}

	}
}
