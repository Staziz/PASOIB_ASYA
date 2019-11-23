using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PASOIB_ASYA
{
	public partial class VisualLock : UserControl
	{
		public enum _State { Locked, Unlocked };
		public _State State
		{
			get => State;
			private set
			{
				State = value;
				lockPicture.Image =
					State == _State.Unlocked
						? Properties.Resources.ImageUnlocked
						: Properties.Resources.ImageLocked;
				lockLabel.Text = State.ToString();
			}
		}
		public VisualLock()
		{
			InitializeComponent();
		}

		public void ChangeState(_State newState)
		{
			State = newState;
		}
	}
}
