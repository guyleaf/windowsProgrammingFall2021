using DrawingModel.Enums;
using DrawingModel.Interfaces;
using DrawingModel.States;

using System;

namespace DrawingModel
{
    public partial class Model
    {
        /// <summary>
        /// 選擇游標
        /// </summary>
        public void ChoosePointer()
        {
            _state = new PointerState(_commandManager, this);
        }

        /// <summary>
        /// 尋找目標位置對應的 shape
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <returns></returns>
        public IShape FindShapeByLocation(double locationX, double locationY)
        {
            for (var i = _shapes.Count - 1; i >= 0; i--)
            {
                var shape = _shapes[i];
                if (shape.IsLocatedIn(locationX, locationY))
                {
                    return shape;
                }
            }

            return null;
        }

        /// <summary>
        /// 繪製圖形至最上層
        /// </summary>
        /// <param name="shape"></param>
        public void DrawShapeInFront(IShape shape)
        {
            _shapes.Add(shape);
        }

        /// <summary>
        /// 繪製圖形至最下層
        /// </summary>
        /// <param name="shape"></param>
        public void DrawShapeInBack(IShape shape)
        {
            _shapes.Insert(0, shape);
        }

        /// <summary>
        /// 移除圖形
        /// </summary>
        public void RemoveShape(IShape shape)
        {
            _shapes.Remove(shape);
        }

        /// <summary>
        /// 移除所有圖形
        /// </summary>
        public void RemoveAllShapes()
        {
            _shapes.Clear();
        }

        /// <summary>
        /// 通知訂閱者
        /// </summary>
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }
    }
}
