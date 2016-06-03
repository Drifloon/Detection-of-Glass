using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
 
namespace Detection_Of_Glass
{
    public partial class RustTest : Form
    {
        string filePath;
        string fileName;
        string fileExtension;
        public RustTest()
        {
            InitializeComponent();
        }

        private void RustTest_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string[] strExtension = new string[] { ".jpg", "jpeg", ".bmp", ".png" };
            OpenFileDialog openfile = new OpenFileDialog();
            //Init the open path
            openfile.Filter = "image (*.jpg)|*.jpg|image (*.bmp)|*.bmp|image (*.png)|*.png|image (*.jpeg)|*.jpeg" ;
            openfile.RestoreDirectory = true;
            openfile.Title = "Choose Image File";
            if (openfile.ShowDialog() == DialogResult.OK)
            {

                filePath = openfile.FileName;
                fileName = Path.GetFileName(filePath);
                fileExtension = Path.GetExtension(filePath);
                // textbox.Text = openfile.FileName;
                if (!strExtension.Contains(fileExtension))//验证读取文件的格式，设置为只能读取以下几种格式的图片  
                {
                    MessageBox.Show("仅打开.bmp, .jpeg, .jpg, .png格式的图片！");
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Image tmp = Image.FromFile(filePath);
                    pictureBox1.Image = tmp;
                } 
            }

             openfile.Dispose();
             
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("请先添加图片", "error");
            }
            else
            {
                string argument = " ";
                argument += filePath;
                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "RustTest.exe";
                    MessageBox.Show(filePath);
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.Arguments = argument;
                    myProcess.Start();
                    this.Hide();
                    Wait win = new Wait();
                    myProcess.WaitForExit();
                    win.Close();
                    RustTestResult rwin = new RustTestResult();
                   
                }
                catch (Exception s)
                {
                    Console.WriteLine(s.Message);
            }
            }
        }
    }
}
