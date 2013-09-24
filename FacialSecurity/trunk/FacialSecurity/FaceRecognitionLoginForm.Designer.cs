namespace FacialSecurity
{
	partial class FaceRecognitionLoginForm
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
			this.linkLabelForPasswordLogin = new System.Windows.Forms.LinkLabel();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnSignIn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// linkLabelForPasswordLogin
			// 
			this.linkLabelForPasswordLogin.AutoSize = true;
			this.linkLabelForPasswordLogin.Location = new System.Drawing.Point(93, 155);
			this.linkLabelForPasswordLogin.Name = "linkLabelForPasswordLogin";
			this.linkLabelForPasswordLogin.Size = new System.Drawing.Size(89, 12);
			this.linkLabelForPasswordLogin.TabIndex = 0;
			this.linkLabelForPasswordLogin.TabStop = true;
			this.linkLabelForPasswordLogin.Text = "我想用密码登陆";
			this.linkLabelForPasswordLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForPasswordLogin_LinkClicked);
			// 
			// btnExit
			// 
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(196, 208);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "退出";
			this.btnExit.UseVisualStyleBackColor = true;
			// 
			// btnLogin
			// 
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnLogin.Location = new System.Drawing.Point(10, 208);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "登陆";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnSignIn
			// 
			this.btnSignIn.Location = new System.Drawing.Point(103, 208);
			this.btnSignIn.Name = "btnSignIn";
			this.btnSignIn.Size = new System.Drawing.Size(75, 23);
			this.btnSignIn.TabIndex = 3;
			this.btnSignIn.Text = "注册新用户";
			this.btnSignIn.UseVisualStyleBackColor = true;
			this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
			// 
			// FaceRecognitionLoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnSignIn);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.linkLabelForPasswordLogin);
			this.Name = "FaceRecognitionLoginForm";
			this.Text = "FaceRecognitionLoginForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabelForPasswordLogin;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnSignIn;
	}
}