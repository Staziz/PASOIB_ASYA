using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	internal class Authentication
	{
		internal bool IsAuthenticated;

		public Authentication()
		{
			IsAuthenticated = false;
		}

		public void ShowGreeting()
		{
			string message = "";
			string capture = "";
			if (DataAccess.GetIdentificator() == null)
			{
				message = "Please select the USB device you want to set as a key for the program";
				capture = "Preparing for work...";
			}
			else
			{
				message = "Please select the USB device you want to use to enter the program";
				capture = "Preparing for work...";
			}

			DialogResult dialogResult = MessageBox.Show(
					message,
					capture,
					MessageBoxButtons.OKCancel,
					MessageBoxIcon.Asterisk,
					MessageBoxDefaultButton.Button1);
			if (dialogResult == DialogResult.Cancel)
			{
				Application.Exit();
			}
		}

		public void TryAuthentify(string currentID, string masterID, bool force = false)
		{
			if ((masterID == null) && force)
			{
				DataAccess.SetIdentificator(currentID);
				IsAuthenticated = true;
			}
			else
			{
				if (Security.IsStringEqualsHash(currentID, masterID))
				{
					IsAuthenticated = true;
				}
				else
				{
					IsAuthenticated = false;
				}
			}
		}
	}
}
