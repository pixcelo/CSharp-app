namespace SampleLog.NET8.Command
{
    public class ClearCommand : ICommand
    {
        private readonly CalculatorForm _form;        
        private string _previousValue;

        public ClearCommand(CalculatorForm form)
        {
            _form = form;            
        }

        public void Invoke()
        {
            var currentValue = _form.GetTextBoxDisplay();
            _previousValue = currentValue;

            _form.SetTextBoxDisplay("");
        }

        public void Undo()
        {
            _form.SetTextBoxDisplay(_previousValue);
        }

        public void Redo()
        {
            Invoke();
        }
    }
}
