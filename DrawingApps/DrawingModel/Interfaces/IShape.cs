namespace DrawingModel.Interfaces
{
    public interface IShape
    {
        /// <summary>
        /// 畫圖
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics);
    }
}
