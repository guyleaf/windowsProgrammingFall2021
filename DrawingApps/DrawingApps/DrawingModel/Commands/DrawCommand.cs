using System;

namespace DrawingModel.Commands
{
    public class DrawCommand : ICommand
    {
        /// <summary>
        /// 執行
        /// </summary>
        public void Execute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 復原
        /// </summary>
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
