using DrawingModel.Interfaces;

namespace DrawingModel.Commands
{
    public class DrawCommand : ICommand
    {
        private readonly Model _model;
        private readonly IShape _shape;

        public DrawCommand(Model model, IShape shape)
        {
            _model = model;
            _shape = shape;
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        /// <summary>
        /// 撤銷
        /// </summary>
        public void Revoke()
        {
            _model.RemoveShape();
        }
    }
}
