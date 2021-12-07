using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public class TestEventForm : Form
    {
        private int _clickX;
        private int _clickY;
        private int _movement;
        private bool _clicked;
        private string _message;

        public TestEventForm()
        {
            _clickX = _clickY = -1;
            _movement = 0;
            _clicked = false;
            _message = "Where is the mouse?";

            Text = _message;
            SetClientSizeCore(640, 480);

            MouseClick += MouseClicked;
            MouseMove += MouseMoved;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            var font = new Font("Times New Roman", 12.0f, FontStyle.Bold);
            using (font)
            {
                // Show the location if the mouse clicked on somewhere 
                if (_clicked)
                {
                    g.DrawEllipse(Pens.Blue, _clickX - 2, _clickY - 2, 4, 4);
                    g.DrawEllipse(Pens.Blue, _clickX - 5, _clickY - 5, 10, 10);
                    g.DrawEllipse(Pens.Blue, _clickX - 8, _clickY - 8, 16, 16);
                    g.DrawString(_message, font, Brushes.Blue, _clickX, _clickY);
                }
                // Oops! The mouse disappeared! 
                else
                {
                    SizeF size = g.MeasureString(_message, font);
                    int x = (int)(ClientSize.Width - size.Width) / 2;
                    int y = (int)(ClientSize.Height - size.Height) / 2;
                    g.DrawString(_message, font, Brushes.Red, x, y);
                }
            }
        }

        private void MouseClicked(object sender, MouseEventArgs e)
        {
            _clickX = e.X;
            _clickY = e.Y;
            _message = "(" + _clickX + ", " + _clickY + ")!";
            _clicked = true;
            Invalidate();
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            _movement = Math.Abs(e.X - _clickX) + Math.Abs(e.Y - _clickY);
            if (_movement > 75)
            {
                _clicked = false;
                _message = "Where is the mouse?";
                Invalidate();
            }
        }
    }
}
