using OpenCloedPrinciple.Classes;
using System;
using System.Windows.Forms;

namespace OpenCloedPrinciple.Views
{
    public partial class PointForm : Form
    {
        private readonly string cardNumber;
        private readonly IPoint point;

        public PointForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cardNumber"></param>
        public PointForm(string cardNumber) : this()
        {
            this.cardNumber = cardNumber;
            this.point = PointFactory.CreatePoint(cardNumber);
        }

        /// <summary>
        /// Pointボタン（機能拡張に弱い例：NGパターン）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ng_pointButton_Click(object sender, EventArgs e)
        {
            int price = 100;

            // 1%のポイントを付与する仕様
            //int point = Convert.ToInt32(price * 0.01f);
            //this.pointLabel.Text = $"{point.ToString()}p";

            // 上記のポイント付与条件に仕様変更があった場合、修正に閉じられていないため
            // 仕様変更があるたびに条件分岐を修正する必要がある
            int point;
            if (this.cardNumber.StartsWith("P"))
            {
                point = Convert.ToInt32(price * 0.02f);
            }
            else
            {
                point = Convert.ToInt32(price * 0.01f);
            }

            this.pointLabel.Text = $"{point.ToString()}p";

            // さらに言えば、画面にビジネスロジックを書いてしまっているため、
            // 本来は修正する必要のない画面クラスが修正対象となってしまう
        }

        /// <summary>
        /// Pointボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pointButton_Click(object sender, EventArgs e)
        {
           int price = 100;
           this.pointLabel.Text = $"{this.point.GetPoint(price).ToString()}p";
        }

    }
}
