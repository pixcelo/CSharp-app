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
    internal class A05 // Three Cards
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
                int[] nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
                //int n = nk[0];
                //int k = nk[1];

                //var list = Enumerable.Range(1, n + 1).ToList();
                //var result = 0;

                // これだと遅すぎる
                // int sum = nk[1];

                //for (int i = 1; i <= n; i++)
                //{
                //    for (int j = 1; j <= n; j++)
                //    {
                //        for (int k = 1; k <= n; k++)
                //        {
                //            if (i + j + k == sum)
                //            {
                //                result++;
                //            }
                //        }
                //    }
                //}

                // Console.WriteLine(result);

                // 1. カードの合計をKにするために、ある2枚のカードの合計をK - x(x = 1~N)にする
                // 2. 残りの1枚のカードの値はxとなる
                // 3. ある2枚のカードの合計がK - xになる組み合わせの数を数える

                int N = nk[0];
                int K = nk[1];

                long count = 0;
                for (int x = 1; x <= N; x++)
                {
                    int remaining = K - x;
                    if (remaining >= 1 && remaining <= 2 * N)
                    {
                        int ways = Count2Sum(N, remaining);
                        count += ways;
                    }
                }

                Console.WriteLine(count); 
            }
        }

        public static int Count2Sum(int N, int target)
        {
            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                int j = target - i;
                if (j >= 1 && j <= N)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
