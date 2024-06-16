namespace DDD.WinForm.Views
{
    partial class WeatherSaveView
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.ConditionLabel = new System.Windows.Forms.Label();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.DateTimeTextBox = new System.Windows.Forms.DateTimePicker();
            this.AreaIdComboBox = new System.Windows.Forms.ComboBox();
            this.ConditionComboBox = new System.Windows.Forms.ComboBox();
            this.TemperatureTextBox = new System.Windows.Forms.TextBox();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(26, 24);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(27, 71);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(29, 12);
            this.AreaLabel.TabIndex = 1;
            this.AreaLabel.Text = "地域";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(26, 99);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(29, 12);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "日時";
            // 
            // ConditionLabel
            // 
            this.ConditionLabel.AutoSize = true;
            this.ConditionLabel.Location = new System.Drawing.Point(26, 126);
            this.ConditionLabel.Name = "ConditionLabel";
            this.ConditionLabel.Size = new System.Drawing.Size(29, 12);
            this.ConditionLabel.TabIndex = 3;
            this.ConditionLabel.Text = "状態";
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Location = new System.Drawing.Point(26, 155);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(29, 12);
            this.TemperatureLabel.TabIndex = 4;
            this.TemperatureLabel.Text = "温度";
            // 
            // DateTimeTextBox
            // 
            this.DateTimeTextBox.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.DateTimeTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimeTextBox.Location = new System.Drawing.Point(65, 95);
            this.DateTimeTextBox.Name = "DateTimeTextBox";
            this.DateTimeTextBox.Size = new System.Drawing.Size(153, 19);
            this.DateTimeTextBox.TabIndex = 5;
            // 
            // AreaIdComboBox
            // 
            this.AreaIdComboBox.FormattingEnabled = true;
            this.AreaIdComboBox.Location = new System.Drawing.Point(65, 67);
            this.AreaIdComboBox.Name = "AreaIdComboBox";
            this.AreaIdComboBox.Size = new System.Drawing.Size(121, 20);
            this.AreaIdComboBox.TabIndex = 6;
            // 
            // ConditionComboBox
            // 
            this.ConditionComboBox.FormattingEnabled = true;
            this.ConditionComboBox.Location = new System.Drawing.Point(65, 121);
            this.ConditionComboBox.Name = "ConditionComboBox";
            this.ConditionComboBox.Size = new System.Drawing.Size(121, 20);
            this.ConditionComboBox.TabIndex = 7;
            // 
            // TemperatureTextBox
            // 
            this.TemperatureTextBox.Location = new System.Drawing.Point(66, 153);
            this.TemperatureTextBox.Name = "TemperatureTextBox";
            this.TemperatureTextBox.Size = new System.Drawing.Size(100, 19);
            this.TemperatureTextBox.TabIndex = 8;
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(172, 156);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(19, 12);
            this.UnitLabel.TabIndex = 9;
            this.UnitLabel.Text = "XX";
            // 
            // WeatherSaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 234);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.TemperatureTextBox);
            this.Controls.Add(this.ConditionComboBox);
            this.Controls.Add(this.AreaIdComboBox);
            this.Controls.Add(this.DateTimeTextBox);
            this.Controls.Add(this.TemperatureLabel);
            this.Controls.Add(this.ConditionLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.AreaLabel);
            this.Controls.Add(this.SaveButton);
            this.Name = "WeatherSaveView";
            this.Text = "WeatherSaveView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label AreaLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label ConditionLabel;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.DateTimePicker DateTimeTextBox;
        private System.Windows.Forms.ComboBox AreaIdComboBox;
        private System.Windows.Forms.ComboBox ConditionComboBox;
        private System.Windows.Forms.TextBox TemperatureTextBox;
        private System.Windows.Forms.Label UnitLabel;
    }
}