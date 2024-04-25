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
    internal class A07 // Event Attendance
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_g

        問題文
        ある会社では D 日間にわたってイベントが開催され，N 人が出席します．
        参加者 i は Li日目から Ri​日目まで出席する予定です．各日の出席者数を出力するプログラムを作成してください．

        制約
        1 ≤ D, N ≤ 10^5
        1 ≤ Li ≤ Ri ≤ D
        入力はすべて整数

        入力
        入力は以下の形式で与えられる。
        D
        N
        L1 R1
        ⋮
        LN RN

        出力
        D行にわたって出力してください．d行目には，d日目の出席者数を出力してください．

        */

        public void Run()
        {
            while (true)
            {
                int D = int.Parse(Console.ReadLine());
                int N = int.Parse(Console.ReadLine());
                int[] L = new int[D];
                int[] R = new int[D];

                for (int i = 0; i < N; i++)
                {
                    int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    L[i] = list[0];
                    R[i] = list[1];
                }

                // 各実施日の出席者数を配列にする
                int[] s = new int[D];
 
                for (int i = 0; i < N; i++)
                {
                    var nums = Enumerable.Range(L[i], (R[i] - L[i] + 1));

                    foreach (var num in nums)
                    {
                        s[num - 1] += 1;
                    }
                }

                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }
        
    }
}
