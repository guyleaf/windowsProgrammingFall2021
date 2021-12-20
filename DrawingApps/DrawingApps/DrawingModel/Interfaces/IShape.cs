namespace DrawingModel.Interfaces
{
    public interface IShape
    {
        double X1
        {
            get; set;
        }

        double Y1
        {
            get; set;
        }

        double X2
        {
            get; set;
        }

        double Y2
        {
            get; set;
        }

        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics);
    }
}
