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
            this.image_PICBX = new System.Windows.Forms.PictureBox();
            this.message_bar = new System.Windows.Forms.Label();
            this.Faces_Found_Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelForPasswordLogin
            // 
            this.linkLabelForPasswordLogin.AutoSize = true;
            this.linkLabelForPasswordLogin.Location = new System.Drawing.Point(173, 350);
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
            this.btnExit.Location = new System.Drawing.Point(280, 386);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Location = new System.Drawing.Point(94, 386);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(187, 386);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 3;
            this.btnSignIn.Text = "注册新用户";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // image_PICBX
            // 
            this.image_PICBX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.image_PICBX.Location = new System.Drawing.Point(12, 12);
            this.image_PICBX.Name = "image_PICBX";
            this.image_PICBX.Size = new System.Drawing.Size(441, 317);
            this.image_PICBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_PICBX.TabIndex = 4;
            this.image_PICBX.TabStop = false;
            // 
            // message_bar
            // 
            this.message_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.message_bar.AutoSize = true;
            this.message_bar.Location = new System.Drawing.Point(12, 350);
            this.message_bar.Name = "message_bar";
            this.message_bar.Size = new System.Drawing.Size(53, 12);
            this.message_bar.TabIndex = 5;
            this.message_bar.Text = "Message:";
            // 
            // Faces_Found_Panel
            // 
            this.Faces_Found_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Faces_Found_Panel.AutoScroll = true;
            this.Faces_Found_Panel.Location = new System.Drawing.Point(459, 12);
            this.Faces_Found_Panel.Name = "Faces_Found_Panel";
            this.Faces_Found_Panel.Size = new System.Drawing.Size(194, 317);
            this.Faces_Found_Panel.TabIndex = 6;
            // 
            // FaceRecognitionLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 443);
            this.Controls.Add(this.Faces_Found_Panel);
            this.Controls.Add(this.message_bar);
            this.Controls.Add(this.image_PICBX);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.linkLabelForPasswordLogin);
            this.Name = "FaceRecognitionLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaceRecognitionLoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.LinkLabel linkLabelForPasswordLogin;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.PictureBox image_PICBX;
        private System.Windows.Forms.Label message_bar;
        private System.Windows.Forms.Panel Faces_Found_Panel;
	}
}