using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemTrayNotification
{
	public class SystemTrayNotifyIcon
	{
		private NotifyIcon notifyIcon = new NotifyIcon();	// NotifyIcon object
		private ContextMenu BaseMenu;
		private Form mainForm;
		private Icon[] iconArray;
		private Icon mainIcon;
		private Timer iconTimer;
		private int timerInterval = 50;
		private int iconCounter = 0;
		private int totalAnimations = 0;
		private int animationCounter = 0;
		private bool iconsLoaded = false;

		public bool Visibility
		{
			get => notifyIcon.Visible;
			set => notifyIcon.Visible = value;
		}

		public bool KeepAnimationAlive { get; set; } = false;

		/// <summary>
		/// Overloaded Constructor -- 1 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Application Name (Default),
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotifyIcon(Form form, bool visible)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			notifyIcon.Icon = mainForm.Icon;
			notifyIcon.Text = mainForm.Text;
			notifyIcon.ContextMenu = LoadDefaultContextMenu();
			iconTimer = new Timer
			{
				Interval = timerInterval
			};
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		/// <summary>
		/// Overloaded Constructor -- 2 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotifyIcon(Form form, bool visible, string toolTip)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			notifyIcon.Icon = mainForm.Icon;
			notifyIcon.Text = toolTip;
			notifyIcon.ContextMenu = LoadDefaultContextMenu();
			iconTimer = new Timer
			{
				Interval = timerInterval
			};
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		/// <summary>
		/// Overloaded Constructor -- 3 --
		/// Icon = Programmer must provide,
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = SystemTrayNotifyIcon class generated menu (Default).
		/// </summary>
		public SystemTrayNotifyIcon(Form form, bool visible, string toolTip, Icon icon)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			if (icon.Size.Height > 16 || icon.Size.Width > 16)
				notifyIcon.Icon = mainForm.Icon;
			else
				notifyIcon.Icon = icon;
			notifyIcon.Text = toolTip;
			notifyIcon.ContextMenu = LoadDefaultContextMenu();
			iconTimer = new Timer
			{
				Interval = timerInterval
			};
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		/// <summary>
		/// Overloaded Constructor -- 4 --
		/// Icon = Application Icon (Default),
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = Programmer must provide.
		/// </summary>
		public SystemTrayNotifyIcon(Form form, bool visible, string toolTip, ContextMenu contextMenu)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			notifyIcon.Icon = mainForm.Icon;
			notifyIcon.Text = toolTip;
			notifyIcon.ContextMenu = contextMenu;
			iconTimer = new Timer
			{
				Interval = timerInterval
			};
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		/// <summary>
		/// Overloaded Constructor -- 5 --
		/// Icon = Programmer must provide,
		/// Tooltip = Programmer must provide,
		/// Visibility = Programmer must provide,
		/// ContextMenu = Programmer must provide.
		/// </summary>
		public SystemTrayNotifyIcon(Form form, bool visible, string toolTip, Icon icon, ContextMenu contextMenu)
		{
			mainForm = form;
			notifyIcon.Visible = visible;
			if (icon.Size.Height > 16 || icon.Size.Width > 16)
				notifyIcon.Icon = mainForm.Icon;
			else
				notifyIcon.Icon = icon;
			notifyIcon.Text = toolTip;
			notifyIcon.ContextMenu = contextMenu;
			iconTimer = new Timer
			{
				Interval = timerInterval
			};
			iconTimer.Tick += new EventHandler(TimerProc);
		}

		public void Dispose()
		{
			iconTimer.Tick -= new EventHandler(TimerProc);
			if (BaseMenu != null)
				BaseMenu.Dispose();
			notifyIcon.Dispose();
		}

		~SystemTrayNotifyIcon()
		{
		}

		private ContextMenu LoadDefaultContextMenu()
		{
			BaseMenu = new ContextMenu();

			BaseMenu.MenuItems.Add(new MenuItem("Hide Icon", new EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("-", new EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("Exit Application", new EventHandler(DefaultMenuHandler)));

			return BaseMenu;
		}

		private void DefaultMenuHandler(object sender, EventArgs e) 
		{
			try 
			{
				switch (((MenuItem)sender).Text)
				{
					case "Animate":
						Animate(-1, 50);
						break;
					case "Stop Animation":
						KeepAnimationAlive = false;
						break;
					case "Hide Icon":
						notifyIcon.Visible = false;
						break;
					case "Exit Application":
						notifyIcon.Visible = false;
						mainForm.Close();
						break;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message,"Error");
			}
		}

		public void Animate(int nTimes)
		{
			if (!iconsLoaded)
			{
				return;
			}
			if ((nTimes == -1) || (nTimes > 0))
			{
				totalAnimations = nTimes;
				KeepAnimationAlive = true;
				iconTimer.Start();
			}
		}

		public void Animate(int nTimes, int timerinterval)
		{
			timerInterval = (timerinterval>50000 || timerinterval<50)?200:timerinterval;
			if (!iconsLoaded)
			{
				MessageBox.Show("LoadIcons() must be called before Animate().", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((nTimes == -1) || (nTimes > 0))
			{
				if (BaseMenu != null)
				{
					BaseMenu.MenuItems.RemoveAt(0);
					BaseMenu.MenuItems.Add(0, new MenuItem("Stop Animation", new System.EventHandler(DefaultMenuHandler)));
				}
				totalAnimations = nTimes;
				iconTimer.Interval = timerInterval;
				KeepAnimationAlive = true;
				iconTimer.Start();
			}
		}

		/// <summary>
		/// Loads default icons of size 16x16 for animation,
		/// </summary>
		public void LoadIcons(Icon[] iconarray)
		{
			iconsLoaded = true;
			iconCounter = 0;
			totalAnimations = 0;
			mainIcon = notifyIcon.Icon;
			iconArray = iconarray;
			if (BaseMenu != null)
				BaseMenu.MenuItems.Add(0, new MenuItem("Animate", new System.EventHandler(DefaultMenuHandler)));
		}

		private void TimerProc(object sender, EventArgs e)
		{
			if (KeepAnimationAlive == false)
			{
				iconTimer.Stop();
				iconCounter = 0;
				animationCounter = 0;
				notifyIcon.Icon = mainIcon;
				if (BaseMenu != null)
				{
					BaseMenu.MenuItems.RemoveAt(0);
					BaseMenu.MenuItems.Add(0, new MenuItem("Animate", new System.EventHandler(DefaultMenuHandler)));
				}
			}
			else
			{
				notifyIcon.Icon = iconArray[iconCounter++];
				if (iconCounter == iconArray.Length)
				{
					iconCounter = 0;
					animationCounter++;
				}
				
				if ((animationCounter == totalAnimations) && (totalAnimations != -1))
				{
					animationCounter = 0;
					totalAnimations = 0;
					KeepAnimationAlive = false;
				}
			}
		}
	}
}
