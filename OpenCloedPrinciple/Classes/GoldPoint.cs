using System;

namespace OpenCloedPrinciple.Classes
{
    /// <summary>
    /// ゴールド会員ポイントクラス
    /// </summary>
    public class GoldPoint : IPoint
    {
        public int GetPoint(int price)
        {
            return Convert.ToInt32(price * 0.03f);
        }
    }
}
