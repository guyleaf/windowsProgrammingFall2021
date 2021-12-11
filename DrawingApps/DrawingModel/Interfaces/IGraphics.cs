namespace DrawingModel.Interfaces
{
    public interface IGraphics
    {
        /// <summary>
        /// 清除全部
        /// </summary>
        void ClearAll();

        /// <summary>
        /// 畫線
        /// </summary>
        void DrawDashedLine(double x1, double y1, double x2, double y2);

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
