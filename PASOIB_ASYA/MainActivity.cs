using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	public partial class MainActivity : Form
	{
		private USBChecker USBChecker;
		private bool isAuthenticated;
		public MainActivity()
		{
			InitializeComponent();
		}

		private void MainActivity_Load(object sender, EventArgs e)
		{
			USBChecker = new USBChecker();
			isAuthenticated = false;
			UpdateTabControlState();
		}

		private void UpdateTabControlState()
		{
			if (!isAuthenticated)
			{
				((Control)tabAuthentication).Enabled = true;
				((Control)tabKeySelection).Enabled = false;
				((Control)tabFilesSelection).Enabled = false;
				((Control)tabRealtimeData).Enabled = false;
				((Control)tabReports).Enabled = false;
			}
			else
			{
				((Control)tabAuthentication).Enabled = false;
				((Control)tabKeySelection).Enabled = true;
				((Control)tabFilesSelection).Enabled = true;
				((Control)tabRealtimeData).Enabled = true;
				((Control)tabReports).Enabled = true;
			}
		}
	}
}
