using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PASOIB
{
	internal class TwilioSMSSender
	{
		private readonly string fromNumber;
		private readonly string toNumber;
		private readonly string accountSid;
		private readonly string authToken;

		/// <summary>
		/// </summary>
		/// <param name="targetNumber">Set cellfone number in international format, a.k.a. +7aaaBBBccDD</param>
		public TwilioSMSSender(string targetNumber)
		{
			fromNumber = "+17855945463";
			toNumber = targetNumber;
			accountSid = "ACa224ed760a26238bb9d621ef3a5d9b57";
			authToken = "a39abd0a2907f124f0892e73f626443f";
			TwilioClient.Init(accountSid, authToken);
		}

		public int SendVerificationSMS()
		{
			var randomizer = new Random();
			int codeNumber = randomizer.Next(100000, 1000000);
			MessageResource message = MessageResource.Create(
				body: codeNumber.ToString(),
				from: new Twilio.Types.PhoneNumber(fromNumber),
				to: new Twilio.Types.PhoneNumber(toNumber)
			);
			Console.WriteLine(message.Sid);
			return codeNumber;
		}
	}
}
