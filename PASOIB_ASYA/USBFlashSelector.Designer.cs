namespace PASOIB_ASYA
{
	partial class USBFlashSelector
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.deviceList = new System.Windows.Forms.ListBox();
			this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// deviceList
			// 
			this.tableLayout.SetColumnSpan(this.deviceList, 2);
			this.deviceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.deviceList.FormattingEnabled = true;
			this.deviceList.Location = new System.Drawing.Point(3, 3);
			this.deviceList.Name = "deviceList";
			this.deviceList.Size = new System.Drawing.Size(333, 397);
			this.deviceList.TabIndex = 0;
			// 
			// tableLayout
			// 
			this.tableLayout.ColumnCount = 2;
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout.Controls.Add(this.deviceList, 0, 0);
			this.tableLayout.Controls.Add(this.button1, 0, 1);
			this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayout.Location = new System.Drawing.Point(0, 0);
			this.tableLayout.Name = "tableLayout";
			this.tableLayout.RowCount = 2;
			this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.55556F));
			this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.44444F));
			this.tableLayout.Size = new System.Drawing.Size(339, 450);
			this.tableLayout.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 406);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// USBFlashSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 450);
			this.Controls.Add(this.tableLayout);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "USBFlashSelector";
			this.Text = "USBFlashSelector";
			this.TopMost = true;
			this.tableLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox deviceList;
		private System.Windows.Forms.TableLayoutPanel tableLayout;
		private System.Windows.Forms.Button button1;
	}
}