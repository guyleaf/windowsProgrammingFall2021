using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public class MyFirstForm : Form
    {
        public MyFirstForm()
        {
            Text = "Hello, WinForms!";
            Button button = new Button()
            {
                Text = "Click Me!"
            };
            button.Click += ButtonOnClicked;
            Controls.Add(button);
        }

        /// <summary>
        /// 按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOnClicked(object sender, EventArgs e)
        {
            MessageBox.Show("That's a strong click you've got.");
        }
    }
}
