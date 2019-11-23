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
		public MainActivity()
		{
			InitializeComponent();
		}

		private void MainActivity_Load(object sender, EventArgs e)
		{
			USBChecker = new USBChecker();
			label1.Text = string.Join("\n", USBChecker.GetUSBDevicesInfo());
		}

		private void MainActivity_Click(object sender, EventArgs e)
		{
			label1.Text = string.Join("\n", USBChecker.GetUSBDevicesInfo(true));
		}
	}
}
