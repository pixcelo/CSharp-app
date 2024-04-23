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
    internal class A06 // How Many Guests? 
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/math_and_algorithm_ai

        問題文
        遊園地「ALGO-RESORT」では N 日間にわたるイベントが開催され、 i 日目 (1≤i≤N) には Ai​人が来場しました。

        以下の合計 Q 個の質問に答えるプログラムを作成してください。
        1 個目の質問：L 1日目から R 1 日目までの合計来場者数は？
        2 個目の質問：L 2  日目から R2 日目までの合計来場者数は？
        :
        Q 個目の質問：L Q  日目から R Q 日目までの合計来場者数は？

        制約
        1≤N,Q≤10^5
        1≤Ai≤10000
        1≤Li≤Ri≤N
        入力はすべて整数

        入力
        入力は以下の形式で与えられる。
        N Q
        A1 A2⋯ AN​
        L1 R1
        L2 R2
        :
        LQ RQ

        出力
        全体で Q 行出力してください。
        i 行目  (1≤i≤Q) には、i 個目の質問への答えを整数で出力してください。

        入力例
        10 5 // 10日間、5個の質問
        8 6 9 1 2 1 10 100 1000 10000 // 来場者数の配列
        2 3 // 以下、質問（2日目から3日目の来場者数）
        1 4
        3 9
        6 8
        1 10

        */

        public void Run()
        {
            while (true)
            {
                int[] l1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int N = l1[0];
                int Q = l1[1];

                int[] l2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var list = new List<int[]>();
                int counter = 0;
                
                while (counter < Q)
                {
                    var arry = new int[2];
                    arry = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    list.Add(arry);
                    counter++;
                }

                // このやり方では、時間制限超過となってしまう
                //foreach (var item in list)
                //{
                //    var skipCount = item[0] - 1;
                //    var takeCount = (item[1] + 1) - item[0];
                //    Console.WriteLine(l2.Skip(skipCount).Take(takeCount).Sum());
                //}
                

                // 累積和を求めるため、予め各インデックスまでの総和を格納したリストを作成する
                long[] s = new long[N + 1];
                s[0] = l2[0];

                for (int i = 0; i < N; i++)
                {
                    s[i + 1] = s[i] + l2[i];
                }

                foreach (var item in list)
                {
                    // 例えば3～4番目の総和を求める場合、2番目（1つ前）までの累積和を引けば良い
                    Console.WriteLine(s[item[1]] - s[item[0] - 1]);
                }

            }
        }
        
    }
}
