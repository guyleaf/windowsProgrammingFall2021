using DrawingModel;

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace DrawingApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Model _model;
        private readonly PresentationModel.PresentationModel _presentationModel;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clearButton.Click += HandleClearButtonClick;
            _model.ModelChanged += HandleModelChanged;
        }

        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerPressed(
                GetCanvasPointX(e), GetCanvasPointY(e));
        }

        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerReleased(
                GetCanvasPointX(e), GetCanvasPointY(e));
        }

        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.PointerMoved(
                GetCanvasPointX(e), GetCanvasPointY(e));
        }

        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }

        private double GetCanvasPointX(PointerRoutedEventArgs e)
        {
            return GetCanvasPoint(e).X;
        }

        private double GetCanvasPointY(PointerRoutedEventArgs e)
        {
            return GetCanvasPoint(e).Y;
        }

        private Point GetCanvasPoint(PointerRoutedEventArgs e)
        {
            return e.GetCurrentPoint(_canvas).Position;
        }
    }
}
