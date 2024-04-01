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
            var textBoxData = _form.GetTextBoxData();
            var currentValue = textBoxData.DisplayText;
            _previousValue = currentValue;

            _form.SetTextBoxDisplay("");
            _form.SetTextBoxExpression("");
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
