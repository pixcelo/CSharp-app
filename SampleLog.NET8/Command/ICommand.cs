namespace SampleLog.NET8.Command
{
    public interface ICommand
    {
        public void Invoke();
        public void Undo();
        public void Redo();
    }
}
