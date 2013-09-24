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
	public partial class FaceRecognitionLoginForm : Form
	{
		public bool HasLoggedOn { get; private set; }

		public FaceRecognitionLoginForm()
		{
			InitializeComponent();
			HasLoggedOn = false;//默认未登陆

			var iniMgr = new CIniManager(@"Config\Admin.ini");
			if (!iniMgr.ExistIniFile())//若配置文件不存在则退出
			{
				MessageBox.Show("缺少配置文件");
				Environment.Exit(Environment.ExitCode);
			}
			if (iniMgr.IniReadValue("FacialSecurity","Signed") == "false")
			{
				btnLogin.Enabled = false;//若没注册则没法登陆
			}
		}

		private void linkLabelForPasswordLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var pwLoginForm = new PasswordLoginForm();//密码登陆对话框
			var forMD5 = new KeysFactory();//MD5转换对象

			pwLoginForm.ShowDialog();

			while (pwLoginForm.DialogResult == DialogResult.OK)//若点了密码登陆框的确定
			{
				//todo::根据pwLoginForm的成员textBoxPassword的内容转换成MD5码，与数据库中的MD5密码比对，若相同则通过并把HasLoggedOn赋值true
				//随便写的显示MD5转换结果=.=
				MessageBox.Show(forMD5.TransToMD5String(pwLoginForm.TextBoxPasswordContent));

				if (true/*这里写比对代码，若比对成功则if成立*/)
				{
					HasLoggedOn = true;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("密码错误！");
					pwLoginForm.ShowDialog();
				}
			}
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			//todo::用摄像头拍一张照片对比，成功则HasLoggedOn设true
			if (true/*对比成功代码*/)
			{
				HasLoggedOn = true;
			}
		}

		private void btnSignIn_Click(object sender, EventArgs e)
		{
			var signDlg = new SignInForm();
			signDlg.ShowDialog();

			if (signDlg.DialogResult == DialogResult.OK)
			{
				var iniMgr = new CIniManager(@"Config\Admin.ini");
				if (iniMgr.ExistIniFile() && iniMgr.IniReadValue("FacialSecurity","Signed") == "true")//验证配置文件
				{
					btnLogin.Enabled = true;
				}
			}
		}
	}
}
