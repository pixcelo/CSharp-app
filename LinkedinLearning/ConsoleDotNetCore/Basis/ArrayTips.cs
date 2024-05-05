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

            foreach (var item in items )
            {
                Console.WriteLine(item);
            }
        }
    }
}
