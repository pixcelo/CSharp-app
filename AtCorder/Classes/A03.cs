using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCorder.Classes
{
    internal class A03 //Two Cards
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_c

        問題文
        赤いカードが N 枚あり、それぞれ整数 P 1​,P 2​,⋯,P Nが書かれています。
        また、青いカードが N 枚あり、それぞれ整数 Q 1,Q 2​,⋯,Q N​が書かれています。

        太郎君は、赤いカードの中から 1 枚、青いカードの中から 1 枚、合計 2 枚のカードを選びます。
        選んだ 2 枚のカードに書かれた整数の合計が K となるようにする方法は存在しますか。

        制約
        N は 1 以上 100 以下の整数
        K は 1 以上 100 以下の整数
        P1,P2,⋯,P N　は 1 以上 100 以下の整数
        Q1,Q2,⋯,Q N　は 1 以上 100 以下の整数

        入力
        入力は以下の形式で与えられる。
        N K
        P1,P2,⋯,P N
        Q1,Q2,⋯,Q N

        出力
        合計を K にする方法が存在するとき Yes、そうでないとき No を出力してください。

        */

        public void Run()
        {
            while (true)
            {
                int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int n = nk[0];
                int k = nk[1];

                int[] p = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int[] q = Console.ReadLine().Split().Select(int.Parse).ToArray();

                string result = "No";

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (p[i] + q[j] == k)
                        {
                            result = "Yes";
                            break;
                        }
                    }
                }
                
                Console.WriteLine(result);
            }
        }
    }
}
