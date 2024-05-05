using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class ArrayTips
    {
        public void Run()
        {
            string[] array = { "a", "b", "c", "d", "e", "f" };
            string str = array[3];

            // 新しい書き方
            var index = new Index(value: 2);
            str = array[index];

            str = array[^2]; // 最後から2番目を取得

            //Console.WriteLine(str);

            Range range = 0..^1; // 0番目～最後から1番目を配列から取り出す

            var items = array[range];

            //foreach (var item in items )
            //{
            //    Console.WriteLine(item);
            //}


            // 数値に変換できる文字列だけ出力する
            var stringList = new List<string>()
            {
                "123",
                "456",
                "abc",
                "def",
            };

            foreach (var strValue in stringList)
            {
                // out の値は使用しないので _ で破棄する
                if (int.TryParse(strValue, out _))
                {
                    Console.WriteLine(strValue);
                }
            }

            // 変数の値を明示的に使用しない場合
            var (x, _) = GetPosition("Japan");
        }

        (int, int) GetPosition(string name)
        {
            return (10, 15);
        }
    }
}
