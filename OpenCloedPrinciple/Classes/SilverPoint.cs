using System;

namespace OpenCloedPrinciple.Classes
{
    /// <summary>
    /// シルバー会員ポイントクラス
    /// </summary>
    public class SilverPoint : IPoint
    {
        public int GetPoint(int price)
        {
            return Convert.ToInt32(price * 0.02f);
        }
    }
}
