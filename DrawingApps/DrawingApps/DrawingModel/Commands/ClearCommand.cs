using DrawingModel.Interfaces;

using System.Collections.Generic;

namespace DrawingModel.Commands
{
    public class ClearCommand : ICommand
    {
        private readonly Model _model;
        private readonly IList<IShape> _shapes;

        public ClearCommand(Model model, IList<IShape> shapes)
        {
            _model = model;
            _shapes = new List<IShape>(shapes);
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            _model.RemoveAllShapes();
        }

        /// <summary>
        /// 撤銷
        /// </summary>
        public void Revoke()
        {
            foreach (var shape in _shapes)
            {
                _model.DrawShapeInFront(shape);
            }
        }
    }
}
