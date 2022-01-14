﻿using DrawingModel.Enums;

using System;

namespace DrawingModel.Interfaces
{
    public interface IModel
    {
        event Action _modelChanged;

        bool IsAnyShapeDisplayed
        {
            get;
        }

        bool IsAnyShapeRemoved
        {
            get;
        }

        bool IsDrawing
        {
            get;
        }

        /// <summary>
        /// 選擇畫圖形
        /// </summary>
        /// <param name="shapeType"></param>
        void ChooseShape(ShapeType shapeType);

        /// <summary>
        /// 選擇畫線
        /// </summary>
        void ChooseLine();

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
        /// 清除所有繪製布
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
