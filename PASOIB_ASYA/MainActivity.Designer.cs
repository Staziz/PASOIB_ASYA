﻿namespace PASOIB_ASYA
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
			this.RealtimeDataTab = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.EventsListBox = new System.Windows.Forms.ListBox();
			this.PrintEventListButton = new System.Windows.Forms.Button();
			this.FilesSelectionTab = new System.Windows.Forms.TabPage();
			this.FilesSelectionTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.ButtonsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.DeleteFileButton = new System.Windows.Forms.Button();
			this.RestoreFileButton = new System.Windows.Forms.Button();
			this.AddFileButton = new System.Windows.Forms.Button();
			this.ProctectingFilesDataGrid = new System.Windows.Forms.DataGridView();
			this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileCreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AuthenticationTab = new System.Windows.Forms.TabPage();
			this.AuthenticationTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.USBDevicesDataGrid = new System.Windows.Forms.DataGridView();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DiskDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VisualLock = new PASOIB_ASYA.VisualLock();
			this.SelectButton = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.RealtimeDataTab.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.FilesSelectionTab.SuspendLayout();
			this.FilesSelectionTableLayout.SuspendLayout();
			this.ButtonsFlowLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ProctectingFilesDataGrid)).BeginInit();
			this.AuthenticationTab.SuspendLayout();
			this.AuthenticationTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.USBDevicesDataGrid)).BeginInit();
			this.tabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// RealtimeDataTab
			// 
			this.RealtimeDataTab.Controls.Add(this.tableLayoutPanel1);
			this.RealtimeDataTab.Location = new System.Drawing.Point(4, 22);
			this.RealtimeDataTab.Name = "RealtimeDataTab";
			this.RealtimeDataTab.Padding = new System.Windows.Forms.Padding(3);
			this.RealtimeDataTab.Size = new System.Drawing.Size(792, 424);
			this.RealtimeDataTab.TabIndex = 3;
			this.RealtimeDataTab.Text = "Realtime Data";
			this.RealtimeDataTab.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.PrintEventListButton, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.EventsListBox, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 418);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// EventsListBox
			// 
			this.EventsListBox.BackColor = System.Drawing.Color.White;
			this.EventsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EventsListBox.FormattingEnabled = true;
			this.EventsListBox.Location = new System.Drawing.Point(5, 5);
			this.EventsListBox.Margin = new System.Windows.Forms.Padding(5);
			this.EventsListBox.Name = "EventsListBox";
			this.EventsListBox.Size = new System.Drawing.Size(776, 374);
			this.EventsListBox.TabIndex = 0;
			// 
			// PrintEventListButton
			// 
			this.PrintEventListButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.PrintEventListButton.Location = new System.Drawing.Point(708, 387);
			this.PrintEventListButton.Name = "PrintEventListButton";
			this.PrintEventListButton.Size = new System.Drawing.Size(75, 28);
			this.PrintEventListButton.TabIndex = 1;
			this.PrintEventListButton.Text = "Print";
			this.PrintEventListButton.UseVisualStyleBackColor = true;
			this.PrintEventListButton.Click += new System.EventHandler(this.PrintEventListButton_Click);
			// 
			// FilesSelectionTab
			// 
			this.FilesSelectionTab.Controls.Add(this.FilesSelectionTableLayout);
			this.FilesSelectionTab.Location = new System.Drawing.Point(4, 22);
			this.FilesSelectionTab.Name = "FilesSelectionTab";
			this.FilesSelectionTab.Padding = new System.Windows.Forms.Padding(3);
			this.FilesSelectionTab.Size = new System.Drawing.Size(792, 424);
			this.FilesSelectionTab.TabIndex = 2;
			this.FilesSelectionTab.Text = "Files Selection";
			this.FilesSelectionTab.UseVisualStyleBackColor = true;
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
			// ButtonsFlowLayout
			// 
			this.ButtonsFlowLayout.Controls.Add(this.AddFileButton);
			this.ButtonsFlowLayout.Controls.Add(this.RestoreFileButton);
			this.ButtonsFlowLayout.Controls.Add(this.DeleteFileButton);
			this.ButtonsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonsFlowLayout.Location = new System.Drawing.Point(553, 212);
			this.ButtonsFlowLayout.Name = "ButtonsFlowLayout";
			this.ButtonsFlowLayout.Size = new System.Drawing.Size(230, 203);
			this.ButtonsFlowLayout.TabIndex = 1;
			// 
			// DeleteFileButton
			// 
			this.DeleteFileButton.Location = new System.Drawing.Point(3, 32);
			this.DeleteFileButton.Name = "DeleteFileButton";
			this.DeleteFileButton.Size = new System.Drawing.Size(75, 23);
			this.DeleteFileButton.TabIndex = 2;
			this.DeleteFileButton.Text = "Delete File";
			this.DeleteFileButton.UseVisualStyleBackColor = true;
			this.DeleteFileButton.Click += new System.EventHandler(this.DeleteFileButton_Click);
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
			// FileSize
			// 
			this.FileSize.HeaderText = "Size";
			this.FileSize.Name = "FileSize";
			this.FileSize.ReadOnly = true;
			// 
			// FileCreationTime
			// 
			this.FileCreationTime.HeaderText = "Creation Time";
			this.FileCreationTime.Name = "FileCreationTime";
			this.FileCreationTime.ReadOnly = true;
			// 
			// FileName
			// 
			this.FileName.HeaderText = "File Name";
			this.FileName.Name = "FileName";
			this.FileName.ReadOnly = true;
			// 
			// AuthenticationTab
			// 
			this.AuthenticationTab.Controls.Add(this.AuthenticationTableLayout);
			this.AuthenticationTab.Location = new System.Drawing.Point(4, 22);
			this.AuthenticationTab.Name = "AuthenticationTab";
			this.AuthenticationTab.Padding = new System.Windows.Forms.Padding(3);
			this.AuthenticationTab.Size = new System.Drawing.Size(792, 424);
			this.AuthenticationTab.TabIndex = 0;
			this.AuthenticationTab.Text = "Authentication";
			this.AuthenticationTab.UseVisualStyleBackColor = true;
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
			// USBDevicesDataGrid
			// 
			this.USBDevicesDataGrid.AllowUserToAddRows = false;
			this.USBDevicesDataGrid.AllowUserToDeleteRows = false;
			this.USBDevicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.USBDevicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.USBDevicesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DiskDrive,
            this.DeviceName,
            this.DeviceID,
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
			// Description
			// 
			this.Description.HeaderText = "Description";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			// 
			// DeviceID
			// 
			this.DeviceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.DeviceID.HeaderText = "Device ID";
			this.DeviceID.Name = "DeviceID";
			this.DeviceID.ReadOnly = true;
			this.DeviceID.Width = 131;
			// 
			// DeviceName
			// 
			this.DeviceName.HeaderText = "Name";
			this.DeviceName.Name = "DeviceName";
			this.DeviceName.ReadOnly = true;
			// 
			// DiskDrive
			// 
			this.DiskDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.DiskDrive.Frozen = true;
			this.DiskDrive.HeaderText = "Disk Drive";
			this.DiskDrive.Name = "DiskDrive";
			this.DiskDrive.ReadOnly = true;
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
			// tabControl
			// 
			this.tabControl.Controls.Add(this.AuthenticationTab);
			this.tabControl.Controls.Add(this.FilesSelectionTab);
			this.tabControl.Controls.Add(this.RealtimeDataTab);
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
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainActivity_FormClosed);
			this.Load += new System.EventHandler(this.MainActivity_Load);
			this.Shown += new System.EventHandler(this.MainActivity_Shown);
			this.RealtimeDataTab.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.FilesSelectionTab.ResumeLayout(false);
			this.FilesSelectionTableLayout.ResumeLayout(false);
			this.ButtonsFlowLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ProctectingFilesDataGrid)).EndInit();
			this.AuthenticationTab.ResumeLayout(false);
			this.AuthenticationTableLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.USBDevicesDataGrid)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage RealtimeDataTab;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button PrintEventListButton;
		private System.Windows.Forms.ListBox EventsListBox;
		private System.Windows.Forms.TabPage FilesSelectionTab;
		private System.Windows.Forms.TableLayoutPanel FilesSelectionTableLayout;
		private System.Windows.Forms.DataGridView ProctectingFilesDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileCreationTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
		private System.Windows.Forms.FlowLayoutPanel ButtonsFlowLayout;
		private System.Windows.Forms.Button AddFileButton;
		private System.Windows.Forms.Button RestoreFileButton;
		private System.Windows.Forms.Button DeleteFileButton;
		private System.Windows.Forms.TabPage AuthenticationTab;
		private System.Windows.Forms.TableLayoutPanel AuthenticationTableLayout;
		private System.Windows.Forms.Button SelectButton;
		private VisualLock VisualLock;
		private System.Windows.Forms.DataGridView USBDevicesDataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn DiskDrive;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DeviceID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.TabControl tabControl;
	}
}

