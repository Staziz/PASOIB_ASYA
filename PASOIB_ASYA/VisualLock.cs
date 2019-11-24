using System.Windows.Forms;

namespace PASOIB_ASYA
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
