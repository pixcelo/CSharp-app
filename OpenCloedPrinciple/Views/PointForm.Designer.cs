namespace OpenCloedPrinciple.Views
{
    partial class PointForm
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
            this.pointButton = new System.Windows.Forms.Button();
            this.pointLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pointButton
            // 
            this.pointButton.Location = new System.Drawing.Point(133, 26);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(75, 23);
            this.pointButton.TabIndex = 0;
            this.pointButton.Text = "Point";
            this.pointButton.UseVisualStyleBackColor = true;
            this.pointButton.Click += new System.EventHandler(this.pointButton_Click);
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.Location = new System.Drawing.Point(163, 63);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(17, 12);
            this.pointLabel.TabIndex = 1;
            this.pointLabel.Text = "--";
            // 
            // PointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 99);
            this.Controls.Add(this.pointLabel);
            this.Controls.Add(this.pointButton);
            this.Name = "PointForm";
            this.Text = "PointForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pointButton;
        private System.Windows.Forms.Label pointLabel;
    }
}