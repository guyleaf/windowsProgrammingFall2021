namespace DrawingModel.Interfaces
{
    public interface IGraphics
    {
        /// <summary>
        /// 清除全部
        /// </summary>
        void ClearAll();

        /// <summary>
        /// 畫虛線
        /// </summary>
        void DrawDashedLine(double x1, double y1, double x2, double y2);

        /// <summary>
        /// 畫實線
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void DrawLine(double x1, double y1, double x2, double y2);

        /// <summary>
        /// 畫橢圓形
        /// </summary>
        void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY);

        /// <summary>
        /// 畫長方形
        /// </summary>
        void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY);
    }
}
