using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Detection_Of_Glass
{
    public partial class RustTestResult : Form
    {
        public RustTestResult()
        {
            InitializeComponent(); 
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Image tmp = Image.FromFile("rustResult.jpg");
            pictureBox1.Image = tmp;
            StreamReader sr = new StreamReader(@"rust.txt", Encoding.Default);
            string str;
            str = sr.ReadLine();
            sr.Close();

            label1.Text="该玻璃上共有"+str+"块铁锈" ;
            this.Show();
           
        }

    }
}
