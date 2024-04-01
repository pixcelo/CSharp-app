using System.Data;

namespace SampleLog.NET8.Command
{
    public class EqualCommand : ICommand
    {
        private readonly CalculatorForm _form;        
        private readonly DataTable _dataTable;
        private string _previousValue;
        private string _previousExpression;

        public EqualCommand(CalculatorForm form)
        {
            _form = form;            
            _dataTable = new DataTable();
        }

        public void Invoke()
        {
            var textBoxData = _form.GetTextBoxData();
            var currentValue = textBoxData.DisplayText;
            _previousValue = currentValue;
            _previousExpression = textBoxData.ExpressionText;

            if (string.IsNullOrEmpty(currentValue))
            {
                return;
            }

            var expression = ConvertExpression(currentValue);

            if (!char.IsDigit(expression.Last()))
            {
                return;
            }

            var newValue = _dataTable.Compute(expression, null);
            var decimalValue = ConvertStringToDecimal(newValue.ToString());

            if (decimalValue != null)
            {
                newValue = Math.Round((decimal)decimalValue, 5);
            }
                        
            _form.SetTextBoxDisplay(newValue.ToString());
            _form.SetTextBoxExpression(_previousValue + "=");
        }


        public void Undo()
        {            
            _form.SetTextBoxDisplay(_previousValue);
            _form.SetTextBoxDisplay(_previousExpression);
        }

        public void Redo()
        {
            Invoke();
        }

        /// <summary>
        /// 演算子の文字列を変換
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string ConvertExpression(string expression)
        {
            var result = expression;

            var operands = new Dictionary<string, string>()
            {
                { "×", "*" },
                { "÷", "/" }
            };

            foreach (var operand in operands)
            {
                result = result.Replace(operand.Key, operand.Value);
            }

            return result;
        }

        private decimal? ConvertStringToDecimal(string value)
        {
            return decimal.TryParse(value, out decimal result) ? result : null;
        }
    }    
}
