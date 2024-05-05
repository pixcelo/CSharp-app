using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.Basis
{
    public class ArrayTips
    {
        public void Run()
        {
            string[] array = { "a", "b", "c", "d", "e", "f" };
            string str = array[3];

            // 新しい書き方
            //var index = new Index(Value:2);
            //str = array[index];

            Console.WriteLine(str);

            //str = array[^2]; // 最後から2番目を取得            
        }
    }
}
