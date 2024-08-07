﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Helpers
{
    /// <summary>
    /// Float処理用のクラス
    /// </summary>
    public static class FloatHelper
    {
        /// <summary>
        /// 小数点N桁までの文字列に変換 (拡張メソッド)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static string RoundString(this float value, int digit)
        {
            var temp = Convert.ToSingle(Math.Round(value, digit));
            return temp.ToString($"F{digit}");
        }
    }
}
