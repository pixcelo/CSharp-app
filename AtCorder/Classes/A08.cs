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
    internal class A08 // Two Dimensional Sum
    {
        /*
        https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_h

        問題文
        H × W のマス目があります．上からi行目，左からj列目にあるマス (i,j) には，整数Xi,j​が書かれています． 
        これについて，以下の Q 個の質問に答えるプログラムを作成してください．
            ・i 個目の質問：左上 (Ai,Bi) 右下 (Ci,Di) の長方形領域に書かれた整数の総和は？

        制約
        1≤H,W≤1500
        1≤Q≤100000
        0≤Xi,j≤9
        1≤Ai≤Ci≤H
        1≤Bi≤Di≤W
        入力はすべて整数

        入力
        入力は以下の形式で標準入力から与えられます．
        H W
        X1,1 X1,2 ⋯ X1,W
        ⋮
        XH,1 XH,2 ⋯ XH,W
        Q
        A1 B1 C1 D1
        ⋮
        AQ BQ CQ DQ
​
        出力
        Q 行にわたって出力してください．i行目には，質問iの答えを出力してください．

        入力例
        5 5
        2 0 0 5 1
        1 0 3 0 0
        0 8 5 0 2
        4 1 0 0 6
        0 9 2 7 0
        2
        2 2 4 5
        1 1 5 5

        出力例
        25
        56

        */

        public void Run()
        {
            while (true)
            {
                int[] hw = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int h = hw[0];
                int w = hw[1];
                int[,] grid = new int[h, w];

                for (int i = 0; i < h; i++)
                {
                    int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                    for (int j = 0; j < w; j++)
                    {
                        grid[i, j] = row[j];
                    }
                }
                
            }
        }
        
    }
}
