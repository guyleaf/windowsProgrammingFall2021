using DrawingApp.Models;

using DrawingForm;

using DrawingModel.Interfaces;

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly AppPresentationModel _appPresentationModel;
        private readonly IModel _model;
        private readonly IGraphics _graphics;

        public MainPage(AppPresentationModel appPresentationModel, IModel model)
        {
            InitializeComponent();
            _appPresentationModel = appPresentationModel;
            _model = model;
            _graphics = new AppGraphicsAdapter(_canvas);

            _rectangleDrawingButton.Click += HandleRectangleButtonOnClick;
            _ellipseDrawingButton.Click += HandleEllipseButtonOnClick;
            _clearButton.Click += HandleClearButtonOnClick;

            var dataBinding = new Binding
            { 
                Source = _appPresentationModel,
                Path = new PropertyPath(nameof(_appPresentationModel.IsRectangleButtonEnabled)) };
            _rectangleDrawingButton.SetBinding(IsEnabledProperty, dataBinding);

            dataBinding = new Binding
            { 
                Source = _appPresentationModel,
                Path = new PropertyPath(nameof(_appPresentationModel.IsEllipseButtonEnabled)) };
            _ellipseDrawingButton.SetBinding(IsEnabledProperty, dataBinding);

            _canvas.PointerPressed += HandleCanvasOnMouseDown;
            _canvas.PointerMoved += HandleCanvasOnMouseMove;
            _canvas.PointerReleased += HandleCanvasOnMouseUp;

            _model._modelChanged += HandleModelOnModelChanged;
        }

        /// <summary>
        /// 處理 Rectangle Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleRectangleButtonOnClick(object sender, RoutedEventArgs e)
        {
            _appPresentationModel.ClickRectangleButton();
        }

        /// <summary>
        /// 處理 Ellipse Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleEllipseButtonOnClick(object sender, RoutedEventArgs e)
        {
            _appPresentationModel.ClickEllipseButton();
        }

        /// <summary>
        /// 處理 Clear Button 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClearButtonOnClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        /// <summary>
        /// 處理 Canvas 的 MouseDown 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseDown(object sender, PointerRoutedEventArgs e)
        {
            var point = GetCurrentPointOnCanvas(e);
            _appPresentationModel.PressPointer(point.X, point.Y);
        }

        // <summary>
        /// 處理 Canvas 的 MouseUp 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseUp(object sender, PointerRoutedEventArgs e)
        {
            var point = GetCurrentPointOnCanvas(e);
            _appPresentationModel.ReleasePointer(point.X, point.Y);
        }

        // <summary>
        /// 處理 Canvas 的 MouseMove 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasOnMouseMove(object sender, PointerRoutedEventArgs e)
        {
            var point = GetCurrentPointOnCanvas(e);
            _appPresentationModel.MovePointer(point.X, point.Y);
        }

        // <summary>
        /// 處理 Model 的 ModelChanged 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleModelOnModelChanged()
        {
            _model.Draw(_graphics);
        }

        /// <summary>
        /// 取得目前 Pointer 在 Canvas 的所在位置
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private Point GetCurrentPointOnCanvas(PointerRoutedEventArgs e)
        {
            return e.GetCurrentPoint(_canvas).Position;
        }
    }
}
