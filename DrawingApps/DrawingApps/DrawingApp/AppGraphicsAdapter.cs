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
        private const int MARGIN_RIGHT_AND_BOTTOM = 0;
        private readonly Canvas _canvas;
        private readonly Brush _blackBrush;
        private readonly Brush _brushForRectangle;
        private readonly Brush _brushForEllipse;

        public AppGraphicsAdapter(Canvas canvas)
        {
            _canvas = canvas;
            _blackBrush = new SolidColorBrush(Colors.Black);
            _brushForRectangle = new SolidColorBrush(Colors.Yellow);
            _brushForEllipse = new SolidColorBrush(Colors.Orange);
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
        /// TODO: Change to use Rectangle with dashed format
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void DrawDashedLine(double x1, double y1, double x2, double y2)
        {
            // 無解 已知 bug 在 code 建立 Dashed Line 會有問題
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
                Y2 = y2
            };

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
    }
}
