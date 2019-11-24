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
		private bool _isAuthenticated;
		private bool IsAuthenticated
		{
			get => _isAuthenticated;
			set
			{
				_isAuthenticated = value;
				visualLock.ChangeState((VisualLock._State)(IsAuthenticated ? 1 : 0));
			}
		}

		public MainActivity()
		{
			InitializeComponent();
		}

		private void MainActivity_Load(object sender, EventArgs e)
		{
			USBChecker = new USBChecker();
			IsAuthenticated = false;
			UpdateTabControlState();
		}

		private void UpdateTabControlState()
		{
			((Control)tabAuthentication).Enabled = !IsAuthenticated;
			((Control)tabFilesSelection).Enabled = IsAuthenticated;
			((Control)tabRealtimeData).Enabled = IsAuthenticated;
			((Control)tabReports).Enabled = IsAuthenticated;
		}
	}
}
