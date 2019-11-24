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
			this.tabReports = new System.Windows.Forms.TabPage();
			this.tabRealtimeData = new System.Windows.Forms.TabPage();
			this.tabFilesSelection = new System.Windows.Forms.TabPage();
			this.tabAuthentication = new System.Windows.Forms.TabPage();
			this.tableLayoutAuthentication = new System.Windows.Forms.TableLayoutPanel();
			this.ubsDevicesList = new System.Windows.Forms.ListBox();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.visualLock1 = new PASOIB_ASYA.VisualLock();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabAuthentication.SuspendLayout();
			this.tableLayoutAuthentication.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
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
			// tabAuthentication
			// 
			this.tabAuthentication.Controls.Add(this.tableLayoutAuthentication);
			this.tabAuthentication.Location = new System.Drawing.Point(4, 22);
			this.tabAuthentication.Name = "tabAuthentication";
			this.tabAuthentication.Padding = new System.Windows.Forms.Padding(3);
			this.tabAuthentication.Size = new System.Drawing.Size(792, 424);
			this.tabAuthentication.TabIndex = 0;
			this.tabAuthentication.Text = "Authentication";
			this.tabAuthentication.UseVisualStyleBackColor = true;
			// 
			// tableLayoutAuthentication
			// 
			this.tableLayoutAuthentication.ColumnCount = 3;
			this.tableLayoutAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.tableLayoutAuthentication.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutAuthentication.Controls.Add(this.ubsDevicesList, 2, 0);
			this.tableLayoutAuthentication.Controls.Add(this.buttonSelect, 1, 3);
			this.tableLayoutAuthentication.Controls.Add(this.visualLock1, 0, 1);
			this.tableLayoutAuthentication.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutAuthentication.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutAuthentication.Name = "tableLayoutAuthentication";
			this.tableLayoutAuthentication.RowCount = 4;
			this.tableLayoutAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutAuthentication.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutAuthentication.Size = new System.Drawing.Size(786, 418);
			this.tableLayoutAuthentication.TabIndex = 0;
			// 
			// ubsDevicesList
			// 
			this.ubsDevicesList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ubsDevicesList.FormattingEnabled = true;
			this.ubsDevicesList.Location = new System.Drawing.Point(237, 3);
			this.ubsDevicesList.Name = "ubsDevicesList";
			this.tableLayoutAuthentication.SetRowSpan(this.ubsDevicesList, 4);
			this.ubsDevicesList.Size = new System.Drawing.Size(546, 412);
			this.ubsDevicesList.TabIndex = 3;
			// 
			// buttonSelect
			// 
			this.buttonSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonSelect.Location = new System.Drawing.Point(120, 315);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(111, 23);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			// 
			// visualLock1
			// 
			this.visualLock1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutAuthentication.SetColumnSpan(this.visualLock1, 2);
			this.visualLock1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.visualLock1.Location = new System.Drawing.Point(3, 107);
			this.visualLock1.Name = "visualLock1";
			this.visualLock1.Size = new System.Drawing.Size(228, 98);
			this.visualLock1.State = PASOIB_ASYA.VisualLock._State.Locked;
			this.visualLock1.TabIndex = 5;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabAuthentication);
			this.tabControl.Controls.Add(this.tabFilesSelection);
			this.tabControl.Controls.Add(this.tabRealtimeData);
			this.tabControl.Controls.Add(this.tabReports);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 450);
			this.tabControl.TabIndex = 0;
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
			this.tabAuthentication.ResumeLayout(false);
			this.tableLayoutAuthentication.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabReports;
		private System.Windows.Forms.TabPage tabRealtimeData;
		private System.Windows.Forms.TabPage tabFilesSelection;
		private System.Windows.Forms.TabPage tabAuthentication;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutAuthentication;
		private System.Windows.Forms.ListBox ubsDevicesList;
		private System.Windows.Forms.Button buttonSelect;
		private VisualLock visualLock1;
	}
}

