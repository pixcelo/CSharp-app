using SampleLog.NET8.Models;
using System.Text.RegularExpressions;

namespace SampleLog.NET8.Calculator.Command
{
    public class NumberCommand : ICommand
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
        private CalculatorViewModel _viewModel;
        private readonly string _number;
        private string _previousValue;

        public NumberCommand(CalculatorViewModel viewModel, string number)
        {
            _viewModel = viewModel;
            _number = number;
        }

        public void Invoke()
        {            
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;

            if (ValidateMaxDigits(currentValue))
            {
                return;
            }
            
            _viewModel.DisplayText = currentValue + _number;

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
        /// 小数点以下の桁数が既定の数値を超えている場合は True
        /// </summary>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        private bool ValidateMaxDigits(string currentValue)
        {
            if (string.IsNullOrEmpty(currentValue))
            {
                return false;
            }

            var input = SplitByOperators(currentValue).Last();

            if (!input.Contains("."))
            {
                return false;
            }

            const int MAX_DECIMAL_PLACES = 5;
            var decimalPart = input.Split('.').LastOrDefault();
            return decimalPart.Length >= MAX_DECIMAL_PLACES;
        }

        /// <summary>
        /// 項の配列を取得
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[] SplitByOperators(string input)
        {
            // 数値または小数点以外
            var pattern = @"[^0-9.]+";
            return Regex.Split(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
