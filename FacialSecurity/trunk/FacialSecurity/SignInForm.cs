﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FacialSecurity
{
	public partial class SignInForm : Form
	{
        #region 变量
        //Camera specific
        Capture grabber;

        //Images for finding face
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result = null;
        Image<Gray, byte> gray_frame = null;

        //Classifier
        CascadeClassifier Face;

        //For aquiring 10 images in a row
        List<Image<Gray, byte>> resultImages = new List<Image<Gray, byte>>();
        int results_list_pos = 0;
        int num_faces_to_aquire = 50;
        bool RECORD = false;

        //Saving Jpg
        List<Image<Gray, byte>> ImagestoWrite = new List<Image<Gray, byte>>();
        EncoderParameters ENC_Parameters = new EncoderParameters(1);
        EncoderParameter ENC = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);
        ImageCodecInfo Image_Encoder_JPG;

        //Saving XAML Data file
        List<string> NamestoWrite = new List<string>();
        List<string> NamesforFile = new List<string>();
        XmlDocument docu = new XmlDocument();

        //Variables
        FaceRecognitionLoginForm Parent;

	    private bool IsOpenWebcam = false;

        #endregion

        #region 构造函数（初始化一些数据）
        public SignInForm(FaceRecognitionLoginForm _Parent)
		{
            InitializeComponent();
            //设定密码的掩码符号
            textBoxPassword.PasswordChar = '*';
            textBoxConfirmPassword.PasswordChar = '*';

            Parent = _Parent;
            Face = Parent.Face;
            //Face = new HaarCascade(Application.StartupPath + "/Cascades/haarcascade_frontalface_alt2.xml");
            ENC_Parameters.Param[0] = ENC;
            Image_Encoder_JPG = GetEncoder(ImageFormat.Jpeg);
            initialise_capture();
		}
        #endregion]      

        //Camera Start Stop
        public void initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            IsOpenWebcam = !IsOpenWebcam; //摄像机打开
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }
        private void stop_capture()
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (grabber != null)
            {
                grabber.Dispose();
            }
            IsOpenWebcam = !IsOpenWebcam;
            //Initialize the FrameGraber event
        }

        //Process Frame
        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                //MCvAvgComp[][] facesDetected = gray_frame.DetectHaarCascade(Face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20)); //old method
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
                    face_PICBX.Image = result.ToBitmap();
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                }
                if (RECORD && facesDetected.Length > 0 && resultImages.Count < num_faces_to_aquire)
                {
                    resultImages.Add(result);
                    count_lbl.Text = "计数: " + resultImages.Count.ToString();
                    if (resultImages.Count == num_faces_to_aquire)
                    {
                     //   ADD_BTN.Enabled = true;
                     //   NEXT_BTN.Visible = true;
                     //   PREV_btn.Visible = true;
                        count_lbl.Visible = false;
                        Single_btn.Visible = true;
                        ADD_ALL.Visible = true;
                        RECORD = false;
                        Store_All_Picture(); //存储所有照片
                        Application.Idle -= new EventHandler(FrameGrabber);
                    }
                }

                image_PICBX.Image = currentFrame.ToBitmap();
            }
        }

      
        //Saving The Data
        private bool save_training_data(Image face_data)
        {
            try
            {
                Random rand = new Random();
                bool file_create = true;
                string facename = "face_" + NAME_PERSON.Text + "_" + rand.Next().ToString() + ".jpg";
                while (file_create)
                {

                    if (!File.Exists(Application.StartupPath + "/TrainedFaces/" + facename))
                    {
                        file_create = false;
                    }
                    else
                    {
                        facename = "face_" + NAME_PERSON.Text + "_" + rand.Next().ToString() + ".jpg";
                    }
                }


                if (Directory.Exists(Application.StartupPath + "/TrainedFaces/"))
                {
                    face_data.Save(Application.StartupPath + "/TrainedFaces/" + facename, ImageFormat.Jpeg);
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "/TrainedFaces/");
                    face_data.Save(Application.StartupPath + "/TrainedFaces/" + facename, ImageFormat.Jpeg);
                }
                if (File.Exists(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml"))
                {
                    //File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", NAME_PERSON.Text + "\n\r");
                    bool loading = true;
                    while (loading)
                    {
                        try
                        {
                            docu.Load(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                            loading = false;
                        }
                        catch
                        {
                            docu = null;
                            docu = new XmlDocument();
                            Thread.Sleep(10);
                        }
                    }

                    //Get the root element
                    XmlElement root = docu.DocumentElement;

                    XmlElement face_D = docu.CreateElement("FACE");
                    XmlElement name_D = docu.CreateElement("NAME");
                    XmlElement file_D = docu.CreateElement("FILE");

                    //Add the values for each nodes
                    //name.Value = textBoxName.Text;
                    //age.InnerText = textBoxAge.Text;
                    //gender.InnerText = textBoxGender.Text;
                    name_D.InnerText = NAME_PERSON.Text;
                    file_D.InnerText = facename;

                    //Construct the Person element
                    //person.Attributes.Append(name);
                    face_D.AppendChild(name_D);
                    face_D.AppendChild(file_D);

                    //Add the New person element to the end of the root element
                    root.AppendChild(face_D);

                    //Save the document
                    docu.Save(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                    //XmlElement child_element = docu.CreateElement("FACE");
                    //docu.AppendChild(child_element);
                    //docu.Save("TrainedLabels.xml");
                }
                else
                {
                    FileStream FS_Face = File.OpenWrite(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                    using (XmlWriter writer = XmlWriter.Create(FS_Face))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Faces_For_Training");

                        writer.WriteStartElement("FACE");
                        writer.WriteElementString("NAME", NAME_PERSON.Text);
                        writer.WriteElementString("FILE", facename);
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    FS_Face.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        //Delete all the old training data by simply deleting the folder
   /*     private void Delete_Data_BTN_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "/TrainedFaces/"))
            {
                Directory.Delete(Application.StartupPath + "/TrainedFaces/", true);
                Directory.CreateDirectory(Application.StartupPath + "/TrainedFaces/");
                MessageBox.Show("已经成功删除所有原来的用户脸部照片!");
            }
        }
    */
        #region 按钮等响应事件
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            else if (textBoxConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！");
                return;
            }
            else if (textBoxPassword.Text != textBoxConfirmPassword.Text)
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
            iniMgr.IniWriteValue("FacialSecurity", "Signed", "true");

            btnCancel_Click(sender, e);
        }
        //关闭窗体事件
        private void SignInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_capture();
            Parent.retrain();
            Parent.initialise_capture();
        }
  
        //Add the image to training data
   /*     private void ADD_BTN_Click(object sender, EventArgs e)
        {
            if (resultImages.Count == num_faces_to_aquire)
            {
                if (!save_training_data(face_PICBX.Image)) MessageBox.Show("Error", "Error in saving file info. Training data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("已经成功添加改脸部照片!");
                }
            }
            else
            {
                stop_capture();
                if (!save_training_data(face_PICBX.Image)) MessageBox.Show("Error", "Error in saving file info. Training data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("已经成功添加脸部照片!");
                }
                initialise_capture();
            }
        }
    */
        private void Single_btn_Click(object sender, EventArgs e)
        {
            RECORD = false;
            resultImages.Clear();
          //  NEXT_BTN.Visible = false;
          //  PREV_btn.Visible = false;
            Application.Idle += new EventHandler(FrameGrabber);
            Single_btn.Visible = false;
            count_lbl.Text = "计数: 0";
            count_lbl.Visible = true;
        }
        //Get 10 image to train
        private void RECORD_BTN_Click(object sender, EventArgs e)
        {
            if (RECORD)
            {
                RECORD = false;
            }
            else
            {
                if (resultImages.Count == 50)
                {
                    resultImages.Clear();                    
                    Application.Idle += new EventHandler(FrameGrabber);                   
                }
                RECORD = true;
           //     ADD_BTN.Enabled = false;
            }

        }
        /*
        private void NEXT_BTN_Click(object sender, EventArgs e)
        {
            if (results_list_pos < resultImages.Count - 1)
            {
                face_PICBX.Image = resultImages[results_list_pos].ToBitmap();
                results_list_pos++;
                PREV_btn.Enabled = true;
            }
            else
            {
                NEXT_BTN.Enabled = false;
            }
        }
        private void PREV_btn_Click(object sender, EventArgs e)
        {
            if (results_list_pos > 0)
            {
                results_list_pos--;
                face_PICBX.Image = resultImages[results_list_pos].ToBitmap();
                NEXT_BTN.Enabled = true;
            }
            else
            {
                PREV_btn.Enabled = false;
            }
        }
         */
        private void Store_All_Picture()
        {
            for (int i = 0; i < resultImages.Count; i++)
            {
                face_PICBX.Image = resultImages[i].ToBitmap();
                if (!save_training_data(face_PICBX.Image)) MessageBox.Show("Error", "Error in saving file info. Training data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.Sleep(10);
            }
            ADD_ALL.Visible = false;
            MessageBox.Show("已经成功存储所有改脸部照片!");
            //restart single face detection
            Single_btn_Click(null, null);
        }
        private void ADD_ALL_Click(object sender, EventArgs e)
        {
           Store_All_Picture();
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(IsOpenWebcam)
            {stop_capture();}
            this.Close();            
        }

    }
}
