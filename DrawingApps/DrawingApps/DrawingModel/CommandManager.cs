using DrawingModel.Commands;

using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class CommandManager
    {
        private const string EXCEPTION_MESSAGE_FOR_REDO = "No more commands to redo.";
        private const string EXCEPTION_MESSAGE_FOR_UNDO = "No more commands to undo.";

        private readonly Stack<ICommand> _executedCommands;
        private readonly Stack<ICommand> _revokedCommands;

        public CommandManager()
        {
            _executedCommands = new Stack<ICommand>();
            _revokedCommands = new Stack<ICommand>();
        }

        public bool IsAnyCommandExecuted
        {
            get
            {
                return _executedCommands.Count > 0;
            }
        }

        public bool IsAnyCommandRevoked
        {
            get
            {
                return _revokedCommands.Count > 0;
            }
        }

        /// <summary>
        /// 執行指令
        /// </summary>
        /// <param name="command"></param>
        public void Execute(ICommand command)
        {
            _executedCommands.Clear();
            command.Execute();
            _executedCommands.Push(command);
        }

        /// <summary>
        /// 重作
        /// </summary>
        public void Redo()
        {
            if (_revokedCommands.Count < 0)
            {
                throw new InvalidOperationException(EXCEPTION_MESSAGE_FOR_REDO);
            }

            var command = _revokedCommands.Pop();
            command.Execute();
            _executedCommands.Push(command);
        }

        /// <summary>
        /// 復原
        /// </summary>
        public void Undo()
        {
            if (_executedCommands.Count < 0)
            {
                throw new InvalidOperationException(EXCEPTION_MESSAGE_FOR_UNDO);
            }

            var command = _executedCommands.Pop();
            command.Revoke();
            _revokedCommands.Push(command);
        }
    }
}
