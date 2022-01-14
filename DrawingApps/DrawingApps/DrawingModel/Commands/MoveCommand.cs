using DrawingModel.Interfaces;

namespace DrawingModel.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly IShape _shape;

        private readonly double _originalTopLeftX;
        private readonly double _originalTopLeftY;

        private readonly double _newTopLeftX;
        private readonly double _newTopLeftY;

        public MoveCommand(
            IShape shape, double originalTopLeftX, double originalTopLeftY, double newTopLeftX, double newTopLeftY)
        {
            _shape = shape;
            _originalTopLeftX = originalTopLeftX;
            _originalTopLeftY = originalTopLeftY;

            _newTopLeftX = newTopLeftX;
            _newTopLeftY = newTopLeftY;
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            _shape.MoveTo(_newTopLeftX, _newTopLeftY);
        }

        /// <summary>
        /// 撤銷
        /// </summary>
        public void Revoke()
        {
            _shape.MoveTo(_originalTopLeftX, _originalTopLeftY);
        }
    }
}
