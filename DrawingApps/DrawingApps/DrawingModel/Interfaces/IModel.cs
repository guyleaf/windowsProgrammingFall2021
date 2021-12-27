using DrawingModel.Enums;

using System;

namespace DrawingModel.Interfaces
{
    public interface IModel
    {
        event Action _modelChanged;

        ShapeType CurrentDrawingShapeType
        {
            get; set;
        }

        bool IsAnyShapeDisplayed
        {
            get;
        }

        bool IsAnyShapeRemoved
        {
            get;
        }

        bool IsAnyShapeSelected
        {
            get;
        }

        string SelectedShapeInfo
        {
            get;
        }

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

        /// <summary>
        /// 清除所有畫布
        /// </summary>
        void Clear();

        /// <summary>
        /// 重作
        /// </summary>
        void Redo();

        /// <summary>
        /// 復原
        /// </summary>
        void Undo();
    }
}
