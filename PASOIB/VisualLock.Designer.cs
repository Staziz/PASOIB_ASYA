namespace PASOIB
{
	partial class VisualLock
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

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.lockPicture = new System.Windows.Forms.PictureBox();
			this.lockLabel = new System.Windows.Forms.Label();
			this.tableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lockPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayout
			// 
			this.tableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(201)))));
			this.tableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayout.ColumnCount = 2;
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.3787F));
			this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.6213F));
			this.tableLayout.Controls.Add(this.lockPicture, 0, 0);
			this.tableLayout.Controls.Add(this.lockLabel, 1, 0);
			this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayout.Location = new System.Drawing.Point(0, 0);
			this.tableLayout.Name = "tableLayout";
			this.tableLayout.RowCount = 1;
			this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayout.Size = new System.Drawing.Size(338, 148);
			this.tableLayout.TabIndex = 0;
			// 
			// lockPicture
			// 
			this.lockPicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lockPicture.Image = global::PASOIB.Properties.Resources.ImageLocked;
			this.lockPicture.InitialImage = global::PASOIB.Properties.Resources.ImageLocked;
			this.lockPicture.Location = new System.Drawing.Point(4, 4);
			this.lockPicture.Name = "lockPicture";
			this.lockPicture.Size = new System.Drawing.Size(142, 140);
			this.lockPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.lockPicture.TabIndex = 0;
			this.lockPicture.TabStop = false;
			// 
			// lockLabel
			// 
			this.lockLabel.AutoSize = true;
			this.lockLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(201)))));
			this.lockLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lockLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
			this.lockLabel.Location = new System.Drawing.Point(153, 1);
			this.lockLabel.Name = "lockLabel";
			this.lockLabel.Size = new System.Drawing.Size(181, 146);
			this.lockLabel.TabIndex = 1;
			this.lockLabel.Text = "Locked";
			this.lockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// VisualLock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.tableLayout);
			this.Name = "VisualLock";
			this.Size = new System.Drawing.Size(338, 148);
			this.tableLayout.ResumeLayout(false);
			this.tableLayout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.lockPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayout;
		private System.Windows.Forms.PictureBox lockPicture;
		private System.Windows.Forms.Label lockLabel;
	}
}
