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
	public partial class SignInForm : Form
	{
		public SignInForm()
		{
			InitializeComponent();
		}

		private void btnSignIn_Click(object sender, EventArgs e)
		{
			if (textBoxPassword.Text != textBoxConfirmPassword.Text)
			{
				MessageBox.Show("两次输入密码不一致！");
				return;
			}

			//todo::拍照并人脸识别
			;

			//todo::把密码转换成MD5码放入数据库
			var MD5Obj = new MD5();
			;

			//改写配置文件
			var iniMgr = new CIniManager(@"Config\Admin.ini");
			iniMgr.IniWriteValue("FacialSecurity","Signed","true");
		}
	}
}
