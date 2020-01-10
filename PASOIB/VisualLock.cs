using System.Windows.Forms;

namespace PASOIB
{
	public partial class VisualLock : UserControl
	{
		public enum _State { Locked, Unlocked };
		public _State _state;
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
					lockLabel.ForeColor= System.Drawing.Color.FromArgb(34, 177, 76);
				}
				else
				{
					lockPicture.Image = Properties.Resources.ImageLocked;
					lockLabel.ForeColor = System.Drawing.Color.FromArgb(237, 28, 36);
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
