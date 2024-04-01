using System.Data;

namespace SampleLog.NET8.Command
{
    public class EqualCommand : ICommand
    {
        private readonly CalculatorForm _form;        
        private readonly DataTable _dataTable;
        private string _previousValue;

        public EqualCommand(CalculatorForm form)
        {
            _form = form;            
            _dataTable = new DataTable();
        }

        public void Invoke()
        {
            var currentValue = _form.GetTextBoxDisplay();
            _previousValue = currentValue;

            var expression = ConvertExpression(currentValue);
            var newValue = _dataTable.Compute(expression, null);            
            var decimalValue = ConvertStringToDecimal(newValue.ToString());

            if (decimalValue != null)
            {
                newValue = Math.Round((decimal)decimalValue, 5);                
            }
                        
            _form.SetTextBoxDisplay(newValue.ToString());                        
        }


        public void Undo()
        {            
            _form.SetTextBoxDisplay(_previousValue);
        }

        public void Redo()
        {
            Invoke();
        }

        private string ConvertExpression(string expression)
        {
            var result = expression;

            var operands = new Dictionary<string, string>()
            {
                { "x", "*" },
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
