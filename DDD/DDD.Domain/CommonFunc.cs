using System;

namespace DDD.Domain
{
    /// <summary>
    /// 共通の機能クラス
    /// </summary>
    public static class CommonFunc
    {
        /// <summary>
        /// 小数点N桁までの文字列に変換
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static string RoundString(float value, int digit)
        {
            var temp = Convert.ToSingle(Math.Round(value, digit));
            return temp.ToString($"F{digit}");
        }
    }
}
