using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleDotNetCore.Delegate
{
    public class DelegeteTips
    {
        // デリゲート型の宣言
        public delegate void SampleDel(string m);        

        public void Run()
        {
            // SampleDel型の変数をインスタンス化
            //SampleDel del = new SampleDel(DelegeteMethod);
            SampleDel del = DelegeteMethod;

            // デリゲート型の関数を実行
            del("Hello Delegete.");

            // デリゲートを利用して、呼び出し時に動的にメソッドを呼び分けることが可能

            // 定義済みデリゲートの使用（宣言が不要）
            Action<string> del2 = DelegeteMethod;
            del2("del2");

            // 引数無し、stringを返すデリゲート ※複数の型がある場合、最後の型が戻り値の型となる
            Func<string> del3 = DeletegeFunc;
            Console.WriteLine("del3 " + del3());

            // 匿名メソッドを使用したデリゲート型の変数の定義
            SampleDel del4 = delegate (string m)
            {
                Console.WriteLine(m);
            };

            del4("Anoymous Method");
        }

        public static void DelegeteMethod(string message)
        {
            Console.WriteLine(message);
        }

        public string DeletegeFunc()
        {
            return "DeletegeFunc";
        }

        /// <summary>
        /// マルチキャストデリゲートの確認用 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public delegate int intDel(int n);
        public intDel? del;

        public int RunMultiCast()
        {
            // マルチキャストデリゲートの宣言
            del = DelegateMethod1;
            del += DelegateMethod2;

            var list = del.GetInvocationList();
            var result = 0;

            // マルチキャストデリゲートの実行
            foreach (var method in list)
            {
                result += ((intDel)method)(1);
            }
            
            return result;
        }

        public int DelegateMethod1(int n)
        {
            return n += 3;
        }

        public int DelegateMethod2(int n)
        {
            return n += 4;
        }
    }
}
