using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;

namespace FacialSecurity
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			var loginForm = new FaceRecognitionLoginForm();
			loginForm.ShowDialog();

			while (!loginForm.HasLoggedOn)
			{
				if (loginForm.DialogResult == DialogResult.Cancel)
				{
					//关闭整个程序
					Environment.Exit(System.Environment.ExitCode);
				}
				//MessageBox.Show("请先登录");
				loginForm.ShowDialog();
			}

			if (loginForm.DialogResult == DialogResult.OK)
			{
				//MessageBox.Show("登陆成功！");
			}
			else
			{
				Environment.Exit(System.Environment.ExitCode);
			}
		}

		private void btnCopyPassword_Click(object sender, EventArgs e)
		{
			//todo::把选中的记录的密码放进剪贴板并提示
			;
			MessageBox.Show("已复制");
		}

		private void btnAddRecord_Click(object sender, EventArgs e)
		{
			var addRecordDlg = new AddRecordForm();
			addRecordDlg.ShowDialog();
		}

		private void btnDelRecord_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(" 确定删除记录？", " 提示",  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
			{
				//todo::从数据库中删除选定的记录
				;
// 				MessageBox.Show("点了删除");
			}
		}

        private void btn_DeleteAll_Picture_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "/TrainedFaces/"))
            {
                Directory.Delete(Application.StartupPath + "/TrainedFaces/", true);
                Directory.CreateDirectory(Application.StartupPath + "/TrainedFaces/");
                MessageBox.Show("已经成功删除所有原来的用户脸部照片!");
            }
        }

	}
}
