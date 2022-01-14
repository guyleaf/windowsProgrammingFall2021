using DrawingForm.Models;

using DrawingModel.Interfaces;

using System;
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

            InitializeButtons();

            var enabledName = nameof(Enabled);
            _rectangleDrawingButton.DataBindings.Add(
                enabledName, _formPresentationModel, nameof(_formPresentationModel.IsRectangleButtonEnabled));
            _ellipseDrawingButton.DataBindings.Add(
                enabledName, _formPresentationModel, nameof(_formPresentationModel.IsEllipseButtonEnabled));
            _lineDrawingButton.DataBindings.Add(
                enabledName, _formPresentationModel, nameof(_formPresentationModel.IsLineButtonEnabled));

            _canvas.MouseDown += HandleCanvasOnMouseDown;
            _canvas.MouseUp += HandleCanvasOnMouseUp;
            _canvas.MouseMove += HandleCanvasOnMouseMove;
            _canvas.Paint += HandleCanvasOnPaint;

            _model._modelChanged += HandleModelOnModelChanged;
        }

        /// <summary>
        /// 初始化按鈕
        /// </summary>
        private void InitializeButtons()
        {
            _rectangleDrawingButton.Click += HandleRectangleButtonOnClick;
            _ellipseDrawingButton.Click += HandleEllipseButtonOnClick;
            _lineDrawingButton.Click += HandleLineButtonOnClick;
            _clearButton.Click += HandleClearButtonOnClick;

            _undoButton.Click += HandleUndoButtonOnClick;
            _redoButton.Click += HandleRedoButtonOnClick;
        }

        /// <summary>
        /// 處理 Undo Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleUndoButtonOnClick(object sender, EventArgs e)
        {
            _model.Undo();
        }

        /// <summary>
        /// 處理 Redo Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleRedoButtonOnClick(object sender, EventArgs e)
        {
            _model.Redo();
        }

        /// <summary>
        /// 處理 Rectangle Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleRectangleButtonOnClick(object sender, EventArgs e)
        {
            _formPresentationModel.ClickRectangleButton();
        }

        /// <summary>
        /// 處理 Ellipse Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleEllipseButtonOnClick(object sender, EventArgs e)
        {
            _formPresentationModel.ClickEllipseButton();
        }

        /// <summary>
        /// 處理 Line Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleLineButtonOnClick(object sender, EventArgs e)
        {
            _formPresentationModel.ClickLineButton();
        }

        /// <summary>
        /// 處理 Clear Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClearButtonOnClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        /// <summary>
        /// 處理 Canvas 的 MouseDown 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseDown(object sender, MouseEventArgs e)
        {
            _formPresentationModel.PressPointer(e.X, e.Y);
        }

        // <summary>
        /// 處理 Canvas 的 MouseUp 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseUp(object sender, MouseEventArgs e)
        {
            _formPresentationModel.ReleasePointer(e.X, e.Y);
        }

        // <summary>
        /// 處理 Canvas 的 MouseMove 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseMove(object sender, MouseEventArgs e)
        {
            _formPresentationModel.MovePointer(e.X, e.Y);
        }

        // <summary>
        /// 處理 Canvas 的 Paint 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new FormGraphicsAdapter(e.Graphics));
        }

        // <summary>
        /// 處理 Model 的 ModelChanged 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleModelOnModelChanged()
        {
            _canvas.Invalidate(true);
            _undoButton.Enabled = _model.IsAnyShapeDisplayed;
            _redoButton.Enabled = _model.IsAnyShapeRemoved;
        }
    }
}
