namespace SampleLog.NET8.Command
{
    public class OperationCommand : ICommand
    {
        private readonly CalculatorForm _form;
        private readonly string _operand;
        private string _previousValue;

        public OperationCommand(CalculatorForm form, string operand)
        {
            _form = form;
            _operand = operand;
        }

        public void Invoke()
        {
            var textBoxData = _form.GetTextBoxData();
            var currentValue = textBoxData.DisplayText;
            _previousValue = currentValue;

            if (currentValue.Length == 0)
            {
                return;
            }
        
            var lastChar = currentValue[^1];            

            if (char.IsDigit(lastChar))
            {
                _form.SetTextBoxDisplay(currentValue + _operand);
            }
            else
            {
                var newValue = currentValue.Remove(currentValue.Length - 1);
                _form.SetTextBoxDisplay(newValue + _operand);
            }       
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
