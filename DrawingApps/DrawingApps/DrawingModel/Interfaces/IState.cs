using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingModel.Interfaces
{
    public interface IState
    {
        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        void PressPointer(double locationX, double locationY);

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        void MovePointer(double locationX, double locationY);

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="mode"></param>
        void ReleasePointer(double locationX, double locationY);

        /// <summary>
        /// 渲染/繪圖
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics);
    }
}
