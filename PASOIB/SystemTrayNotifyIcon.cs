using System;
using System.Drawing;
using System.Windows.Forms;

namespace SystemTrayNotification
{
	internal class SystemTrayNotifyIcon : IDisposable
	{
		internal System.Threading.SemaphoreSlim semaphore;
		private NotifyIcon notifyIcon = new NotifyIcon();
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

		internal bool Visibility
		{
			get => notifyIcon.Visible;
			set => notifyIcon.Visible = value;
		}

		internal bool IsClosing = false;
		internal bool KeepAnimationAlive = false;

		internal SystemTrayNotifyIcon(Form form, bool visible)
		{
			semaphore = new System.Threading.SemaphoreSlim(0, 1);
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

		internal SystemTrayNotifyIcon(Form form, bool visible, string toolTip)
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

		internal SystemTrayNotifyIcon(Form form, bool visible, string toolTip, Icon icon)
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

		internal SystemTrayNotifyIcon(Form form, bool visible, string toolTip, ContextMenu contextMenu)
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

		internal SystemTrayNotifyIcon(Form form, bool visible, string toolTip, Icon icon, ContextMenu contextMenu)
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

			BaseMenu.MenuItems.Add(new MenuItem("Open", new EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("-", new EventHandler(DefaultMenuHandler)));
			BaseMenu.MenuItems.Add(new MenuItem("Stop security service", new EventHandler(DefaultMenuHandler)));

			return BaseMenu;
		}

		private void DefaultMenuHandler(object sender, EventArgs e) 
		{
			try 
			{
				switch (((MenuItem)sender).Text)
				{
					case "Open":
						mainForm.Show();
						break;
					case "Stop security service":
						IsClosing = true;
						mainForm.Close();
						break;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message,"Error");
			}
		}

		internal void Animate(int nTimes)
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

		internal void Animate(int nTimes, int timerinterval)
		{
			timerInterval = (timerinterval>50000 || timerinterval<50)?200:timerinterval;
			if (!iconsLoaded)
			{
				MessageBox.Show("LoadIcons() must be called before Animate().", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if ((nTimes == -1) || (nTimes > 0))
			{
				totalAnimations = nTimes;
				iconTimer.Interval = timerInterval;
				KeepAnimationAlive = true;
				iconTimer.Start();
			}
		}

		/// <summary>
		/// Loads default icons of size 16x16 for animation,
		/// </summary>
		internal void LoadIcons(Icon[] iconarray)
		{
			iconsLoaded = true;
			iconCounter = 0;
			totalAnimations = 0;
			mainIcon = notifyIcon.Icon;
			iconArray = iconarray;
		}

		private void TimerProc(object sender, EventArgs e)
		{
			if (KeepAnimationAlive == false)
			{
				iconTimer.Stop();
				iconCounter = 0;
				animationCounter = 0;
				notifyIcon.Icon = mainIcon;
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
