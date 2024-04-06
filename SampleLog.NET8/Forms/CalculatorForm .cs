using SampleLog.NET8.Calculator.Command;
using SampleLog.NET8.Models;

namespace SampleLog.NET8
{
    public partial class CalculatorForm : Form
    {        
        private CommandManager _commandManager;
        private CalculatorViewModel _viewModel;

        public CalculatorForm(CommandManager commandManager)
        {
            InitializeComponent();
            Setup();

            _commandManager = commandManager;
        }

        private void Setup()
        {
            _viewModel = new CalculatorViewModel();
            TextBoxDisplay.DataBindings.Add(nameof(TextBoxDisplay.Text), _viewModel, nameof(_viewModel.DisplayText));
            TextBoxExpression.DataBindings.Add(nameof(TextBoxExpression.Text), _viewModel, nameof(_viewModel.ExpressionText));
        }


        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;                
            ICommand command = new NumberCommand(_viewModel, button.Text);
            _commandManager.Invoke(command);
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new DotCommand(_viewModel, button.Text);
            _commandManager.Invoke(command);           
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            ICommand command = new EqualCommand(_viewModel);
            _commandManager.Invoke(command);
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new OperationCommand(_viewModel, button.Text);
            _commandManager.Invoke(command);
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            _commandManager.Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            _commandManager.Redo();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new ClearCommand(_viewModel);
            _commandManager.Invoke(command);
        }     
    }
}
