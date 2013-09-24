using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacialSecurity
{
	public partial class AddRecordForm : Form
	{
		public AddRecordForm()
		{
			InitializeComponent();
		}

		private void btnGeneratePassword_Click(object sender, EventArgs e)
		{
			//todo::随机生成密码放入genPasswordStr
			string genPasswordStr = "";//随机生成的密码

			var dr = MessageBox.Show("系统为您生成的密码为：" + genPasswordStr + "是否存入数据库并复制？"
													, "已生成密码"
													, MessageBoxButtons.OKCancel
													, MessageBoxIcon.Question
													, MessageBoxDefaultButton.Button2
													);

			if (dr != DialogResult.OK) return;

			//todo::把生成的密码genPasswordStr放进剪贴板，并提示
			;
			MessageBox.Show("已复制到剪贴板！");

			//todo::把密码用AES算法加密后和账号和描述一起放入数据库，并把textBoxPassword的值变成生成的密码
			var aesObj = new AES();
			;
			textBoxPassword.Text = genPasswordStr;
		}
	}
}
