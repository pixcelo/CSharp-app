using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtCorder.Classes
{
    internal class A04 // Binary Representation 1 
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_d

        問題文
        整数 N が 10 進法表記で与えられます。
        N を 2 進法に変換した値を出力するプログラムを作成してください。

        制約
        N は 1 以上 1000 以下の整数        

        入力
        入力は以下の形式で与えられる。
        N

        出力
        N を 2 進法に変換した値を、10 桁で出力してください。
        桁数が足りない場合は、左側を 0 で埋めてください。

        */

        public void Run()
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine());

                // 2進数に変換
                string nStr = Convert.ToString(n, 2);

                // ゼロパディング
                string result = string.Format("{0:D10}", int.Parse(nStr));

                Console.WriteLine(result);
            }
        }
    }
}
