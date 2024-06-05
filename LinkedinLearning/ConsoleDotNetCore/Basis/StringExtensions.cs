using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    /// <summary>
    /// 拡張メソッド
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// thisの後にくるクラスを継承せずに拡張する（この場合はstringクラス）
        /// 拡張メソッドはクラスのprivete変数を操作できない
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Report(this string str, int count)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                builder.Append(str);
            }
            return builder.ToString(); 
        }

        /// <summary>
        /// 拡張メソッドを呼び出す
        /// </summary>
        public static void Run()
        {
            var message = "Hello";
            var result = message.Report(5);
            Console.WriteLine(result);
        }
    }
}
