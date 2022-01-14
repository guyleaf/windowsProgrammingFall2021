using DrawingModel.Interfaces;

namespace DrawingModel.Commands
{
    public class DrawCommand : ICommand
    {
        private readonly Model _model;
        private readonly IShape _shape;
        private readonly bool _drawInBack;

        public DrawCommand(Model model, IShape shape, bool drawInBack = false)
        {
            _model = model;
            _shape = shape;
            _drawInBack = drawInBack;
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            if (_drawInBack)
            {
                _model.DrawShapeInBack(_shape);
            }
            else
            {
                _model.DrawShapeInFront(_shape);
            }
        }

        /// <summary>
        /// 撤銷
        /// </summary>
        public void Revoke()
        {
            _model.RemoveShape(_shape);
        }
    }
}
