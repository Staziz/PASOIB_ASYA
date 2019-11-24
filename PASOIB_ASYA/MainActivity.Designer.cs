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
			this.buttonSelect = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.dataGridUSBDevices = new System.Windows.Forms.DataGridView();
			this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PNPDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.visualLock = new PASOIB_ASYA.VisualLock();
			this.tabAuthentication.SuspendLayout();
			this.tableLayoutAuthentication.SuspendLayout();
			this.tabControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridUSBDevices)).BeginInit();
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
			this.tableLayoutAuthentication.Controls.Add(this.buttonSelect, 1, 3);
			this.tableLayoutAuthentication.Controls.Add(this.visualLock, 0, 1);
			this.tableLayoutAuthentication.Controls.Add(this.dataGridUSBDevices, 2, 0);
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
			// buttonSelect
			// 
			this.buttonSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.buttonSelect.Location = new System.Drawing.Point(120, 315);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(111, 23);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
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
			// dataGridUSBDevices
			// 
			this.dataGridUSBDevices.AllowUserToAddRows = false;
			this.dataGridUSBDevices.AllowUserToDeleteRows = false;
			this.dataGridUSBDevices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridUSBDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridUSBDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceID,
            this.PNPDeviceID,
            this.DeviceName,
            this.Description});
			this.dataGridUSBDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridUSBDevices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridUSBDevices.Location = new System.Drawing.Point(237, 3);
			this.dataGridUSBDevices.MultiSelect = false;
			this.dataGridUSBDevices.Name = "dataGridUSBDevices";
			this.dataGridUSBDevices.ReadOnly = true;
			this.dataGridUSBDevices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.tableLayoutAuthentication.SetRowSpan(this.dataGridUSBDevices, 4);
			this.dataGridUSBDevices.Size = new System.Drawing.Size(546, 412);
			this.dataGridUSBDevices.TabIndex = 7;
			// 
			// DeviceID
			// 
			this.DeviceID.HeaderText = "Device ID";
			this.DeviceID.Name = "DeviceID";
			this.DeviceID.ReadOnly = true;
			// 
			// PNPDeviceID
			// 
			this.PNPDeviceID.HeaderText = "PNP Device ID";
			this.PNPDeviceID.Name = "PNPDeviceID";
			this.PNPDeviceID.ReadOnly = true;
			// 
			// DeviceName
			// 
			this.DeviceName.HeaderText = "Name";
			this.DeviceName.Name = "DeviceName";
			this.DeviceName.ReadOnly = true;
			// 
			// Description
			// 
			this.Description.HeaderText = "Description";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			// 
			// visualLock
			// 
			this.visualLock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutAuthentication.SetColumnSpan(this.visualLock, 2);
			this.visualLock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.visualLock.Location = new System.Drawing.Point(3, 107);
			this.visualLock.Name = "visualLock";
			this.visualLock.Size = new System.Drawing.Size(228, 98);
			this.visualLock.State = PASOIB_ASYA.VisualLock._State.Locked;
			this.visualLock.TabIndex = 5;
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
			((System.ComponentModel.ISupportInitialize)(this.dataGridUSBDevices)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabReports;
		private System.Windows.Forms.TabPage tabRealtimeData;
		private System.Windows.Forms.TabPage tabFilesSelection;
		private System.Windows.Forms.TabPage tabAuthentication;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutAuthentication;
		private System.Windows.Forms.Button buttonSelect;
		private VisualLock visualLock;
		private System.Windows.Forms.DataGridView dataGridUSBDevices;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceID;
		private System.Windows.Forms.DataGridViewTextBoxColumn PNPDeviceID;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
	}
}

