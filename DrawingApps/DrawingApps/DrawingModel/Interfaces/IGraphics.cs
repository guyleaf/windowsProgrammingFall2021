namespace DrawingModel.Interfaces
{
    public interface IGraphics
    {
        /// <summary>
        /// 清除全部
        /// </summary>
        void ClearAll();

        /// <summary>
        /// 繪製虛線樣式的長方形
        /// </summary>
        void DrawDashedRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY);

        /// <summary>
        /// 繪製圓點
        /// </summary>
        /// <param name="middleX"></param>
        /// <param name="middleY"></param>
        void DrawDot(double middleX, double middleY);

        /// <summary>
        /// 繪製實線
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawLine(double x1, double y1, double x2, double y2);

        /// <summary>
        /// 繪製橢圓形
        /// </summary>
        void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY);

        /// <summary>
        /// 繪製長方形
        /// </summary>
        void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY);

        /// <summary>
        /// 繪製文字
        /// </summary>
        /// <param name="topLeftX"></param>
        /// <param name="topLeftY"></param>
        void DrawString(double topLeftX, double topLeftY, string text);
    }
}
