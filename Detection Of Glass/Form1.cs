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
using System.Diagnostics;

namespace Detection_Of_Glass
{
    public partial class Form1 : Form
    {
        string[] imagePath = new string[5];
        bool a, b, c, d;
        public Form1()
        {
            a = b = c = d = false;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) //给第一个框添加图片
        {
            string filePath;
            string fileName;
            string fileExtension;
            string[] strExtension = new string[] { ".jpg",".jpeg",".bmp",".png",".bmp"};

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
   
            //初始化打开文件夹位置
            openFileDialog1.InitialDirectory = "C:\\Users\\Crow\\Desktop";
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "All files (*.*)|*.*";
            //显示在Dialg中的Files of Type的选择  
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径 和文件名字  
                filePath = openFileDialog1.FileName;
                fileName = Path.GetFileName(filePath);
                // 获取文件后缀  
                fileExtension = Path.GetExtension(filePath);
                //设置一个text控件，显示更新txtShow的显示内容  
                //txtShow.Text = fileName;

                if (!strExtension.Contains(fileExtension))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.gif, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    sourceImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image tmp = Image.FromFile(filePath);
                    imagePath[1] = filePath;
                    a = true;
                    sourceImage1.Image = tmp;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请稍等");
            string argument = " ";
            if (a) argument += imagePath[1];
            argument += " ";
            if (b) argument += imagePath[2];
            argument += " ";
            if (c) argument += imagePath[3];
            argument += " ";
            if (d) argument += imagePath[4];
            Console.WriteLine(argument);
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "opencvTest.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = argument;
                myProcess.Start();
                myProcess.WaitForExit();
            }
            catch (Exception s)
            {
                Console.WriteLine(s.Message);
            }
            Image tmp1 = Image.FromFile("result1.jpg");
            showImage1.SizeMode = PictureBoxSizeMode.StretchImage;
            showImage1.Image = tmp1;

            Image tmp2 = Image.FromFile("result2.jpg");
            showImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            showImage2.Image = tmp2;

            Image tmp3 = Image.FromFile("result3.jpg");
            showImage3.SizeMode = PictureBoxSizeMode.StretchImage;
            showImage3.Image = tmp3;

            Image tmp4 = Image.FromFile("result4.jpg");
            showImage4.SizeMode = PictureBoxSizeMode.StretchImage;
            showImage4.Image = tmp4;
            //textBox1.AppendText("单位：厘米\n");
            StreamReader sr = new StreamReader("output_circle_size.txt",Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                textBox1.AppendText(line);
                textBox1.AppendText("\n");
            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e) //第二个画框添加图片
        {
            string filePath;
            string fileName;
            string fileExtension;
            string[] strExtension = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".bmp" };

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //初始化打开文件夹位置
            openFileDialog1.InitialDirectory = "C:\\Users\\Crow\\Desktop";
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "All files (*.*)|*.*";
            //显示在Dialg中的Files of Type的选择  
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径 和文件名字  
                filePath = openFileDialog1.FileName;
                fileName = Path.GetFileName(filePath);
                // 获取文件后缀  
                fileExtension = Path.GetExtension(filePath);
                //设置一个text控件，显示更新txtShow的显示内容  
                //txtShow.Text = fileName;

                if (!strExtension.Contains(fileExtension))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.gif, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    sourceImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image tmp = Image.FromFile(filePath);
                    imagePath[2] = filePath;
                    b = true;
                    sourceImage2.Image = tmp;
                }
            }
        }

        private void sourceImage1_Click(object sender, EventArgs e)
        {

        }

        private void addButton4_Click(object sender, EventArgs e) //给第四个框添加图片
        {
            string filePath;
            string fileName;
            string fileExtension;
            string[] strExtension = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".bmp" };

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //初始化打开文件夹位置
            openFileDialog1.InitialDirectory = "C:\\Users\\Crow\\Desktop";
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "All files (*.*)|*.*";
            //显示在Dialg中的Files of Type的选择  
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径 和文件名字  
                filePath = openFileDialog1.FileName;
                fileName = Path.GetFileName(filePath);
                // 获取文件后缀  
                fileExtension = Path.GetExtension(filePath);
                //设置一个text控件，显示更新txtShow的显示内容  
                //txtShow.Text = fileName;

                if (!strExtension.Contains(fileExtension))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.gif, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    sourceImage4.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image tmp = Image.FromFile(filePath);
                    imagePath[4] = filePath;
                    d = true;
                    sourceImage4.Image = tmp;
                }
            }
        }

        private void addButton3_Click(object sender, EventArgs e) //给第三个画框添加图片
        {
            string filePath;
            string fileName;
            string fileExtension;
            string[] strExtension = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".bmp" };

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //初始化打开文件夹位置
            openFileDialog1.InitialDirectory = "C:\\Users\\Crow\\Desktop";
            //Filter 允许打开文件的格式  显示在Dialg中的Files of Type  
            openFileDialog1.Filter = "All files (*.*)|*.*";
            //显示在Dialg中的Files of Type的选择  
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Choose Image File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //文件路径 和文件名字  
                filePath = openFileDialog1.FileName;
                fileName = Path.GetFileName(filePath);
                // 获取文件后缀  
                fileExtension = Path.GetExtension(filePath);
                //设置一个text控件，显示更新txtShow的显示内容  
                //txtShow.Text = fileName;

                if (!strExtension.Contains(fileExtension))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.gif, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    sourceImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image tmp = Image.FromFile(filePath);
                    imagePath[3] = filePath;
                    c = true;
                    sourceImage3.Image = tmp;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
