using SampleLog.NET8.Models;
using SampleLog.NET8.Repositories;
using System.Data;

namespace SampleLog.NET8.Calculator.Command
{
    public class EqualCommand : ICommand
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
        private IHistoryRepository _historyRepository;
        private CalculatorViewModel _viewModel;
        private readonly DataTable _dataTable;
        private string _previousValue;
        private string _previousExpression;

        public EqualCommand(IHistoryRepository historyRepository, CalculatorViewModel viewModel)
        {
            _historyRepository = historyRepository;
            _viewModel = viewModel;
            _dataTable = new DataTable();
        }

        public void Invoke()
        {            
            var currentValue = _viewModel.DisplayText;
            _previousValue = currentValue;
            _previousExpression = _viewModel.ExpressionText;

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
            
            _viewModel.DisplayText = Convert.ToDouble(newValue).ToString("#,##0.#####");
            _viewModel.ExpressionText = _previousValue + "=";            

            var history = new History
            {                
                Operation = _viewModel.ExpressionText,
                Result = _viewModel.DisplayText
            };

            _historyRepository.Save(history);

            logger.Info($"Result: {_viewModel.DisplayText}");
        }


        public void Undo()
        {            
            _viewModel.DisplayText = _previousValue;
            _viewModel.ExpressionText = _previousExpression;
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
                { "÷", "/" },
                { ",", "" }
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
