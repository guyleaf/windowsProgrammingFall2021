using DrawingModel.Enums;
using DrawingModel.Interfaces;

using System.ComponentModel;

namespace DrawingForm.Models
{
    public class FormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IModel _model;

        private bool _isRectangleButtonEnabled;
        private bool _isEllipseButtonEnabled;
        private bool _isLineButtonEnabled;

        public FormPresentationModel(IModel model)
        {
            _model = model;
            _model._modelChanged += HandleModelOnModelChanged;
            _isRectangleButtonEnabled = _isEllipseButtonEnabled = _isLineButtonEnabled = true;
        }

        public bool IsRectangleButtonEnabled
        {
            get
            {
                return _isRectangleButtonEnabled;
            }
        }

        public bool IsEllipseButtonEnabled
        {
            get
            {
                return _isEllipseButtonEnabled;
            }
        }

        public bool IsLineButtonEnabled
        {
            get
            {
                return _isLineButtonEnabled;
            }
        }

        /// <summary>
        /// 常壓滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void PressPointer(double locationX, double locationY)
        {
            _model.PressPointer(locationX, locationY);
        }

        /// <summary>
        /// 移動滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void MovePointer(double locationX, double locationY)
        {
            _model.MovePointer(locationX, locationY);
        }

        /// <summary>
        /// 釋放滑鼠
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        public void ReleasePointer(double locationX, double locationY)
        {
            _model.ReleasePointer(locationX, locationY);
        }

        /// <summary>
        /// 點選 Rectangle button
        /// </summary>
        public void ClickRectangleButton()
        {
            _model.ChooseShape(ShapeType.Rectangle);
            _isRectangleButtonEnabled = false;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 點選 Ellipse button
        /// </summary>
        public void ClickEllipseButton()
        {
            _model.ChooseShape(ShapeType.Ellipse);
            _isEllipseButtonEnabled = false;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 點選 Line button
        /// </summary>
        public void ClickLineButton()
        {
            _model.ChooseLine();
            _isLineButtonEnabled = false;
            NotifyPropertyChanged();
        }

        /// <summary>
        /// 監聽 Model 的 ModelChanged
        /// </summary>
        private void HandleModelOnModelChanged()
        {
            if (!_model.IsDrawing)
            {
                _isRectangleButtonEnabled = _isEllipseButtonEnabled = _isLineButtonEnabled = true;
                NotifyPropertyChanged();
            }
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
