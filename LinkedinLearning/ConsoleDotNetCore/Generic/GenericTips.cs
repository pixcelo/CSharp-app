using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Generic
{
    public class GenericTips
    {
        public void Run()
        {
            var geInt = new GeClass<int>();
            geInt.value = 3;

            Console.WriteLine(geInt.value);

            var geString = new GeClass<string>();
            geString.value = "aaa";

            Console.WriteLine(geString.value);

            // Func型
            Func<int, int> func = SomeMethod;

            // ジェネリックなクラスにリフレクションを使用する
            Type type = typeof(GeClass<int>);

            // ジェネリックかどうかを判定
            if (type.IsGenericType)
            {
                //Console.WriteLine("is Generic");

                // GetMethodにはメソッドの名前を渡す
                MethodInfo method = type.GetMethod("GeMethod");

                // ジェネリックなメソッドかどうかを判定
                if (method.IsGenericMethod) // methodがnullだとnullExceptionが発生
                {
                    // ジェネリックなメソッドの型パラメーターを指定
                    MethodInfo geMethod = method.MakeGenericMethod(typeof(int));

                    // メソッドを呼び出す
                    geMethod.Invoke(null, new object[] { 3 });
                }
            }
        }      

        public int SomeMethod(int i)
        {
            return i * 2;
        }

    }
}
