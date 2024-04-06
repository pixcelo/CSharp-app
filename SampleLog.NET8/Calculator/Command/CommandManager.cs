namespace SampleLog.NET8.Calculator.Command
{
    public class CommandManager
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Stack<ICommand> _undoBuffer = new Stack<ICommand>();
        private Stack<ICommand> _redoBuffer = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            try
            {                
                command.Invoke();
                _undoBuffer.Push(command);
                _redoBuffer.Clear();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        public void Undo()
        {
            try
            {
                if (_undoBuffer.Count > 0)
                {
                    ICommand command = _undoBuffer.Pop();
                    command.Undo();
                    _redoBuffer.Push(command);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        public void Redo()
        {
            try
            {
                if (_redoBuffer.Count > 0)
                {
                    ICommand command = _redoBuffer.Pop();
                    command.Invoke();
                    _undoBuffer.Push(command);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }            
        }
    }
}
