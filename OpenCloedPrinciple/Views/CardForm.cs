using OpenCloedPrinciple.Views;
using System;
using System.Windows.Forms;

namespace OpenCloedPrinciple
{
    public partial class CardForm : Form
    {
        public CardForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Readボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readButton_Click(object sender, EventArgs e)
        {
            using (var form = new PointForm(cardNumberTextBox.Text))
            {
                form.ShowDialog();
            }
        }
    }
}
