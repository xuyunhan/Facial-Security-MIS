namespace FacialSecurity
{
	partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ADD_ALL = new System.Windows.Forms.Button();
            this.count_lbl = new System.Windows.Forms.Label();
            this.Single_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RECORD_BTN = new System.Windows.Forms.Button();
            this.NAME_PERSON = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.face_PICBX = new System.Windows.Forms.PictureBox();
            this.image_PICBX = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.face_PICBX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSignIn.Location = new System.Drawing.Point(461, 384);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "确定";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(583, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(52, 31);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(116, 21);
            this.textBoxPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "密码";
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(270, 31);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(128, 21);
            this.textBoxConfirmPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "确认密码";
            // 
            // ADD_ALL
            // 
            this.ADD_ALL.Location = new System.Drawing.Point(503, 183);
            this.ADD_ALL.Name = "ADD_ALL";
            this.ADD_ALL.Size = new System.Drawing.Size(139, 21);
            this.ADD_ALL.TabIndex = 28;
            this.ADD_ALL.Text = "存储所有照片";
            this.ADD_ALL.UseVisualStyleBackColor = true;
            this.ADD_ALL.Visible = false;
            this.ADD_ALL.Click += new System.EventHandler(this.ADD_ALL_Click);
            // 
            // count_lbl
            // 
            this.count_lbl.AutoSize = true;
            this.count_lbl.Location = new System.Drawing.Point(569, 276);
            this.count_lbl.Name = "count_lbl";
            this.count_lbl.Size = new System.Drawing.Size(47, 12);
            this.count_lbl.TabIndex = 27;
            this.count_lbl.Text = "计数: 0";
            // 
            // Single_btn
            // 
            this.Single_btn.Location = new System.Drawing.Point(569, 271);
            this.Single_btn.Name = "Single_btn";
            this.Single_btn.Size = new System.Drawing.Size(107, 21);
            this.Single_btn.TabIndex = 26;
            this.Single_btn.Text = "准备记录";
            this.Single_btn.UseVisualStyleBackColor = true;
            this.Single_btn.Visible = false;
            this.Single_btn.Click += new System.EventHandler(this.Single_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(462, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "选项";
            // 
            // RECORD_BTN
            // 
            this.RECORD_BTN.Location = new System.Drawing.Point(461, 271);
            this.RECORD_BTN.Name = "RECORD_BTN";
            this.RECORD_BTN.Size = new System.Drawing.Size(102, 21);
            this.RECORD_BTN.TabIndex = 23;
            this.RECORD_BTN.Text = "开始记录50张脸";
            this.RECORD_BTN.UseVisualStyleBackColor = true;
            this.RECORD_BTN.Click += new System.EventHandler(this.RECORD_BTN_Click);
            // 
            // NAME_PERSON
            // 
            this.NAME_PERSON.Location = new System.Drawing.Point(518, 228);
            this.NAME_PERSON.Name = "NAME_PERSON";
            this.NAME_PERSON.Size = new System.Drawing.Size(149, 21);
            this.NAME_PERSON.TabIndex = 22;
            this.NAME_PERSON.Text = "PERSON1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "用户名:";
            // 
            // face_PICBX
            // 
            this.face_PICBX.Location = new System.Drawing.Point(461, 15);
            this.face_PICBX.Name = "face_PICBX";
            this.face_PICBX.Size = new System.Drawing.Size(209, 189);
            this.face_PICBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.face_PICBX.TabIndex = 17;
            this.face_PICBX.TabStop = false;
            // 
            // image_PICBX
            // 
            this.image_PICBX.Location = new System.Drawing.Point(12, 15);
            this.image_PICBX.Name = "image_PICBX";
            this.image_PICBX.Size = new System.Drawing.Size(441, 317);
            this.image_PICBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_PICBX.TabIndex = 16;
            this.image_PICBX.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxConfirmPassword);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 69);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请输入密码:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(459, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "小提示:请多添加照片,";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(501, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "以提高识别的成功率!";
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ADD_ALL);
            this.Controls.Add(this.count_lbl);
            this.Controls.Add(this.Single_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RECORD_BTN);
            this.Controls.Add(this.NAME_PERSON);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.face_PICBX);
            this.Controls.Add(this.image_PICBX);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSignIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignInForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignInForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.face_PICBX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSignIn;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxConfirmPassword;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ADD_ALL;
        private System.Windows.Forms.Label count_lbl;
        private System.Windows.Forms.Button Single_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RECORD_BTN;
        private System.Windows.Forms.TextBox NAME_PERSON;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox face_PICBX;
        private System.Windows.Forms.PictureBox image_PICBX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
	}
}