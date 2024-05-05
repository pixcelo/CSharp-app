using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.Basis
{
    public class LiteralTips
    {
        public void Run()
        {
            long longValue;

            // 3桁区切りで見やすくしたいが、こちらの書き方はコンパイルエラー
            //longValue = 123,456;

            // 個の書き方でもいける
            //longValue = long.Parse("123,456", System.Globalization.NumberStyles.Any);
            //Console.WriteLine(longValue.ToString()); // 123456

            // アンダーバーであれば冗長にならない C#6~
            longValue = 123_456;
            Console.WriteLine(longValue.ToString()); // 123456
        }
    }
}
