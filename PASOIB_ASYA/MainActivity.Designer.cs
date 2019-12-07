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
			this.FilesSelectionTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.ProctectingFilesDataGrid = new System.Windows.Forms.DataGridView();
			this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileCreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AddFileButton = new System.Windows.Forms.Button();
			this.tabAuthentication = new System.Windows.Forms.TabPage();
			this.AuthenticationTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.SelectButton = new System.Windows.Forms.Button();
			this.VisualLock = new PASOIB_ASYA.VisualLock();
			this.USBDevicesDataGrid = new System.Windows.Forms.DataGridView();
			this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PNPDeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.ButtonsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.RestoreFileButton = new System.Windows.Forms.Button();
			this.tabFilesSelection.SuspendLayout();
			this.FilesSelectionTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProctectingFilesDataGrid)).BeginInit();
			this.tabAuthentication.SuspendLayout();
			this.AuthenticationTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.USBDevicesDataGrid)).BeginInit();
			this.tabControl.SuspendLayout();
			this.ButtonsFlowLayout.SuspendLayout();
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
			this.tabFilesSelection.Controls.Add(this.FilesSelectionTableLayout);
			this.tabFilesSelection.Location = new System.Drawing.Point(4, 22);
			this.tabFilesSelection.Name = "tabFilesSelection";
			this.tabFilesSelection.Padding = new System.Windows.Forms.Padding(3);
			this.tabFilesSelection.Size = new System.Drawing.Size(792, 424);
			this.tabFilesSelection.TabIndex = 2;
			this.tabFilesSelection.Text = "Files Selection";
			this.tabFilesSelection.UseVisualStyleBackColor = true;
			// 
			// FilesSelectionTableLayout
			// 
			this.FilesSelectionTableLayout.ColumnCount = 2;
			this.FilesSelectionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.FilesSelectionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.FilesSelectionTableLayout.Controls.Add(this.ProctectingFilesDataGrid, 0, 0);
			this.FilesSelectionTableLayout.Controls.Add(this.ButtonsFlowLayout, 1, 1);
			this.FilesSelectionTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilesSelectionTableLayout.Location = new System.Drawing.Point(3, 3);
			this.FilesSelectionTableLayout.Name = "FilesSelectionTableLayout";
			this.FilesSelectionTableLayout.RowCount = 2;
			this.FilesSelectionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.FilesSelectionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.FilesSelectionTableLayout.Size = new System.Drawing.Size(786, 418);
			this.FilesSelectionTableLayout.TabIndex = 1;
			// 
			// ProctectingFilesDataGrid
			// 
			this.ProctectingFilesDataGrid.AllowUserToAddRows = false;
			this.ProctectingFilesDataGrid.AllowUserToDeleteRows = false;
			this.ProctectingFilesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.ProctectingFilesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ProctectingFilesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileCreationTime,
            this.FileSize});
			this.ProctectingFilesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ProctectingFilesDataGrid.Location = new System.Drawing.Point(3, 3);
			this.ProctectingFilesDataGrid.Name = "ProctectingFilesDataGrid";
			this.ProctectingFilesDataGrid.ReadOnly = true;
			this.FilesSelectionTableLayout.SetRowSpan(this.ProctectingFilesDataGrid, 2);
			this.ProctectingFilesDataGrid.Size = new System.Drawing.Size(544, 412);
			this.ProctectingFilesDataGrid.TabIndex = 0;
			// 
			// FileName
			// 
			this.FileName.HeaderText = "File Name";
			this.FileName.Name = "FileName";
			this.FileName.ReadOnly = true;
			// 
			// FileCreationTime
			// 
			this.FileCreationTime.HeaderText = "Creation Time";
			this.FileCreationTime.Name = "FileCreationTime";
			this.FileCreationTime.ReadOnly = true;
			// 
			// FileSize
			// 
			this.FileSize.HeaderText = "Size";
			this.FileSize.Name = "FileSize";
			this.FileSize.ReadOnly = true;
			// 
			// AddFileButton
			// 
			this.AddFileButton.Location = new System.Drawing.Point(3, 3);
			this.AddFileButton.Name = "AddFileButton";
			this.AddFileButton.Size = new System.Drawing.Size(75, 23);
			this.AddFileButton.TabIndex = 0;
			this.AddFileButton.Text = "Add File";
			this.AddFileButton.UseVisualStyleBackColor = true;
			this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
			// 
			// tabAuthentication
			// 
			this.tabAuthentication.Controls.Add(this.AuthenticationTableLayout);
			this.tabAuthentication.Location = new System.Drawing.Point(4, 22);
			this.tabAuthentication.Name = "tabAuthentication";
			this.tabAuthentication.Padding = new System.Windows.Forms.Padding(3);
			this.tabAuthentication.Size = new System.Drawing.Size(792, 424);
			this.tabAuthentication.TabIndex = 0;
			this.tabAuthentication.Text = "Authentication";
			this.tabAuthentication.UseVisualStyleBackColor = true;
			// 
			// AuthenticationTableLayout
			// 
			this.AuthenticationTableLayout.ColumnCount = 3;
			this.AuthenticationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.AuthenticationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
			this.AuthenticationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.AuthenticationTableLayout.Controls.Add(this.SelectButton, 1, 3);
			this.AuthenticationTableLayout.Controls.Add(this.VisualLock, 0, 1);
			this.AuthenticationTableLayout.Controls.Add(this.USBDevicesDataGrid, 2, 0);
			this.AuthenticationTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AuthenticationTableLayout.Location = new System.Drawing.Point(3, 3);
			this.AuthenticationTableLayout.Name = "AuthenticationTableLayout";
			this.AuthenticationTableLayout.RowCount = 4;
			this.AuthenticationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AuthenticationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AuthenticationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AuthenticationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.AuthenticationTableLayout.Size = new System.Drawing.Size(786, 418);
			this.AuthenticationTableLayout.TabIndex = 0;
			// 
			// SelectButton
			// 
			this.SelectButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.SelectButton.Location = new System.Drawing.Point(120, 315);
			this.SelectButton.Name = "SelectButton";
			this.SelectButton.Size = new System.Drawing.Size(111, 23);
			this.SelectButton.TabIndex = 4;
			this.SelectButton.Text = "Select";
			this.SelectButton.UseVisualStyleBackColor = true;
			this.SelectButton.Click += new System.EventHandler(this.ButtonSelect_Click);
			// 
			// VisualLock
			// 
			this.VisualLock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.AuthenticationTableLayout.SetColumnSpan(this.VisualLock, 2);
			this.VisualLock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VisualLock.Location = new System.Drawing.Point(3, 107);
			this.VisualLock.Name = "VisualLock";
			this.VisualLock.Size = new System.Drawing.Size(228, 98);
			this.VisualLock.State = PASOIB_ASYA.VisualLock._State.Locked;
			this.VisualLock.TabIndex = 5;
			// 
			// USBDevicesDataGrid
			// 
			this.USBDevicesDataGrid.AllowUserToAddRows = false;
			this.USBDevicesDataGrid.AllowUserToDeleteRows = false;
			this.USBDevicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.USBDevicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.USBDevicesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceID,
            this.PNPDeviceID,
            this.DeviceName,
            this.Description});
			this.USBDevicesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.USBDevicesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.USBDevicesDataGrid.Location = new System.Drawing.Point(237, 3);
			this.USBDevicesDataGrid.MultiSelect = false;
			this.USBDevicesDataGrid.Name = "USBDevicesDataGrid";
			this.USBDevicesDataGrid.ReadOnly = true;
			this.USBDevicesDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.AuthenticationTableLayout.SetRowSpan(this.USBDevicesDataGrid, 4);
			this.USBDevicesDataGrid.Size = new System.Drawing.Size(546, 412);
			this.USBDevicesDataGrid.TabIndex = 7;
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
			// ButtonsFlowLayout
			// 
			this.ButtonsFlowLayout.Controls.Add(this.AddFileButton);
			this.ButtonsFlowLayout.Controls.Add(this.RestoreFileButton);
			this.ButtonsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonsFlowLayout.Location = new System.Drawing.Point(553, 212);
			this.ButtonsFlowLayout.Name = "ButtonsFlowLayout";
			this.ButtonsFlowLayout.Size = new System.Drawing.Size(230, 203);
			this.ButtonsFlowLayout.TabIndex = 1;
			// 
			// RestoreFileButton
			// 
			this.RestoreFileButton.Location = new System.Drawing.Point(84, 3);
			this.RestoreFileButton.Name = "RestoreFileButton";
			this.RestoreFileButton.Size = new System.Drawing.Size(75, 23);
			this.RestoreFileButton.TabIndex = 1;
			this.RestoreFileButton.Text = "Restore File";
			this.RestoreFileButton.UseVisualStyleBackColor = true;
			this.RestoreFileButton.Click += new System.EventHandler(this.RestoreFileButton_Click);
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
			this.Shown += new System.EventHandler(this.MainActivity_Shown);
			this.tabFilesSelection.ResumeLayout(false);
			this.FilesSelectionTableLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ProctectingFilesDataGrid)).EndInit();
			this.tabAuthentication.ResumeLayout(false);
			this.AuthenticationTableLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.USBDevicesDataGrid)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.ButtonsFlowLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabReports;
		private System.Windows.Forms.TabPage tabRealtimeData;
		private System.Windows.Forms.TabPage tabFilesSelection;
		private System.Windows.Forms.TabPage tabAuthentication;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TableLayoutPanel AuthenticationTableLayout;
		private System.Windows.Forms.Button SelectButton;
		private VisualLock VisualLock;
		private System.Windows.Forms.DataGridView USBDevicesDataGrid;
		private System.Windows.Forms.TableLayoutPanel FilesSelectionTableLayout;
		private System.Windows.Forms.DataGridView ProctectingFilesDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceID;
		private System.Windows.Forms.DataGridViewTextBoxColumn PNPDeviceID;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileCreationTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
		private System.Windows.Forms.Button AddFileButton;
		private System.Windows.Forms.FlowLayoutPanel ButtonsFlowLayout;
		private System.Windows.Forms.Button RestoreFileButton;
	}
}

