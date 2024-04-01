using System.Text.RegularExpressions;

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
        }

        public void Invoke()
        {
            var textBoxData = _form.GetTextBoxData();
            var currentValue = textBoxData.DisplayText;
            _previousValue = currentValue;

            if (ValidateMaxDigits(currentValue))
            {
                return;
            }

            _form.AddValueToTextBoxDisplay(_number);
        }

        public void Undo()
        {
            _form.SetTextBoxDisplay(_previousValue);
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
            if (currentValue.Length == 0)
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
