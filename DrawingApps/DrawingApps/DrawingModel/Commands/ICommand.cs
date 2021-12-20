namespace DrawingModel.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// 執行
        /// </summary>
        void Execute();

        /// <summary>
        /// 復原
        /// </summary>
        void Undo();
    }
}
