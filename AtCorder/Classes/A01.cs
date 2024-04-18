using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Classes
{
    internal class A01
    {
        /*
        
        問題文
        整数 N が与えられるので、一辺の長さが N であるような正方形の面積を出力するプログラムを作成してください。

        制約
        N は 1 以上 100 以下の整数

        入力
        入力は以下の形式で与えられる。
        N

        */

        public void Run()
        {
            while (true)
            {
                //// 整数の入力
                int a = int.Parse(Console.ReadLine());

                // 出力
                Console.WriteLine(a * a);
            }            
        }
    }
}
