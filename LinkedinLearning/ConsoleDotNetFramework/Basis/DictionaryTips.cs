using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.Basis
{
    public class Dictionary01
    {
        public void Run()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("key1", "value1");
            dict.Add("key2", "value2");
            dict.Add("key3", "value3");

            /*
                ContainsKeyでの確認は、通常では問題がないが
                別のスレッドによってキーが削除される可能性は残る
            */

            string result = "";

            if (dict.ContainsKey("key2"))
            {
                result = dict["key2"];
            }

            // こちらの書き方なら、値が取得できた場合のみ実行可能となる
            if (dict.TryGetValue("key2", out result))
            {
                // 値が取得できた場合の処理
                Console.WriteLine(result);
            }
            else
            {
                // 値が取得できなかった場合の処理
                Console.WriteLine("値が取得できませんでした。");
            }
        }        
    }
}
