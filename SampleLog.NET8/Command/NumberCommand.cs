namespace SampleLog.NET8.Command
{
    public class NumberCommand : ICommand
    {
        private readonly CalculatorForm _form;
        private readonly string _number;

        public NumberCommand(CalculatorForm form, string number)
        {
            _form = form;
            _number = number;            
        }

        public void Invoke()
        {            
            _form.AddValueToTextBoxDisplay(_number);
        }

        public void Undo()
        {
            var currentValue = _form.GetTextBoxDisplay();
            var newValue = currentValue.Remove(currentValue.Length - 1);
            _form.SetTextBoxDisplay(newValue);
        }

        public void Redo()
        {
            Invoke();
        }
    }
}
