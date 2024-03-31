namespace SampleLog.NET8.Command
{
    public class DotCommand : ICommand
    {
        private readonly CalculatorForm _form;
        private readonly string _value;
        private string _previousValue;

        public DotCommand(CalculatorForm form, string value)
        {
            _form = form;
            _value = value;
        }

        public void Invoke()
        {
            var currentValue = _form.GetTextBoxDisplay();
            _previousValue = currentValue;            

            if (currentValue.Length == 0)
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

                _form.SetTextBoxDisplay(currentValue + _value);
            }
            else if (!currentValue.Contains(_value))
            {
                _form.SetTextBoxDisplay(currentValue + _value);
            }
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
        /// 数値または小数点が見つかったインデックスを取得（取得できない場合は -1を返却）
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
