using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Classes
{
    internal class Practice1
    {
        /*
        問題文
        高橋君はデータの加工が行いたいです。
        整数 a, b, cと、文字列 s が与えられます。 
        a+b+c の計算結果と、文字列 s を並べて表示しなさい。

        制約
        1≤a, b, c≤1,000
        1≤∣s∣≤100

        入力
        入力は以下の形式で与えられる。
        a
        b c
        s
        */

        public void Run()
        {
            // 整数の入力
            int a = int.Parse(Console.ReadLine());
            // スペース区切りの整数の入力
            string[] input = Console.ReadLine().Split(' ');
            int b = int.Parse(input[0]);
            int c = int.Parse(input[1]);
            // 文字列の入力
            string s = Console.ReadLine();
            //出力
            Console.WriteLine((a + b + c) + " " + s);

            //int a = int.Parse(Console.ReadLine());
            //int[] bc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //string s = Console.ReadLine();
            //Console.WriteLine(($"{a + bc[0] + bc[1]} {s}"));
        }
    }
}
