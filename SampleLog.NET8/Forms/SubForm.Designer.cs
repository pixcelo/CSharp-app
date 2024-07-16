namespace SampleLog.NET8.Forms
{
    partial class SubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            checkBox1 = new CheckBox();
            productCsvButton = new Button();
            dataGridView1 = new DataGridView();
            stockCsvButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ButtonShadow;
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new Point(0, 263);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(checkBox1);
            splitContainer1.Size = new Size(800, 187);
            splitContainer1.SplitterDistance = 357;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(167, 8);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // productCsvButton
            // 
            productCsvButton.Location = new Point(12, 21);
            productCsvButton.Name = "productCsvButton";
            productCsvButton.Size = new Size(123, 23);
            productCsvButton.TabIndex = 1;
            productCsvButton.Text = "product csv";
            productCsvButton.UseVisualStyleBackColor = true;
            productCsvButton.Click += productCsvButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(512, 150);
            dataGridView1.TabIndex = 2;
            // 
            // stockCsvButton
            // 
            stockCsvButton.Location = new Point(150, 21);
            stockCsvButton.Name = "stockCsvButton";
            stockCsvButton.Size = new Size(123, 23);
            stockCsvButton.TabIndex = 3;
            stockCsvButton.Text = "stock csv";
            stockCsvButton.UseVisualStyleBackColor = true;
            stockCsvButton.Click += stockCsvButton_Click;
            // 
            // SubForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(stockCsvButton);
            Controls.Add(dataGridView1);
            Controls.Add(productCsvButton);
            Controls.Add(splitContainer1);
            Name = "SubForm";
            Text = "SubForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private CheckBox checkBox1;
        private Label label1;
        private Button productCsvButton;
        private DataGridView dataGridView1;
        private Button stockCsvButton;
    }
}