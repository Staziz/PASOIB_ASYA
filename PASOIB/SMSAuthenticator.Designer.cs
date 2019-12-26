namespace PASOIB
{
	partial class SMSAuthenticator
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
			this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SendCodeButton = new System.Windows.Forms.Button();
			this.VerifyCodeButton = new System.Windows.Forms.Button();
			this.VerificationCodeTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// PhoneNumberTextBox
			// 
			this.PhoneNumberTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.PhoneNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.PhoneNumberTextBox.Location = new System.Drawing.Point(57, 37);
			this.PhoneNumberTextBox.MaxLength = 10;
			this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
			this.PhoneNumberTextBox.Size = new System.Drawing.Size(90, 13);
			this.PhoneNumberTextBox.TabIndex = 0;
			this.PhoneNumberTextBox.WordWrap = false;
			this.PhoneNumberTextBox.TextChanged += new System.EventHandler(this.PhoneNumberTextBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "+7";
			// 
			// SendCodeButton
			// 
			this.SendCodeButton.Location = new System.Drawing.Point(211, 32);
			this.SendCodeButton.Name = "SendCodeButton";
			this.SendCodeButton.Size = new System.Drawing.Size(75, 23);
			this.SendCodeButton.TabIndex = 1;
			this.SendCodeButton.Text = "Send code";
			this.SendCodeButton.UseVisualStyleBackColor = true;
			this.SendCodeButton.Click += new System.EventHandler(this.SendCodeButton_Click);
			// 
			// VerifyCodeButton
			// 
			this.VerifyCodeButton.Location = new System.Drawing.Point(211, 89);
			this.VerifyCodeButton.Name = "VerifyCodeButton";
			this.VerifyCodeButton.Size = new System.Drawing.Size(75, 23);
			this.VerifyCodeButton.TabIndex = 3;
			this.VerifyCodeButton.Text = "Verify code";
			this.VerifyCodeButton.UseVisualStyleBackColor = true;
			this.VerifyCodeButton.Click += new System.EventHandler(this.VerifyCodeButton_Click);
			// 
			// VerificationCodeTextBox
			// 
			this.VerificationCodeTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.VerificationCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.VerificationCodeTextBox.Location = new System.Drawing.Point(57, 94);
			this.VerificationCodeTextBox.MaxLength = 6;
			this.VerificationCodeTextBox.Name = "VerificationCodeTextBox";
			this.VerificationCodeTextBox.Size = new System.Drawing.Size(90, 13);
			this.VerificationCodeTextBox.TabIndex = 2;
			this.VerificationCodeTextBox.TextChanged += new System.EventHandler(this.VerificationCodeTextBox_TextChanged);
			// 
			// SMSAuthenticator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 161);
			this.ControlBox = false;
			this.Controls.Add(this.VerificationCodeTextBox);
			this.Controls.Add(this.VerifyCodeButton);
			this.Controls.Add(this.SendCodeButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PhoneNumberTextBox);
			this.MaximumSize = new System.Drawing.Size(360, 200);
			this.MinimumSize = new System.Drawing.Size(360, 200);
			this.Name = "SMSAuthenticator";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "SMSAuthenticator";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox PhoneNumberTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SendCodeButton;
		private System.Windows.Forms.Button VerifyCodeButton;
		private System.Windows.Forms.TextBox VerificationCodeTextBox;
	}
}