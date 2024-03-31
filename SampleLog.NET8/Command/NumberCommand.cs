using System.Text.RegularExpressions;

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
