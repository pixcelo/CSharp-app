namespace SampleLog.NET8.Command
{
    public class CommandManager
    {
        private Stack<ICommand> _undoBuffer = new Stack<ICommand>();
        private Stack<ICommand> _redoBuffer = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            command.Invoke();
            _undoBuffer.Push(command);
            _redoBuffer.Clear();
        }

        public void Undo()
        {
            if (_undoBuffer.Count > 0)
            {
                ICommand command = _undoBuffer.Pop();
                command.Undo();
                _redoBuffer.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoBuffer.Count > 0)
            {
                ICommand command = _redoBuffer.Pop();
                command.Invoke();
                _undoBuffer.Push(command);
            }
        }
    }
}
