using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Detection_Of_Glass
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sizeDetection = new Form1();
            sizeDetection.Show();
            //sizeDeteciton.show(;)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RustTest rt = new RustTest();
            rt.Show();
        }
    }
}
