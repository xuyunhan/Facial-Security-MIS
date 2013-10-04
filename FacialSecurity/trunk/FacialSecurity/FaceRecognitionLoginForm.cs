using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FacialSecurity
{
	public partial class FaceRecognitionLoginForm : Form
	{
		public bool HasLoggedOn { get; private set; }

        #region EmguCV变量
        Image<Bgr, Byte> currentFrame; //从摄像头的显示当前图像细节
        Image<Gray, byte> result, TrainedFace = null; //用于存储当前存摄像头获取的人脸图像及记录的用户人脸图像
        Image<Gray, byte> gray_frame = null; //处理从摄像头获取的图像,使其变灰

        Capture grabber; //捕捉变量

        public CascadeClassifier Face = new CascadeClassifier(Application.StartupPath + "/Cascades/haarcascade_frontalface_default.xml");//人脸的侦测模型

        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_COMPLEX, 0.5, 0.5); //Our fount for writing within the frame

        int NumLabels;
	    private bool IsRecognized = false; //记录是否识别成功
	    private string _StoreName = "";   //存储的用户名
	    private bool IsOpenWebcam = false;

        //Classifier with default training location
        Classifier_Train Eigen_Recog = new Classifier_Train();

        #endregion

	    private bool Isparrellel = true;

        #region 加载窗体时的初始化工作
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

            //Load of previus trainned faces and labels for each image

            if (Eigen_Recog.IsTrained)
            {
                message_bar.Text = "现在可以进行识别登陆！";
                btnSignIn.Visible = false;
            }
            else
            {
                message_bar.Text = "没有发现存储的用户脸部图像, 请先注册！";
                btnSignIn.Visible = true;
            }      
		}
        #endregion

        #region 窗体按钮等的响应事件

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
		    if (!IsRecognized)
		    {
                if (!IsOpenWebcam)
                {
                    initialise_capture();                 
                }
                else
                {
                    stop_capture();
                    initialise_capture();   
                }
		    }
		    //todo::用摄像头拍一张照片对比，成功则HasLoggedOn设true
            if (IsRecognized)
			{
				HasLoggedOn = true;
			}
		}

		private void btnSignIn_Click(object sender, EventArgs e)
		{
            //Stop Camera
            stop_capture();

            //OpenForm
            var signDlg = new SignInForm(this);
            signDlg.Show();

			if (signDlg.DialogResult == DialogResult.OK)
			{
				var iniMgr = new CIniManager(@"Config\Admin.ini");
				if (iniMgr.ExistIniFile() && iniMgr.IniReadValue("FacialSecurity","Signed") == "true")//验证配置文件
				{
					btnLogin.Enabled = true;
				}
			}          
		}
        #endregion

        
        public void retrain()
        {

            Eigen_Recog = new Classifier_Train();
            if (Eigen_Recog.IsTrained)
            {
                message_bar.Text = "现在可以进行识别登录！";
            }
            else
            {
                message_bar.Text = "没有发现存储的用户脸部图像, 请先注册！";
            }
        }
        //摄像机的开始与停止
        public void initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            if (Isparrellel)
            {
                Application.Idle += new EventHandler(FrameGrabber_Parrellel);
            }
            else
            {
                Application.Idle += new EventHandler(FrameGrabber_Standard);
            }
            IsOpenWebcam = !IsOpenWebcam;
        }
        private void stop_capture()
        {
            if (Isparrellel)
            {
                Application.Idle -= new EventHandler(FrameGrabber_Parrellel);
            }
            else
            {
                Application.Idle -= new EventHandler(FrameGrabber_Standard);
            }
            if (grabber != null)
            {
                grabber.Dispose();
            }
            IsOpenWebcam = !IsOpenWebcam;
        }
        //Process Frame
        void FrameGrabber_Standard(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                for (int i = 0; i < facesDetected.Length; i++)// (Rectangle face_found in facesDetected)
                {
                    //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                    //of the background noise
                    facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                    facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                    facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                    facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                    result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    result._EqualizeHist();
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                    if (Eigen_Recog.IsTrained)
                    {
                        string name = Eigen_Recog.Recognise(result);
                        int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                        ADD_Face_Found(result, name, match_value);
                    }
                }
                //Show the faces procesed and recognized
                image_PICBX.Image = currentFrame.ToBitmap();
            }
        }

        void FrameGrabber_Parrellel(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            //Clear_Faces_Found();

            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                Parallel.For(0, facesDetected.Length, i =>
                {
                    try
                    {
                        facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                        facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                        facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                        facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                        result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        result._EqualizeHist();
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                        if (Eigen_Recog.IsTrained)
                        {
                            string name = Eigen_Recog.Recognise(result);
                            int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                            //Draw the label for each face detected and recognized
                            currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                            _StoreName = name;
                            if (_StoreName == "Unknown")
                            {
                                _StoreName = "Unknown";
                            }
                            else if (_StoreName == "")
                            {
                                _StoreName = "Unknown";
                            }

                            if (_StoreName != "Unknown")
                              {
                                  IsRecognized = true;
                                  if (IsRecognized)
                                  {
                                      HasLoggedOn = true;
                                  }
                                 // MessageBox.Show("识别成功,请点击登陆!");        
                                  if (IsOpenWebcam)
                                  { stop_capture(); }
                                  this.DialogResult = DialogResult.OK;
                              }
                            ADD_Face_Found(result, name, match_value);
                        }

                    }
                    catch
                    {
                        //do nothing as parrellel loop buggy
                        //No action as the error is useless, it is simply an error in 
                        //no data being there to process and this occurss sporadically 
                    }
                });
                //Show the faces procesed and recognized
                image_PICBX.Image = currentFrame.ToBitmap();
               
            }
        }

        //ADD Picture box and label to a panel for each face
        int faces_count = 0;
        int faces_panel_Y = 0;
        int faces_panel_X = 0;

        void Clear_Faces_Found()
        {
            this.Faces_Found_Panel.Controls.Clear();
            faces_count = 0;
            faces_panel_Y = 0;
            faces_panel_X = 0;
        }
        void ADD_Face_Found(Image<Gray, Byte> img_found, string name_person, int match_value)
        {
            PictureBox PI = new PictureBox();
            PI.Location = new Point(faces_panel_X, faces_panel_Y);
            PI.Height = 80;
            PI.Width = 80;
            PI.SizeMode = PictureBoxSizeMode.StretchImage;
            PI.Image = img_found.ToBitmap();
            Label LB = new Label();
            LB.Text = name_person + " " + match_value.ToString();
            LB.Location = new Point(faces_panel_X, faces_panel_Y + 80);
            //LB.Width = 80;
            LB.Height = 15;

            this.Faces_Found_Panel.Controls.Add(PI);
            this.Faces_Found_Panel.Controls.Add(LB);
            faces_count++;
            if (faces_count == 2)
            {
                faces_panel_X = 0;
                faces_panel_Y += 100;
                faces_count = 0;
            }
            else faces_panel_X += 85;

            if (Faces_Found_Panel.Controls.Count > 10)
            {
                Clear_Faces_Found();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(IsOpenWebcam)
            {stop_capture();}
            this.Dispose();
        }
	}
}
