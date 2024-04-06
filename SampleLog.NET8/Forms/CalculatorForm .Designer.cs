namespace SampleLog.NET8
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUndo = new Button();
            btn0 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btnRedo = new Button();
            btnDot = new Button();
            btnEqual = new Button();
            btnAddition = new Button();
            btnSubtraction = new Button();
            btnMultiplication = new Button();
            btnDivision = new Button();
            btnClear = new Button();
            TextBoxExpression = new TextBox();
            TextBoxDisplay = new TextBox();
            PanelHeader = new Panel();
            BtnClose = new Button();
            label1 = new Label();
            PanelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // btnUndo
            // 
            btnUndo.BackColor = Color.FromArgb(60, 60, 60);
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.ForeColor = Color.White;
            btnUndo.Location = new Point(12, 201);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(123, 95);
            btnUndo.TabIndex = 0;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = false;
            btnUndo.CursorChanged += UndoButton_Click;
            btnUndo.Click += UndoButton_Click;
            // 
            // btn0
            // 
            btn0.BackColor = Color.FromArgb(60, 60, 60);
            btn0.FlatAppearance.BorderSize = 0;
            btn0.FlatStyle = FlatStyle.Flat;
            btn0.Font = new Font("Yu Gothic UI", 15F);
            btn0.ForeColor = Color.White;
            btn0.Location = new Point(12, 605);
            btn0.Name = "btn0";
            btn0.Size = new Size(252, 95);
            btn0.TabIndex = 1;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = false;
            btn0.Click += NumberButton_Click;
            // 
            // btn1
            // 
            btn1.BackColor = Color.FromArgb(60, 60, 60);
            btn1.FlatAppearance.BorderSize = 0;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Yu Gothic UI", 15F);
            btn1.ForeColor = Color.White;
            btn1.Location = new Point(12, 504);
            btn1.Name = "btn1";
            btn1.Size = new Size(123, 95);
            btn1.TabIndex = 2;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += NumberButton_Click;
            // 
            // btn2
            // 
            btn2.BackColor = Color.FromArgb(60, 60, 60);
            btn2.FlatAppearance.BorderSize = 0;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Font = new Font("Yu Gothic UI", 15F);
            btn2.ForeColor = Color.White;
            btn2.Location = new Point(141, 504);
            btn2.Name = "btn2";
            btn2.Size = new Size(123, 95);
            btn2.TabIndex = 3;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += NumberButton_Click;
            // 
            // btn3
            // 
            btn3.BackColor = Color.FromArgb(60, 60, 60);
            btn3.FlatAppearance.BorderSize = 0;
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.Font = new Font("Yu Gothic UI", 15F);
            btn3.ForeColor = Color.White;
            btn3.Location = new Point(270, 504);
            btn3.Name = "btn3";
            btn3.Size = new Size(123, 95);
            btn3.TabIndex = 4;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += NumberButton_Click;
            // 
            // btn6
            // 
            btn6.BackColor = Color.FromArgb(60, 60, 60);
            btn6.FlatAppearance.BorderSize = 0;
            btn6.FlatStyle = FlatStyle.Flat;
            btn6.Font = new Font("Yu Gothic UI", 15F);
            btn6.ForeColor = Color.White;
            btn6.Location = new Point(270, 403);
            btn6.Name = "btn6";
            btn6.Size = new Size(123, 95);
            btn6.TabIndex = 7;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = false;
            btn6.Click += NumberButton_Click;
            // 
            // btn5
            // 
            btn5.BackColor = Color.FromArgb(60, 60, 60);
            btn5.FlatAppearance.BorderSize = 0;
            btn5.FlatStyle = FlatStyle.Flat;
            btn5.Font = new Font("Yu Gothic UI", 15F);
            btn5.ForeColor = Color.White;
            btn5.Location = new Point(141, 403);
            btn5.Name = "btn5";
            btn5.Size = new Size(123, 95);
            btn5.TabIndex = 6;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = false;
            btn5.Click += NumberButton_Click;
            // 
            // btn4
            // 
            btn4.BackColor = Color.FromArgb(60, 60, 60);
            btn4.FlatAppearance.BorderSize = 0;
            btn4.FlatStyle = FlatStyle.Flat;
            btn4.Font = new Font("Yu Gothic UI", 15F);
            btn4.ForeColor = Color.White;
            btn4.Location = new Point(12, 403);
            btn4.Name = "btn4";
            btn4.Size = new Size(123, 95);
            btn4.TabIndex = 5;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = false;
            btn4.Click += NumberButton_Click;
            // 
            // btn9
            // 
            btn9.BackColor = Color.FromArgb(60, 60, 60);
            btn9.FlatAppearance.BorderSize = 0;
            btn9.FlatStyle = FlatStyle.Flat;
            btn9.Font = new Font("Yu Gothic UI", 15F);
            btn9.ForeColor = Color.White;
            btn9.Location = new Point(270, 302);
            btn9.Name = "btn9";
            btn9.Size = new Size(123, 95);
            btn9.TabIndex = 10;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = false;
            btn9.Click += NumberButton_Click;
            // 
            // btn8
            // 
            btn8.BackColor = Color.FromArgb(60, 60, 60);
            btn8.FlatAppearance.BorderSize = 0;
            btn8.FlatStyle = FlatStyle.Flat;
            btn8.Font = new Font("Yu Gothic UI", 15F);
            btn8.ForeColor = Color.White;
            btn8.Location = new Point(141, 302);
            btn8.Name = "btn8";
            btn8.Size = new Size(123, 95);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = false;
            btn8.Click += NumberButton_Click;
            // 
            // btn7
            // 
            btn7.BackColor = Color.FromArgb(60, 60, 60);
            btn7.FlatAppearance.BorderSize = 0;
            btn7.FlatStyle = FlatStyle.Flat;
            btn7.Font = new Font("Yu Gothic UI", 15F);
            btn7.ForeColor = Color.White;
            btn7.Location = new Point(12, 302);
            btn7.Name = "btn7";
            btn7.Size = new Size(123, 95);
            btn7.TabIndex = 8;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = false;
            btn7.Click += NumberButton_Click;
            // 
            // btnRedo
            // 
            btnRedo.BackColor = Color.FromArgb(60, 60, 60);
            btnRedo.FlatAppearance.BorderSize = 0;
            btnRedo.FlatStyle = FlatStyle.Flat;
            btnRedo.ForeColor = Color.White;
            btnRedo.Location = new Point(141, 201);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(123, 95);
            btnRedo.TabIndex = 12;
            btnRedo.Text = "Redo";
            btnRedo.UseVisualStyleBackColor = false;
            btnRedo.Click += RedoButton_Click;
            // 
            // btnDot
            // 
            btnDot.BackColor = Color.FromArgb(60, 60, 60);
            btnDot.FlatAppearance.BorderSize = 0;
            btnDot.FlatStyle = FlatStyle.Flat;
            btnDot.Font = new Font("Yu Gothic UI", 15F);
            btnDot.ForeColor = Color.White;
            btnDot.Location = new Point(270, 605);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(123, 95);
            btnDot.TabIndex = 13;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = false;
            btnDot.Click += DotButton_Click;
            // 
            // btnEqual
            // 
            btnEqual.BackColor = Color.FromArgb(60, 60, 60);
            btnEqual.FlatAppearance.BorderSize = 0;
            btnEqual.FlatStyle = FlatStyle.Flat;
            btnEqual.Font = new Font("Yu Gothic UI", 15F);
            btnEqual.ForeColor = Color.White;
            btnEqual.Location = new Point(399, 605);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(123, 95);
            btnEqual.TabIndex = 14;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = false;
            btnEqual.Click += EqualButton_Click;
            // 
            // btnAddition
            // 
            btnAddition.BackColor = Color.FromArgb(60, 60, 60);
            btnAddition.FlatAppearance.BorderSize = 0;
            btnAddition.FlatStyle = FlatStyle.Flat;
            btnAddition.Font = new Font("Yu Gothic UI", 15F);
            btnAddition.ForeColor = Color.White;
            btnAddition.Location = new Point(399, 504);
            btnAddition.Name = "btnAddition";
            btnAddition.Size = new Size(123, 95);
            btnAddition.TabIndex = 15;
            btnAddition.Text = "+";
            btnAddition.UseVisualStyleBackColor = false;
            btnAddition.Click += OperationButton_Click;
            // 
            // btnSubtraction
            // 
            btnSubtraction.BackColor = Color.FromArgb(60, 60, 60);
            btnSubtraction.FlatAppearance.BorderSize = 0;
            btnSubtraction.FlatStyle = FlatStyle.Flat;
            btnSubtraction.Font = new Font("Yu Gothic UI", 15F);
            btnSubtraction.ForeColor = Color.White;
            btnSubtraction.Location = new Point(399, 403);
            btnSubtraction.Name = "btnSubtraction";
            btnSubtraction.Size = new Size(123, 95);
            btnSubtraction.TabIndex = 16;
            btnSubtraction.Text = "-";
            btnSubtraction.UseVisualStyleBackColor = false;
            btnSubtraction.Click += OperationButton_Click;
            // 
            // btnMultiplication
            // 
            btnMultiplication.BackColor = Color.FromArgb(60, 60, 60);
            btnMultiplication.FlatAppearance.BorderSize = 0;
            btnMultiplication.FlatStyle = FlatStyle.Flat;
            btnMultiplication.Font = new Font("Yu Gothic UI", 15F);
            btnMultiplication.ForeColor = Color.White;
            btnMultiplication.Location = new Point(399, 302);
            btnMultiplication.Name = "btnMultiplication";
            btnMultiplication.Size = new Size(123, 95);
            btnMultiplication.TabIndex = 17;
            btnMultiplication.Text = "×";
            btnMultiplication.UseVisualStyleBackColor = false;
            btnMultiplication.Click += OperationButton_Click;
            // 
            // btnDivision
            // 
            btnDivision.BackColor = Color.FromArgb(60, 60, 60);
            btnDivision.FlatAppearance.BorderSize = 0;
            btnDivision.FlatStyle = FlatStyle.Flat;
            btnDivision.Font = new Font("Yu Gothic UI", 15F);
            btnDivision.ForeColor = Color.White;
            btnDivision.Location = new Point(399, 201);
            btnDivision.Name = "btnDivision";
            btnDivision.Size = new Size(123, 95);
            btnDivision.TabIndex = 18;
            btnDivision.Text = "÷";
            btnDivision.UseVisualStyleBackColor = false;
            btnDivision.Click += OperationButton_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(60, 60, 60);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Yu Gothic UI", 15F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(270, 201);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(123, 95);
            btnClear.TabIndex = 19;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += ClearButton_Click;
            // 
            // TextBoxExpression
            // 
            TextBoxExpression.BackColor = Color.FromArgb(32, 32, 32);
            TextBoxExpression.BorderStyle = BorderStyle.None;
            TextBoxExpression.ForeColor = Color.DarkGray;
            TextBoxExpression.Location = new Point(13, 67);
            TextBoxExpression.Margin = new Padding(4, 2, 4, 2);
            TextBoxExpression.Multiline = true;
            TextBoxExpression.Name = "TextBoxExpression";
            TextBoxExpression.Size = new Size(503, 55);
            TextBoxExpression.TabIndex = 22;
            TextBoxExpression.TextAlign = HorizontalAlignment.Right;
            // 
            // TextBoxDisplay
            // 
            TextBoxDisplay.BackColor = Color.FromArgb(32, 32, 32);
            TextBoxDisplay.BorderStyle = BorderStyle.None;
            TextBoxDisplay.Font = new Font("Yu Gothic UI", 14F);
            TextBoxDisplay.ForeColor = Color.DarkGray;
            TextBoxDisplay.Location = new Point(12, 126);
            TextBoxDisplay.Margin = new Padding(4, 2, 4, 2);
            TextBoxDisplay.Multiline = true;
            TextBoxDisplay.Name = "TextBoxDisplay";
            TextBoxDisplay.Size = new Size(510, 69);
            TextBoxDisplay.TabIndex = 21;
            TextBoxDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // PanelHeader
            // 
            PanelHeader.Controls.Add(BtnClose);
            PanelHeader.Controls.Add(label1);
            PanelHeader.Location = new Point(13, -4);
            PanelHeader.Name = "PanelHeader";
            PanelHeader.Size = new Size(509, 53);
            PanelHeader.TabIndex = 23;
            PanelHeader.MouseDown += FormMouseDown;
            // 
            // BtnClose
            // 
            BtnClose.BackColor = Color.Transparent;
            BtnClose.FlatAppearance.BorderSize = 0;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Font = new Font("Meiryo UI", 9F);
            BtnClose.ForeColor = Color.White;
            BtnClose.Location = new Point(454, 5);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(41, 40);
            BtnClose.TabIndex = 1;
            BtnClose.Text = "×";
            BtnClose.UseVisualStyleBackColor = false;
            BtnClose.Click += CloseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(120, 32);
            label1.TabIndex = 0;
            label1.Text = "Calculator";
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(533, 709);
            Controls.Add(PanelHeader);
            Controls.Add(TextBoxExpression);
            Controls.Add(TextBoxDisplay);
            Controls.Add(btnClear);
            Controls.Add(btnDivision);
            Controls.Add(btnMultiplication);
            Controls.Add(btnSubtraction);
            Controls.Add(btnAddition);
            Controls.Add(btnEqual);
            Controls.Add(btnDot);
            Controls.Add(btnRedo);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btn0);
            Controls.Add(btnUndo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CalculatorForm";
            Text = "電卓";
            PanelHeader.ResumeLayout(false);
            PanelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUndo;
        private Button btn0;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btnRedo;
        private Button btnDot;
        private Button btnEqual;
        private Button btnAddition;
        private Button btnSubtraction;
        private Button btnMultiplication;
        private Button btnDivision;
        private Button btnClear;
        private TextBox TextBoxExpression;
        private TextBox TextBoxDisplay;
        private Panel PanelHeader;
        private Label label1;
        private Button BtnClose;
    }
}
