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
    public partial class BOBO : Form
    {
        string filePath;
        string fileName;
        string fileExtension;
        public BOBO()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BOBO));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(96, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 345);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(121, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(302, 447);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 42);
            this.button2.TabIndex = 3;
            this.button2.Text = "开始检测";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BOBO
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(551, 548);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "BOBO";
            this.Text = "BOBO";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private PictureBox pictureBox1;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private Button button1;
        private Button button2;

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strExtension = new string[] { ".jpg", "jpeg", ".bmp", ".png" };
            OpenFileDialog openfile = new OpenFileDialog();
            //Init the open path
            openfile.Filter = "image (*.jpg)|*.jpg|image (*.bmp)|*.bmp|image (*.png)|*.png|image (*.jpeg)|*.jpeg";
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
                    myProcess.StartInfo.FileName = "BOBO.exe";
                    //MessageBox.Show(filePath);
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
