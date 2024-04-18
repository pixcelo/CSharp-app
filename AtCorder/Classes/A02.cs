using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Classes
{
    internal class A02
    {
        /*
        
        問題文
        N 個の整数 A1,A2,⋯,A Nの中に、整数 X が含まれるかどうかを判定するプログラムを作成してください。

        制約
        N は 1 以上 100 以下の整数
        X は 1 以上 100 以下の整数
        A1,A2,⋯,A N　は 1 以上 100 以下の整数

        入力
        入力は以下の形式で与えられる。
        N X
        A1,A2,⋯,A N

        出力
        整数 X が含まれるとき Yes、含まれないとき No と出力してください。

        */

        public void Run()
        {
            while (true)
            {
                int[] nx = Console.ReadLine().Split().Select(int.Parse).ToArray();
                //int n = nx[0];
                int x = nx[1];

                int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

                //string result = "No";

                //for (int i = 0; i < n - 1; i++)
                //{
                //    if (x == b[i])
                //    {
                //        result = "Yes";
                //    }
                //}

                string result = b.Contains(x) ? "Yes" : "No";

                Console.WriteLine(result);
            }
        }
    }
}
