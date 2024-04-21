using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtCorder.Classes
{
    internal class A00 // Three Cards
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_e

        問題文
        赤・青・白の 3 枚のカードがあります。
        太郎君は、それぞれのカードに 1 以上 N 以下の整数を書かなければなりません。
        3 枚のカードの合計を K にするような書き方は何通りありますか。

        制約
        N は 1 以上 3000 以下の整数
        K は 3 以上 9000 以下の整数

        入力
        入力は以下の形式で与えられる。
        N K

        出力
        答えを整数で出力してください。

        */

        public void Run()
        {
            while (true)
            {
                var lines = Console.ReadLine().Split().Select(x => x).ToArray();
                int n = int.Parse(lines[lines.Length - 1]);

                bool result = false;
                int x = 0;

                foreach (var line in lines)
                {
                    var num = int.Parse(line.Split(':')[0]);
                    if (n % num == 0)
                    {
                        result = true;
                        x = num;
                    }
                }

                if (result)
                {
                    Console.WriteLine(x);
                }
                else
                {
                    Console.WriteLine("invalid input");
                }

                
            }
        }        
    }
}
