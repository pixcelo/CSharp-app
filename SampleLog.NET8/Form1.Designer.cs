namespace SampleLog.NET8
{
    partial class Form1
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
            textBox1 = new TextBox();
            btnRedo = new Button();
            btnDot = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(611, 373);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(150, 46);
            btnUndo.TabIndex = 0;
            btnUndo.Text = "戻る";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Location = new Point(209, 496);
            btn0.Name = "btn0";
            btn0.Size = new Size(123, 95);
            btn0.TabIndex = 1;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Location = new Point(64, 373);
            btn1.Name = "btn1";
            btn1.Size = new Size(123, 95);
            btn1.TabIndex = 2;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(209, 373);
            btn2.Name = "btn2";
            btn2.Size = new Size(123, 95);
            btn2.TabIndex = 3;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn3
            // 
            btn3.Location = new Point(361, 373);
            btn3.Name = "btn3";
            btn3.Size = new Size(123, 95);
            btn3.TabIndex = 4;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Location = new Point(361, 260);
            btn6.Name = "btn6";
            btn6.Size = new Size(123, 95);
            btn6.TabIndex = 7;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Location = new Point(209, 260);
            btn5.Name = "btn5";
            btn5.Size = new Size(123, 95);
            btn5.TabIndex = 6;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Location = new Point(64, 260);
            btn4.Name = "btn4";
            btn4.Size = new Size(123, 95);
            btn4.TabIndex = 5;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Location = new Point(361, 146);
            btn9.Name = "btn9";
            btn9.Size = new Size(123, 95);
            btn9.TabIndex = 10;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Location = new Point(209, 146);
            btn8.Name = "btn8";
            btn8.Size = new Size(123, 95);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += button3_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(64, 146);
            btn7.Name = "btn7";
            btn7.Size = new Size(123, 95);
            btn7.TabIndex = 8;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(77, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(568, 39);
            textBox1.TabIndex = 11;
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(611, 296);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(150, 46);
            btnRedo.TabIndex = 12;
            btnRedo.Text = "進む";
            btnRedo.UseVisualStyleBackColor = true;
            // 
            // btnDot
            // 
            btnDot.Location = new Point(361, 496);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(123, 95);
            btnDot.TabIndex = 13;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(504, 496);
            button1.Name = "button1";
            button1.Size = new Size(123, 95);
            button1.TabIndex = 14;
            button1.Text = "=";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 617);
            Controls.Add(button1);
            Controls.Add(btnDot);
            Controls.Add(btnRedo);
            Controls.Add(textBox1);
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
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
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
        private TextBox textBox1;
        private Button btnRedo;
        private Button btnDot;
        private Button button1;
    }
}
