namespace FacialSecurity
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnDelRecord = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCopyPassword = new System.Windows.Forms.Button();
            this.btn_DeleteAll_Picture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(294, 92);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(115, 23);
            this.btnAddRecord.TabIndex = 0;
            this.btnAddRecord.Text = "增加账号密码信息";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnDelRecord
            // 
            this.btnDelRecord.Location = new System.Drawing.Point(303, 242);
            this.btnDelRecord.Name = "btnDelRecord";
            this.btnDelRecord.Size = new System.Drawing.Size(75, 23);
            this.btnDelRecord.TabIndex = 1;
            this.btnDelRecord.Text = "删除";
            this.btnDelRecord.UseVisualStyleBackColor = true;
            this.btnDelRecord.Click += new System.EventHandler(this.btnDelRecord_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(240, 328);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.Location = new System.Drawing.Point(294, 159);
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(115, 23);
            this.btnCopyPassword.TabIndex = 3;
            this.btnCopyPassword.Text = "复制选中密码";
            this.btnCopyPassword.UseVisualStyleBackColor = true;
            this.btnCopyPassword.Click += new System.EventHandler(this.btnCopyPassword_Click);
            // 
            // btn_DeleteAll_Picture
            // 
            this.btn_DeleteAll_Picture.Location = new System.Drawing.Point(294, 300);
            this.btn_DeleteAll_Picture.Name = "btn_DeleteAll_Picture";
            this.btn_DeleteAll_Picture.Size = new System.Drawing.Size(137, 23);
            this.btn_DeleteAll_Picture.TabIndex = 4;
            this.btn_DeleteAll_Picture.Text = "删除用户已存储的照片";
            this.btn_DeleteAll_Picture.UseVisualStyleBackColor = true;
            this.btn_DeleteAll_Picture.Click += new System.EventHandler(this.btn_DeleteAll_Picture_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 399);
            this.Controls.Add(this.btn_DeleteAll_Picture);
            this.Controls.Add(this.btnCopyPassword);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelRecord);
            this.Controls.Add(this.btnAddRecord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAddRecord;
		private System.Windows.Forms.Button btnDelRecord;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnCopyPassword;
        private System.Windows.Forms.Button btn_DeleteAll_Picture;



	}
}

