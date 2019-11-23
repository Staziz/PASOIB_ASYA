namespace PASOIB_ASYA
{
	partial class MainActivity
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabAuthentication = new System.Windows.Forms.TabPage();
			this.tabKeySelection = new System.Windows.Forms.TabPage();
			this.tabFilesSelection = new System.Windows.Forms.TabPage();
			this.tabRealtimeData = new System.Windows.Forms.TabPage();
			this.tabReports = new System.Windows.Forms.TabPage();
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabAuthentication);
			this.tabControl.Controls.Add(this.tabKeySelection);
			this.tabControl.Controls.Add(this.tabFilesSelection);
			this.tabControl.Controls.Add(this.tabRealtimeData);
			this.tabControl.Controls.Add(this.tabReports);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 450);
			this.tabControl.TabIndex = 4;
			// 
			// tabAuthentication
			// 
			this.tabAuthentication.Location = new System.Drawing.Point(4, 22);
			this.tabAuthentication.Name = "tabAuthentication";
			this.tabAuthentication.Padding = new System.Windows.Forms.Padding(3);
			this.tabAuthentication.Size = new System.Drawing.Size(792, 424);
			this.tabAuthentication.TabIndex = 0;
			this.tabAuthentication.Text = "Authentication";
			this.tabAuthentication.UseVisualStyleBackColor = true;
			// 
			// tabKeySelection
			// 
			this.tabKeySelection.Location = new System.Drawing.Point(4, 22);
			this.tabKeySelection.Name = "tabKeySelection";
			this.tabKeySelection.Padding = new System.Windows.Forms.Padding(3);
			this.tabKeySelection.Size = new System.Drawing.Size(792, 424);
			this.tabKeySelection.TabIndex = 1;
			this.tabKeySelection.Text = "Key Selection";
			this.tabKeySelection.UseVisualStyleBackColor = true;
			// 
			// tabFilesSelection
			// 
			this.tabFilesSelection.Location = new System.Drawing.Point(4, 22);
			this.tabFilesSelection.Name = "tabFilesSelection";
			this.tabFilesSelection.Padding = new System.Windows.Forms.Padding(3);
			this.tabFilesSelection.Size = new System.Drawing.Size(792, 424);
			this.tabFilesSelection.TabIndex = 2;
			this.tabFilesSelection.Text = "Files Selection";
			this.tabFilesSelection.UseVisualStyleBackColor = true;
			// 
			// tabRealtimeData
			// 
			this.tabRealtimeData.Location = new System.Drawing.Point(4, 22);
			this.tabRealtimeData.Name = "tabRealtimeData";
			this.tabRealtimeData.Padding = new System.Windows.Forms.Padding(3);
			this.tabRealtimeData.Size = new System.Drawing.Size(792, 424);
			this.tabRealtimeData.TabIndex = 3;
			this.tabRealtimeData.Text = "Realtime Data";
			this.tabRealtimeData.UseVisualStyleBackColor = true;
			// 
			// tabReports
			// 
			this.tabReports.Location = new System.Drawing.Point(4, 22);
			this.tabReports.Name = "tabReports";
			this.tabReports.Padding = new System.Windows.Forms.Padding(3);
			this.tabReports.Size = new System.Drawing.Size(792, 424);
			this.tabReports.TabIndex = 4;
			this.tabReports.Text = "Reports";
			this.tabReports.UseVisualStyleBackColor = true;
			// 
			// MainActivity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl);
			this.Name = "MainActivity";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainActivity_Load);
			this.Click += new System.EventHandler(this.MainActivity_Click);
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabAuthentication;
		private System.Windows.Forms.TabPage tabKeySelection;
		private System.Windows.Forms.TabPage tabFilesSelection;
		private System.Windows.Forms.TabPage tabRealtimeData;
		private System.Windows.Forms.TabPage tabReports;
	}
}

