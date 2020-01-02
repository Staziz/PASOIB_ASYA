using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PASOIB
{
	public partial class VisualLock : UserControl
	{
		public enum _State { Locked, Unlocked };
		public _State _state;
		public Region region;
		public _State State
		{
			get => _state;
			set
			{
				_state = value;
				lockLabel.Text = State.ToString();
				if (State == _State.Unlocked)
				{
					lockPicture.Image = Properties.Resources.ImageUnlocked;
					lockLabel.BackColor = Color.FromArgb(181, 230, 29);
					lockLabel.ForeColor = Color.FromArgb(34, 177, 76);
					tableLayout.BackColor = Color.FromArgb(181, 230, 29);
				}
				else
				{
					lockPicture.Image = Properties.Resources.ImageLocked;
					lockLabel.BackColor = Color.FromArgb(255, 174, 201);
					lockLabel.ForeColor = Color.FromArgb(237, 28, 36);
					tableLayout.BackColor = Color.FromArgb(255, 174, 201);
				}
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
