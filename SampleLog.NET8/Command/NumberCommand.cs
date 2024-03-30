namespace SampleLog.NET8.Command
{
    public class NumberCommand : ICommand
    {
        private readonly CalculatorForm _form;
        private readonly string _number;
        private string _previousValue;

        public NumberCommand(CalculatorForm form, string number)
        {
            _form = form;
            _number = number;
            _previousValue = _form.GetTextBoxDisplay();
        }

        public void Invoke()
        {            
            _form.AddValueToTextBoxDisplay(_number);
        }

        public void Undo()
        {
            //_form.TextboxDisplay.Text = _form.TextboxDisplay.Text.Substring(0, _form.TextboxDisplay.Text.Length - _number.Length);
            //_form.
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
