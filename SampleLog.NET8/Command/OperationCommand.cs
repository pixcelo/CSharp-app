namespace SampleLog.NET8.Command
{
    public class OperationCommand : ICommand
    {
        private CalculatorForm _form;
        private string _operation;
        private decimal _operand;

        public OperationCommand(CalculatorForm form, string operation, decimal operand)
        {
            _form = form;
            _operation = operation;
            _operand = operand;
        }

        public void Invoke()
        {
            decimal result = 0;
            decimal currentValue = decimal.Parse(_form.GetTextBoxDisplay());

            switch (_operation)
            {
                case "+":
                    result = currentValue + _operand;
                    break;
                case "-":
                    result = currentValue - _operand;
                    break;
                case "*":
                    result = currentValue * _operand;
                    break;
                case "/":
                    result = currentValue / _operand;
                    break;
            }

            _form.AddValueToTextBoxDisplay(result.ToString());
        }

        public void Undo()
        {
            // 
        }

        public void Redo()
        {
            // 
        }
    }
}
