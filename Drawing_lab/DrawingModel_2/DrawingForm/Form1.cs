using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form1 : Form
    {
        private DrawingModel.Model _model;
        private PresentationModel.PresentationModel _presentationModel;
        private readonly Panel _canvas;

        public Form1()
        {
            InitializeComponent();
            _canvas = new DoubleBufferedPanel();

            // prepare canvas
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            // prepare clear button
            Button clear = new Button();
            clear.Text = "Clear";
            clear.Dock = DockStyle.Top;
            clear.AutoSize = true;
            clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            clear.Click += HandleClearButtonClick;
            Controls.Add(clear);

            // prepare presentation model and model
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model,
           _canvas);
            _model.ModelChanged += HandleModelChanged;
        }

        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }

        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
