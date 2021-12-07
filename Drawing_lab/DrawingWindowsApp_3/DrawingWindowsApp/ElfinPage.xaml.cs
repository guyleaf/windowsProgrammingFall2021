using System;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=234238

namespace DrawingWindowsApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class ElfinPage : Page
    {
        private const string MESSAGE = "Where is the mouse?";
        private const int CANVAS_SIZE = 400;
        private const int BALL_SIZE = 50;
        private const double STROKE_THICKNESS = 5;
        private readonly SolidColorBrush _whiteColor;
        private readonly SolidColorBrush _blueColor;
        private readonly SolidColorBrush _blackColor;
        private readonly SolidColorBrush _yellowColor;
        private readonly SolidColorBrush _greenYellowColor;
        private readonly SolidColorBrush _purpleColor;

        public ElfinPage()
        {
            this.InitializeComponent();
            _whiteColor = new SolidColorBrush(Colors.White);
            _blueColor = new SolidColorBrush(Colors.Blue);
            _blackColor = new SolidColorBrush(Colors.Black);
            _yellowColor = new SolidColorBrush(Colors.Yellow);
            _greenYellowColor = new SolidColorBrush(Colors.GreenYellow);
            _purpleColor = new SolidColorBrush(Colors.Purple);

            _canvas.Width = CANVAS_SIZE;
            _canvas.Height = CANVAS_SIZE;
            _canvas.Background = _whiteColor;
            _canvas.PointerPressed += PressOnCanvas;
            _canvas.PointerMoved += MoveOnCanvas;

            _textBlock.Text = MESSAGE;

            _grid.Background = _blackColor;

            // Three blue blocks
            var rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 0, 150, 100, _blueColor);
            _canvas.Children.Insert(0, rectangle);

            rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 250, 150, 150, _blueColor);
            _canvas.Children.Insert(0, rectangle);

            rectangle = new Rectangle();
            InitializeShape(rectangle, 300, 0, 100, 275, _blueColor);
            _canvas.Children.Insert(0, rectangle);

            // Five balls
            var ellipse = new Ellipse();
            InitializeShape(
                ellipse, 200, 25, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Insert(0, ellipse);

            ellipse = new Ellipse();
            InitializeShape(
                ellipse, 200, 125, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Insert(0, ellipse);

            ellipse = new Ellipse();
            InitializeShape(
                ellipse, 200, 225, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Insert(0, ellipse);

            ellipse = new Ellipse();
            InitializeShape(
                ellipse, 200, 325, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Insert(0, ellipse);

            ellipse = new Ellipse();
            InitializeShape(
                ellipse, 300, 325, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Insert(0, ellipse);
        }

        private void MoveOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double moveX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double moveY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You moved on (" + moveX + ", " + moveY + ")";
        }

        private void PressOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double pressX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double pressY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You pressed on (" + pressX + ", " + pressY + ")";
        }

        private Shape InitializeShape(
            Shape shape, int left, int top, int width, int height, SolidColorBrush fillColorBrush)
        {
            shape.Margin = new Thickness(left, top, width, height);
            shape.Width = width;
            shape.Height = height;
            shape.Fill = fillColorBrush;
            shape.Stroke = _purpleColor;
            shape.StrokeThickness = STROKE_THICKNESS;
            return shape;
        }
    }
}
