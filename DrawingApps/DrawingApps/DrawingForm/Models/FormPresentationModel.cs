﻿using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System.ComponentModel;

namespace DrawingForm.Models
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DrawingMode _drawingMode;
        private readonly IModel _model;

        private int _drawingCount;

        public FormPresentationModel(IModel model)
        {
            _drawingMode = DrawingMode.None;
            _model = model;
            _model._modelChanged += HandleModelOnModelChanged;
            _drawingCount = 0;
        }

        public bool IsRectangleButtonEnabled
        {
            get
            {
                return IsShapeButtonEnabled(ShapeType.Rectangle);
            }
        }

        public bool IsEllipseButtonEnabled
        {
            get
            {
                return IsShapeButtonEnabled(ShapeType.Ellipse);
            }
        }

        public bool IsLineButtonEnabled
        {
            get
            {
                return IsShapeButtonEnabled(ShapeType.Line);
            }
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PressPointer(double locationX, double locationY)
        {
            if (IsCurrentDrawingModeEqualTo(DrawingMode.Drawing))
            {
                _model.PressPointer(locationX, locationY);
            }
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            if (IsCurrentDrawingModeEqualTo(DrawingMode.Drawing))
            {
                _model.MovePointer(locationX, locationY);
            }
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void ReleasePointer(double locationX, double locationY)
        {
            if (IsCurrentDrawingModeEqualTo(DrawingMode.Drawing))
            {
                _model.ReleasePointer(locationX, locationY);
                _drawingCount++;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// 點選 Rectangle button
        /// </summary>
        public void ClickRectangleButton()
        {
            _model.CurrentDrawingShapeType = ShapeType.Rectangle;
            _drawingCount = 0;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 點選 Ellipse button
        /// </summary>
        public void ClickEllipseButton()
        {
            _model.CurrentDrawingShapeType = ShapeType.Ellipse;
            _drawingCount = 0;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 點選 Line button
        /// </summary>
        public void ClickLineButton()
        {
            _model.CurrentDrawingShapeType = ShapeType.Line;
            _drawingCount = 0;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 監聽 Model 的 ModelChanged
        /// </summary>
        private void HandleModelOnModelChanged()
        {
            var newDrawingMode = IsCurrentShapeTypeEqualTo(ShapeType.None) ? DrawingMode.None : DrawingMode.Drawing;
            
            if (newDrawingMode != _drawingMode)
            {
                _drawingMode = newDrawingMode;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// 是否目前 shape type 與參數一樣
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private bool IsCurrentShapeTypeEqualTo(ShapeType shapeType)
        {
            return _model.CurrentDrawingShapeType == shapeType;
        }

        /// <summary>
        /// 是否目前 drawing mode 與參數一樣
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        private bool IsCurrentDrawingModeEqualTo(DrawingMode mode)
        {
            return _drawingMode == mode;
        }

        /// <summary>
        /// 是否 Shape 相關按鈕為啟用
        /// </summary>
        /// <returns></returns>
        private bool IsShapeButtonEnabled(ShapeType shapeType)
        {
            return IsCurrentDrawingModeEqualTo(DrawingMode.None) ||
                    !IsCurrentShapeTypeEqualTo(shapeType) ||
                    _drawingCount > 0;
        }

        /// <summary>
        /// 通知 PropertyChanged 訂閱者
        /// </summary>
        private void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
            }
        }
    }
}
