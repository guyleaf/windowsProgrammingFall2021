using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing
{
    public class ElfinForm : Form
    {
        private const int WINDOW_WIDTH = 400;
        private const int WINDOW_HEIGHT = 400;
        private const int BALL_SIZE = 50;

        public ElfinForm()
        {
            SetClientSizeCore(WINDOW_WIDTH, WINDOW_HEIGHT);
            BackColor = Color.Black;
            Text = "Elfin";
        }

        /// <summary>
        /// 畫圖 event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            FillShapes(e.Graphics);
            DrawShapes(e.Graphics);
        }

        /// <summary>
        /// 畫圖形 (填滿)
        /// </summary>
        /// <param name="e"></param>
        private void FillShapes(Graphics g)
        {
            // Three blue blocks 
            g.FillRectangle(Brushes.Blue, 0, 0, 150, 100);
            g.FillRectangle(Brushes.Blue, 0, 250, 150, 150);
            g.FillRectangle(Brushes.Blue, 300, 0, 100, 275);

            // The elfin 
            g.FillPie(Brushes.Yellow, 15, 115, 120, 120, 30.0f, 300.0f);
            g.FillEllipse(Brushes.Black, 75, 130, 20, 20);

            // Five balls 
            g.FillEllipse(Brushes.GreenYellow, 200, 25, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 125, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 225, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 200, 325, BALL_SIZE, BALL_SIZE);
            g.FillEllipse(Brushes.GreenYellow, 300, 325, BALL_SIZE, BALL_SIZE);
        }

        /// <summary>
        /// 畫圖形 (線)
        /// </summary>
        /// <param name="g"></param>
        private void DrawShapes(Graphics g)
        {
            Pen thickPen = new Pen(Color.Purple, 7.0f);

            // Give a border to each ball 
            g.DrawEllipse(thickPen, 200, 25, BALL_SIZE, BALL_SIZE);
            g.DrawEllipse(thickPen, 200, 125, BALL_SIZE, BALL_SIZE);
            g.DrawEllipse(thickPen, 200, 225, BALL_SIZE, BALL_SIZE);
            g.DrawEllipse(thickPen, 200, 325, BALL_SIZE, BALL_SIZE);
            g.DrawEllipse(thickPen, 300, 325, BALL_SIZE, BALL_SIZE);

            // Change the color of pan to pink 
            thickPen.Color = Color.Pink;

            // Create walls 
            g.DrawRectangle(thickPen, 0, 0, 150, 100);
            g.DrawRectangle(thickPen, 0, 250, 150, 150);
            g.DrawRectangle(thickPen, 300, 0, 100, 275);
        }
    }
}
