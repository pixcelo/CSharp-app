using System.ComponentModel;

namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// <out T>共変性ジェネリッククラス
    /// サブクラスとして動いて、基底クラスに型変換したいというケース等
    /// <see href="https://stackoverflow.com/questions/10956993/out-t-vs-t-in-generics"/>    
    /// <seealso href="https://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISample<out T>
    {
        /// <summary>
        /// outキーワードを付けると戻り値だけが許可される
        /// </summary>
        /// <param name="data"></param>
        //void SetData(T data); // コンパイルエラー

        /// <summary>
        /// 戻り値は暗黙の型変換でＴに固定できる
        /// </summary> 
        T GetData();

        T Value { get; }
        //T Value2 { set; } // setはコンパイルエラー
    }

    /// <summary>
    /// <in T>反変性ジェネリッククラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISample2<in T>
    {
        /// <summary>
        /// inキーワードを付けると引数だけが許可される
        /// </summary>
        /// <param name="data"></param>
        void SetData(T data);        

        //T GetData(); // コンパイルエラー
        //T Value { get; } // getはコンパイルエラー
        T Value2 { set; }
    }

    /// <summary>
    /// 使用する側のクラス
    /// </summary>
    public class GenOut
    {
        public static void Use()
        {
            var list = new Entites<Product1>();
            list.Add(new Product1(1, "A"));
            Read(list);
        }

        /// <summary>
        /// Product1型を継承元のIEntity1として受け取ることを許可できている
        /// </summary>
        /// <param name="entites"></param>
        private static void Read(IRead<IEntity1> entites)
        {
            var val = entites.GetData(0);
        }

        public static void UseB()
        {
            var list = new Entites<IEntity1>();
            // 親クラスListを派生クラスProduct1として変換できている
            WriteProduct(list);
        }

        /// <summary>
        /// 派生クラスが引数にある場合
        /// </summary>
        /// <param name="entites"></param>
        private static void WriteProduct(IWrite<Product1> entites)
        {
            entites.Add(new Product1(2, "B"));
        }
    }

    public interface IRead<out T>
    {
        T GetData(int index);
    }

    public interface IWrite<in T>
    {
        void Add(T entity);
    }

    /// <summary>
    /// 実装例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entites<T> : IRead<T>, IWrite<T>
    {
        private List<T> entities = new List<T>();

        public T GetData(int index)
        {
            return entities[index];
        }

        public void Add(T data)
        {
            entities.Add(data);
        }
    }

    public interface IEntity1
    {
        int Id { get; set; }
    }

    public class Product1 : IEntity1
    {
        public Product1(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// inを使うデリゲート
    /// </summary>
    public static class ActionUse
    {
        private static void Use()
        {
            Action<object> oo = CallBackObj;
            oo.Invoke(DateTime.Now);

            Action<string> ss = CallBackString;
            ss.Invoke("AAA");

            //Action<object> os = CallBackString; // コンパイルエラー

            Action<string> so = CallBackObj;
            so.Invoke("BBB"); // in句なので継承関係にある型変換を許す
        }

        private static void CallBackObj(object obj) { }
        private static void CallBackString(string s) { }
    }
}
