using SampleLog.NET8.Models;

namespace SampleLog.NET8.Calculator.Command
{
    public class OperationCommand : ICommand
    {
        private CalculatorViewModel _viewModel;
        private readonly string _operand;
        private string _previousValue;

        public OperationCommand(CalculatorViewModel viewModel, string operand)
        {
            _viewModel = viewModel;
            _operand = operand;
        }

        public void Invoke()
        {
            //var textBoxData = _form.GetTextBoxData();
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;

            if (currentValue.Length == 0)
            {
                return;
            }

            var lastChar = currentValue[^1];

            if (char.IsDigit(lastChar))
            {
                //_form.SetTextBoxDisplay(currentValue + _operand);
                _viewModel.DisplayText = currentValue + _operand;
            }
            else
            {
                var newValue = currentValue.Remove(currentValue.Length - 1);
                //_form.SetTextBoxDisplay(newValue + _operand);
                _viewModel.DisplayText = newValue + _operand;
            }
        }

        public void Undo()
        {
            _viewModel.DisplayText = _previousValue;
        }

        public void Redo()
        {
            Invoke();
        }
    }
}
