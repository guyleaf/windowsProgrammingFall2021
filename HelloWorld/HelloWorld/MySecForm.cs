using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class MySecForm : Form
    {
        public MySecForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button1 點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                errorProvider.SetError(button1, "Oops~ Don't you hava a name?");
            }
            else
            {
                errorProvider.Clear();
                textBox3.Text = "Hello, " + textBox1.Text + " " + textBox2.Text + ".";
            }
        }
    }
}
