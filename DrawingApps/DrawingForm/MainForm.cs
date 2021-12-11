using DrawingForm.Models;

using DrawingModel.Interfaces;

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
    public partial class MainForm : Form
    {
        private readonly FormPresentationModel _formPresentationModel;
        private readonly IModel _model;

        public MainForm(FormPresentationModel formPresentationModel, IModel model)
        {
            InitializeComponent();
            _formPresentationModel = formPresentationModel;
            _model = model;

            _rectangleDrawingButton.Click += HandleRectangleButtonOnClick;
            _ellipseDrawingButton.Click += HandleEllipseButtonOnClick;
            _clearButton.Click += HandleClearButtonOnClick;

            var enabledName = nameof(Enabled);
            _rectangleDrawingButton.DataBindings.Add(
                enabledName, _formPresentationModel, nameof(_formPresentationModel.IsRectangleButtonEnabled));
            _ellipseDrawingButton.DataBindings.Add(
                enabledName, _formPresentationModel, nameof(_formPresentationModel.IsEllipseButtonEnabled));

            _canvas.MouseDown += HandleCanvasOnMouseDown;
            _canvas.MouseUp += HandleCanvasOnMouseUp;
            _canvas.MouseMove += HandleCanvasOnMouseMove;
            _canvas.Paint += HandleCanvasOnPaint;

            _model._modelChanged += HandleModelOnModelChanged;
        }

        private void HandleRectangleButtonOnClick(object sender, EventArgs e)
        {
            _formPresentationModel.ClickRectangleButton();
        }

        private void HandleEllipseButtonOnClick(object sender, EventArgs e)
        {
            _formPresentationModel.ClickEllipseButton();
        }

        private void HandleClearButtonOnClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        private void HandleCanvasOnMouseDown(object sender, MouseEventArgs e)
        {
            _formPresentationModel.PressPointer(e.X, e.Y);
        }

        private void HandleCanvasOnMouseUp(object sender, MouseEventArgs e)
        {
            _formPresentationModel.ReleasePointer(e.X, e.Y);
        }

        private void HandleCanvasOnMouseMove(object sender, MouseEventArgs e)
        {
            _formPresentationModel.MovePointer(e.X, e.Y);
        }

        private void HandleCanvasOnPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new FormGraphicsAdapter(e.Graphics));
        }

        private void HandleModelOnModelChanged()
        {
            _canvas.Invalidate(true);
        }
    }
}
