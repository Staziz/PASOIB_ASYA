using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PASOIB;

namespace UnitTestProject
{
	[TestClass]
	public class CryptoSystemTest
	{
		readonly string testString = "TestTestTest\t012345+6798/*@#_Яша, яша, ты ишак";
		[TestMethod]
		public void EncryptDecrypt()
		{
			string key = null;
			string initVector = null;

			for (int i = 0; i < 10; i++)
			{
				key = Security.GetKey("SomeKey");
				initVector = Security.GetInitializationVector();
				string ciperText = Security.EncryptFileAES(testString, key, initVector);
				string plainText = Security.DecryptFileAES(ciperText, key, initVector);
				Assert.AreEqual(testString, plainText);
			}
		}

		[TestMethod]
		public void StringToBytesAndViceVersaWithBase64()
		{
			for (int i = 0; i < 10; i++)
			{
				using (AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider())
				{
					string key = Convert.ToBase64String(aesCryptoProvider.Key);
					string initVector = Convert.ToBase64String(aesCryptoProvider.IV);
					Assert.IsTrue(aesCryptoProvider.Key.SequenceEqual(Convert.FromBase64String(key)));
					Assert.IsTrue(aesCryptoProvider.IV.SequenceEqual(Convert.FromBase64String(initVector)));
				}
			}
		}

		[TestMethod]
		public void HashCompare()
		{
			string origHash = Security.GetMd5Hash(testString);
			Assert.IsTrue(Security.IsStringEqualsHash(testString, origHash));
		}
	}
}
