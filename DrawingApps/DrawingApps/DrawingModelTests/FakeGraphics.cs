﻿using DrawingModel.Interfaces;

namespace DrawingModelTests
{
    public class FakeGraphics : IGraphics
    {
        public int CountForClearAll
        {
            get; private set;
        }

        public int CountForDrawEllipse
        {
            get; private set;
        }

        public int CountForDrawRectangle
        {
            get; private set;
        }

        public int CountForDrawDashedRectangle
        {
            get; private set;
        }

        public int CountForDrawLine
        {
            get; private set;
        }

        public int CountForDrawDot
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
                return CountForDrawEllipse > 0;
            }
        }
        
        public bool IsDrawRectangleTriggered
        {
            get
            {
                return CountForDrawRectangle > 0;
            }
        }

        public bool IsDrawDashedRectangleTriggered
        {
            get
            {
                return CountForDrawDashedRectangle > 0;
            }
        }

        public bool IsDrawLineTriggered
        {
            get
            {
                return CountForDrawLine > 0;
            }
        }

        public bool IsDrawDotTriggered
        {
            get
            {
                return CountForDrawDot > 0;
            }
        }

        public double X1
        {
            get; private set;
        }

        public double Y1
        {
            get; private set;
        }

        public double X2
        {
            get; private set;
        }

        public double Y2
        {
            get; private set;
        }

        public double MiddleX
        {
            get; private set;
        }

        public double MiddleY
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
            CountForDrawEllipse++;
            X1 = topLeftX;
            Y1 = topLeftY;
            X2 = bottomRightX;
            Y2 = bottomRightY;
        }

        /// <summary>
        /// 畫虛線
        /// </summary>
        public void DrawDashedRectangle(double x1, double y1, double x2, double y2)
        {
            CountForDrawDashedRectangle++;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>
        /// 畫實線
        /// </summary>
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            CountForDrawLine++;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        /// <summary>
        /// 畫長方形
        /// </summary>
        public void DrawRectangle(double topLeftX, double topLeftY, double bottomRightX, double bottomRightY)
        {
            CountForDrawRectangle++;
            X1 = topLeftX;
            Y1 = topLeftY;
            X2 = bottomRightX;
            Y2 = bottomRightY;
        }

        /// <summary>
        /// 畫圓點
        /// </summary>
        /// <param name="middleX"></param>
        /// <param name="middleY"></param>
        public void DrawDot(double middleX, double middleY)
        {
            CountForDrawDot++;
            MiddleX = middleX;
            MiddleY = middleY;
        }
    }
}
