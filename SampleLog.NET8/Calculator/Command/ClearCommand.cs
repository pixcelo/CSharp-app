using SampleLog.NET8.Models;

namespace SampleLog.NET8.Calculator.Command
{
    public class ClearCommand : ICommand
    {
        private CalculatorViewModel _viewModel;
        private string _previousValue;

        public ClearCommand(CalculatorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Invoke()
        {            
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;
            
            _viewModel.DisplayText = "";
            _viewModel.ExpressionText = "";
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
