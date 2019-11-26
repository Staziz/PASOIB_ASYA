using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	public static class Authentication
	{
		public static void ShowGreeting()
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

		public static bool TryAuthentify(string currentID, string masterID)
		{
			if (masterID == null)
			{
				DataAccess.SetIdentificator(currentID);
				return true;
			}
			else
			{
				if (Hasher.IsStringEqualsHash(currentID, masterID))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
