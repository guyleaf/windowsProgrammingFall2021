using DrawingModel.Interfaces;

namespace DrawingModelTests
{
    public class FakeGraphics : IGraphics
    {
        public int CountForClearAll
        {
            get; private set;
        }

        public int CountForDrawEllipise
        {
            get; private set;
        }

        public int CountForDrawRectangle
        {
            get; private set;
        }

        public bool IsClearAllTriggered
        {
            get
            {
                return CountForClearAll > 0;
            }
        }

        public bool IsDrawEllipseTriggered
        {
            get
            {
                return CountForDrawEllipise > 0;
            }
        }
        
        public bool IsDrawRectangleTriggered
        {
            get
            {
                return CountForDrawRectangle > 0;
            }
        }

        public double TopLeftX
        {
            get; private set;
        }

        public double TopLeftY
        {
            get; private set;
        }

        public double BottomRightX
        {
            get; private set;
        }

        public double BottomRightY
        {
            get; private set;
        }

        /// <summary>
        /// 清除全部
        /// </summary>
        public void ClearAll()
        {
            CountForClearAll++;
        }

        /// <summary>
        /// 畫橢圓形
        /// </summary>
        public void DrawEllipse(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            CountForDrawEllipise++;
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
        }

        /// <summary>
        /// 畫長方形
        /// </summary>
        public void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            CountForDrawRectangle++;
            TopLeftX = topLeftX;
            TopLeftY = topLeftY;
            BottomRightX = bottomRightX;
            BottomRightY = bottomRightY;
        }
    }
}
