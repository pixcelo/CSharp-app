namespace SampleLog
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnQR = new System.Windows.Forms.Button();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQR
            // 
            this.btnQR.Location = new System.Drawing.Point(487, 62);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(231, 95);
            this.btnQR.TabIndex = 0;
            this.btnQR.Text = "QRコード作成";
            this.btnQR.UseVisualStyleBackColor = true;
            this.btnQR.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.Location = new System.Drawing.Point(53, 62);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxQR.TabIndex = 1;
            this.pictureBoxQR.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 541);
            this.Controls.Add(this.pictureBoxQR);
            this.Controls.Add(this.btnQR);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQR;
        private System.Windows.Forms.PictureBox pictureBoxQR;
    }
}

