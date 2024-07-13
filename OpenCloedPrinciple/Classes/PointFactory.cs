namespace OpenCloedPrinciple.Classes
{
    /// <summary>
    /// ポイントファクトリー
    /// Gof : ファクトリーメソッドパターン
    /// 新しいポイントを作成する場合はPointクラスを追加して、
    /// 以下のCreatePointメソッドに条件分岐を追加する
    /// </summary>
    public class PointFactory
    {
        /// <summary>
        /// ポイントを作成する
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static IPoint CreatePoint(string cardNumber)
        {
            if (cardNumber.StartsWith("G"))
            {
                return new GoldPoint();
            }
            
            if (cardNumber.StartsWith("S"))
            {
                return new SilverPoint();
            }

            return new Point();
        }

    }
}
