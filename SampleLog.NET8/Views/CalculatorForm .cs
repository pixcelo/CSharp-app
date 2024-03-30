using SampleLog.NET8.Command;

namespace SampleLog.NET8
{
    public partial class CalculatorForm : Form
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        

        private CommandManager _commandManager = new CommandManager();
        private decimal _operand;
        private string _operation;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        public string GetTextBoxDisplay()
        {
            return this.TextBoxDisplay.Text;
        }

        public void SetTextBoxDisplay(string value)
        {
            this.TextBoxDisplay.Text = value;
        }

        public void AddValueToTextBoxDisplay(string value)
        {
            this.TextBoxDisplay.Text += value;
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

            btnAddition.Click += OperationButton_Click;
            btnSubtraction.Click += OperationButton_Click;
            btnMultiplication.Click += OperationButton_Click;
            btnDivision.Click += OperationButton_Click;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new NumberCommand(this, button.Text);
            _commandManager.Invoke(command);
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operand = TextBoxDisplay.Text;
            _operation = button.Text;
            TextBoxDisplay.Text = "";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            ICommand command = new OperationCommand(this, _operation, _operand);
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

        //private void btnRedo_Click(object sender, EventArgs e)
        //{
        //    logger.Debug("clicked");
        //}        
    }
}