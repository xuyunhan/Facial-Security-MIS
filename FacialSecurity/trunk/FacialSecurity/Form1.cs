using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;

namespace FacialSecurity
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "BMP文件|*.bmp|JPG文件|*.jpg|JPEG文件|*.jpeg|所有文件|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				CvInvoke.cvNamedWindow("打开图片");
				IntPtr img = CvInvoke.cvLoadImage(openFileDialog.FileName, Emgu.CV.CvEnum.LOAD_IMAGE_TYPE.CV_LOAD_IMAGE_UNCHANGED);
				CvInvoke.cvShowImage("打开图片", img);
				CvInvoke.cvWaitKey(0);
				CvInvoke.cvReleaseImage(ref img);
				CvInvoke.cvDestroyWindow("打开图片");
			}
		}
	}
}
