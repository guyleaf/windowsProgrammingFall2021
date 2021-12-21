namespace DrawingModel.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// 執行
        /// </summary>
        void Execute();

        /// <summary>
        /// 撤銷
        /// </summary>
        void Revoke();
    }
}
