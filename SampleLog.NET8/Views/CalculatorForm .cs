using SampleLog.NET8.Command;

namespace SampleLog.NET8
{
    public partial class CalculatorForm : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        
        private CommandManager _commandManager = new CommandManager();

        public class TextBoxData
        {
            public string DisplayText { get; set; }
            public string ExpressionText { get; set; }
        }

        public CalculatorForm()
        {
            InitializeComponent();
        }

        public TextBoxData GetTextBoxData()
        {
            return new TextBoxData
            {
                DisplayText = TextBoxDisplay.Text,
                ExpressionText = TextBoxExpression.Text,
            };
        }

        public void SetTextBoxDisplay(string value)
        {
            TextBoxDisplay.Text = value;
        }

        public void AddValueToTextBoxDisplay(string value)
        {
            TextBoxDisplay.Text += value;
        }

        public void SetTextBoxExpression(string value)
        {
            TextBoxExpression.Text = value;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            btn0.Click += NumberButton_Click;
            btn1.Click += NumberButton_Click;
            btn2.Click += NumberButton_Click;
            btn3.Click += NumberButton_Click;
            btn4.Click += NumberButton_Click;
            btn5.Click += NumberButton_Click;
            btn6.Click += NumberButton_Click;
            btn7.Click += NumberButton_Click;
            btn8.Click += NumberButton_Click;
            btn9.Click += NumberButton_Click;
            btnDot.Click += DotButton_Click;

            btnUndo.Click += UndoButton_Click;
            btnRedo.Click += RedoButton_Click;
            btnClear.Click += ClearButton_Click;

            btnEqual.Click += EqualButton_Click;
            btnAddition.Click += OperationButton_Click;
            btnSubtraction.Click += OperationButton_Click;
            btnMultiplication.Click += OperationButton_Click;
            btnDivision.Click += OperationButton_Click;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                ICommand command = new NumberCommand(this, button.Text);
                _commandManager.Invoke(command);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                ICommand command = new DotCommand(this, button.Text);
                _commandManager.Invoke(command);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            try
            {
                ICommand command = new EqualCommand(this);
                _commandManager.Invoke(command);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                ICommand command = new OperationCommand(this, button.Text);
                _commandManager.Invoke(command);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            try
            {
                _commandManager.Undo();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            try
            {
                _commandManager.Redo();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                ICommand command = new ClearCommand(this);
                _commandManager.Invoke(command);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + ex.StackTrace);
            }
        }

        //private void btnRedo_Click(object sender, EventArgs e)
        //{
        //    logger.Debug("clicked");
        //}        
    }
}
