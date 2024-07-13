using System;

namespace OpenCloedPrinciple.Classes
{
    /// <summary>
    /// スタンダード会員ポイントクラス
    /// </summary>
    public sealed class Point : IPoint
    {
        public int GetPoint(int price)
        {
            return Convert.ToInt32(price * 0.01f);
        }
    }
}
