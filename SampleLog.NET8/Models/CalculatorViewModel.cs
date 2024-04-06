using System.ComponentModel;

namespace SampleLog.NET8.Models
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calculatorModel;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string DisplayText
        {
            get { return _calculatorModel.DisplayText; }
            set
            {
                _calculatorModel.DisplayText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayText)));
            }
        }

        public string ExpressionText
        {
            get { return _calculatorModel.ExpressionText; }
            set
            {
                _calculatorModel.ExpressionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExpressionText)));
            }
        }

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
        }
    }
}
