using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB
{
	internal partial class SMSAuthenticator : Form
	{
		TwilioSMSSender twilioSMSSender;
		string number
		{
			get => Properties.Settings.Default.PhoneNumber;
			set => Properties.Settings.Default.PhoneNumber = value;
		}
		private int VerificationCode;

		public SMSAuthenticator()
		{
			InitializeComponent();
			if (number != "null")
			{
				twilioSMSSender = new TwilioSMSSender(number);
				PhoneNumberTextBox.Text = number;
				PhoneNumberTextBox.Enabled = false;
			}
		}

		private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
		{
			if (PhoneNumberTextBox.Text == "")
			{
				return;
			}
			if (System.Text.RegularExpressions.Regex.IsMatch(PhoneNumberTextBox.Text, "[^0-9]"))
			{
				MessageBox.Show("Please enter only numbers.");
				PhoneNumberTextBox.Text = "";
			}
		}

		private void VerificationCodeTextBox_TextChanged(object sender, EventArgs e)
		{
			if (VerificationCodeTextBox.Text == "")
			{
				return;
			}
			if (System.Text.RegularExpressions.Regex.IsMatch(VerificationCodeTextBox.Text, "[^0-9]"))
			{
				MessageBox.Show("Please enter only numbers.");
				VerificationCodeTextBox.Text = "";
			}
		}

		private void SendCodeButton_Click(object sender, EventArgs e)
		{
			if (PhoneNumberTextBox.Text.Length != 10)
			{
				MessageBox.Show("Cellphone number must contain 10 digits.");
				return;
			}
			if (twilioSMSSender == null)
			{
				number = PhoneNumberTextBox.Text;
				Properties.Settings.Default.Save();
			}
			twilioSMSSender = new TwilioSMSSender($"+7{number}");
			VerificationCode = twilioSMSSender.SendVerificationSMS();
		}

		private void VerifyCodeButton_Click(object sender, EventArgs e)
		{
			if (VerificationCode == int.Parse(VerificationCodeTextBox.Text))
			{
				DialogResult = DialogResult.OK;
				Close();
				return;
			}
			DialogResult = DialogResult.Abort;
			Close();
		}
	}
}
