using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Generic
{
    /// <summary>
    /// ジェネリック型クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeClass<T>
    {
        public T value;

        public void SomeMethod(T arg)
        {
            Console.WriteLine(arg);
        }

        public static void GeMethod<T2>(T2 arg)
        {

        }
    }

    public class GeClass<T, T2>
    {
        public T value;
        public T2 value2;        
    }

    /// <summary>
    /// ジェネリック型クラスを継承する場合は型を指定する必要あり
    /// </summary>
    public class AClass : GeClass<int>{　}
    public class BClass<T> : GeClass<T>{　}

    public class CClass
    {
        // whereで制約を付けられる（下記は型パラメーターがstruct（値型）であることを制約とする）
        public void SomeMethod<T>(T arg)
            where T : struct
        {
            Console.WriteLine(arg);
        }

        public void SomeMethod2<T>(T arg)
            where T : class // class(参照型）に制約を指定する
        {
            Console.WriteLine(arg);
        }

        // 複数の型制約を記述可能
        public void SomeMethod3<T, T2>(T arg)
            where T : class, IDisposable, new()
            where T2 : class
        {
            Console.WriteLine(arg);
        }

    }

}
