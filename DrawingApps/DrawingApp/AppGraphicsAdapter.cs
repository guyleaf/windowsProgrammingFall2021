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

        public AppGraphicsAdapter(Canvas canvas)
        {
            _canvas = canvas;
            _blackBrush = new SolidColorBrush(Colors.Black);
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
                Stroke = _blackBrush };

            _canvas.Children.Add(ellipse);
        }

        /// <summary>
        /// 畫線
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
                Stroke = _blackBrush };

            _canvas.Children.Add(rectangle);
        }
    }
}
