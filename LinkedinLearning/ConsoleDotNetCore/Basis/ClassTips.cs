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

            // 匿名型の宣言
            var person = new { name = "Tom", age = 20 };
            Console.WriteLine(person.name); // メンバーは読み取り専用

            // 匿名型の使いどころ
            int[] intArray = { 1, 3, 5, 6 };
            var list = intArray.Select((v, i) => new { value = v, index = i });
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

        private int[] _intArray = { 3, 4, 8, 7 };

        // インデクサ 配列のように添え字でアクセス可能にする　例： ClassTips[0]
        // 使いどころ：自作のコレクションクラスを作成する
        // 公式が詳しい　https://learn.microsoft.com/ja-jp/dotnet/csharp/indexers
        public int this[int i]
        {
            set { _intArray[i] = value; }
            get { return _intArray[i];}
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
