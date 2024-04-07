using SampleLog.NET8.Models;

namespace SampleLog.NET8.Calculator.Command
{
    public class DotCommand : ICommand
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
        private CalculatorViewModel _viewModel;
        private readonly string _value;
        private string _previousValue;

        public DotCommand(CalculatorViewModel viewModel, string value)
        {
            _viewModel = viewModel;
            _value = value;
        }

        public void Invoke()
        {            
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;

            if (string.IsNullOrEmpty(currentValue))
            {
                return;
            }

            var operandIndex = FindNonNumericIndex(currentValue);

            if (operandIndex != -1)
            {
                var term = currentValue.Substring(operandIndex + 1);
                var lastChar = currentValue[^1];

                if (term.Contains(_value) ||
                    !char.IsDigit(lastChar) ||
                    lastChar.ToString() == _value)
                {
                    return;
                }
                
                _viewModel.DisplayText = currentValue + _value;
            }
            else if (!currentValue.Contains(_value))
            {                
                _viewModel.DisplayText = currentValue + _value;
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

        /// <summary>
        /// 演算子が見つかったインデックスを取得（取得できない場合は -1を返却）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int FindNonNumericIndex(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!char.IsDigit(c) && c != '.')
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
