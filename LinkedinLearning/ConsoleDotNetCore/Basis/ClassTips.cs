using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class ClassTips
    {
        public void Run()
        {
            SomeMethod();
        }


        void SomeMethod()
        {
            int intValue = 3;

            // ローカル関数
            int f(int i) => i * 2;

            int result = f(intValue);
            Console.WriteLine(result);
            　
            return;
        }

        // propf tab tabで入力できる
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        // ファイナライザー（デストラクタ）
        // https://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/finalizers

        // .NET Frameworkではアプリケーション終了時にファイナライザーが起動するが、.NET Coreでは実行されない
        // https://github.com/dotnet/csharpstandard/issues/291
        ~ClassTips()
        {
            Console.WriteLine("デストラクタが呼び出されました。");
        }
    }
}
