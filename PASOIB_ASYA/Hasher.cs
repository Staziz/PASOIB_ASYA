using System;
using System.Security.Cryptography;
using System.Text;

namespace PASOIB_ASYA
{
	public static class Hasher
	{
		private static readonly MD5 md5Hash;

		static Hasher()
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
	}
}
