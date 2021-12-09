using DrawingModel.Enums;

using System;

namespace DrawingModel.Interfaces
{
    public interface IModel
    {
        event Action _modelChanged;

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
        /// 設置圖形種類
        /// </summary>
        /// <param name="shapeType"></param>
        void SetShapeType(ShapeType shapeType);

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        void Clear();
    }
}
