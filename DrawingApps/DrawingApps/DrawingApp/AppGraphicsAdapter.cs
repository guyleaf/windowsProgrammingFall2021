using DrawingModel.Interfaces;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace DrawingForm
{
    public class AppGraphicsAdapter : IGraphics
    {
        private const double RADIUS_OF_DOT = 4;
        private const double DASHED_LINE_WIDTH = 2.5;
        private const double DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE = 3;
        private const int MARGIN_RIGHT_AND_BOTTOM = 0;
        private readonly Canvas _canvas;
        private readonly Brush _whiteBrush;
        private readonly Brush _blackBrush;
        private readonly Brush _brushForRectangle;
        private readonly Brush _brushForEllipse;
        private readonly Brush _brushForDashedRectangle;

        public AppGraphicsAdapter(Canvas canvas)
        {
            _canvas = canvas;
            _whiteBrush = new SolidColorBrush(Colors.White);
            _blackBrush = new SolidColorBrush(Colors.Black);
            _brushForRectangle = new SolidColorBrush(Colors.Yellow);
            _brushForEllipse = new SolidColorBrush(Colors.Orange);
            _brushForDashedRectangle = new SolidColorBrush(Colors.Red);
        }

        /// <summary>
        /// 清除全部
        /// </summary>
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        /// <summary>
        /// 畫橢圓形
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var ellipse = new Ellipse
            { 
                Margin = new Thickness(topLeftX, topLeftY, MARGIN_RIGHT_AND_BOTTOM, MARGIN_RIGHT_AND_BOTTOM),
                Width = bottomRightX - topLeftX,
                Height = bottomRightY - topLeftY,
                Stroke = _blackBrush,
                Fill = _brushForEllipse };

            _canvas.Children.Add(ellipse);
        }

        /// <summary>
        /// 畫虛線
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawDashedRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var rectangle = new Rectangle
            { 
                Margin = new Thickness(topLeftX, topLeftY, MARGIN_RIGHT_AND_BOTTOM, MARGIN_RIGHT_AND_BOTTOM),
                Width = bottomRightX - topLeftX,
                Height = bottomRightY - topLeftY,
                Stroke = _brushForDashedRectangle,
                StrokeDashArray = new DoubleCollection 
                { 
                    DASHED_LINE_LENGTH_BETWEEN_DASHED_LINE },
                StrokeThickness = DASHED_LINE_WIDTH,
                StrokeDashCap = PenLineCap.Triangle };

            _canvas.Children.Add(rectangle);
        }

        /// <summary>
        /// 畫實線
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            var line = new Line
            { 
                Stroke = _blackBrush,
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2 };

            _canvas.Children.Add(line);
        }

        /// <summary>
        /// 畫長方形
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        /// <param name="bottomRightX"></param>
        /// <param name="bottomRightY"></param>
        public void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            var rectangle = new Rectangle
            { 
                Margin = new Thickness(topLeftX, topLeftY, MARGIN_RIGHT_AND_BOTTOM, MARGIN_RIGHT_AND_BOTTOM),
                Width = bottomRightX - topLeftX,
                Height = bottomRightY - topLeftY,
                Stroke = _blackBrush,
                Fill = _brushForRectangle };

            _canvas.Children.Add(rectangle);
        }

        /// <summary>
        /// 畫圓點
        /// </summary>
        /// <param name="middleX"></param>
        /// <param name="middleY"></param>
        public void DrawDot(double middleX, double middleY)
        {
            var diameter = RADIUS_OF_DOT + RADIUS_OF_DOT;
            var ellipse = new Ellipse
            { 
                Margin = new Thickness(middleX - RADIUS_OF_DOT, middleY - RADIUS_OF_DOT, MARGIN_RIGHT_AND_BOTTOM, MARGIN_RIGHT_AND_BOTTOM),
                Width = diameter,
                Height = diameter,
                Stroke = _blackBrush,
                Fill = _whiteBrush };

            _canvas.Children.Add(ellipse);
        }
    }
}
