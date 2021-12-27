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

        string Info
        {
            get;
        }

        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics);

        /// <summary>
        /// 是否位於目標座標
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        bool IsLocatedIn(double locationX, double locationY);
    }
}
