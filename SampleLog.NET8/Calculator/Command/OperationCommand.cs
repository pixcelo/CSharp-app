using log4net.Repository.Hierarchy;
using SampleLog.NET8.Models;

namespace SampleLog.NET8.Calculator.Command
{
    public class OperationCommand : ICommand
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
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
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;

            if (currentValue.Length == 0)
            {
                return;
            }

            var lastChar = currentValue[^1];

            if (char.IsDigit(lastChar))
            {                
                _viewModel.DisplayText = currentValue + _operand;
            }
            else
            {
                var newValue = currentValue.Remove(currentValue.Length - 1);                
                _viewModel.DisplayText = newValue + _operand;
            }

            logger.Info($"Result: {_viewModel.DisplayText}");
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
