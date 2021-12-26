using DrawingModel.Interfaces;

namespace DrawingModel.Commands
{
    public class DrawCommand : ICommand
    {
        private readonly Model _model;
        private readonly IShape _shape;
        private readonly bool _drawInFront;

        public DrawCommand(Model model, IShape shape, bool drawInFront)
        {
            _model = model;
            _shape = shape;
            _drawInFront = drawInFront;
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            if (_drawInFront)
            {
                _model.DrawShapeInFront(_shape);
            }
            else
            {
                _model.DrawShapeInBack(_shape);
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
