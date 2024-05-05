using ConsoleDotNetFramework.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // コンソールアプリは Ctr + F5 で起動
            Console.WriteLine("Hello World");
            Console.WriteLine("===========");

            var model = new SwitchTips();
            model.Run();

            // 動的な変数の宣言 
            //dynamic dynamicValue = 3;
            //dynamicValue = "abc";
            //dynamicValue.SomeMethod();

            // 複数の引数を渡す
            //int Sum(params int[] a)
            //{
            //    return a[0] + a[1];
            //}
        }
    }
}
