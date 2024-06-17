using SampleLog.NET8.Forms;

namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// 参照型の制約を持つジェネリッククラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenClass<T> where T : class
    {
        public string Key { get; set; }
        public T? Value { get; set; }

        public void Run()
        {
            // 参照型の制約でnullを許可する
            if (this.Value == null) { }

            Console.WriteLine($"Key: {Key}, Value: {Value}");
        }
    }

    /// <summary>
    /// ジェネリッククラスを使用するクライアントクラス
    /// </summary>
    public class ClientC
    {
        public static void Use()
        {
            var a = new GenClass<Form>(); // OK
            var b = new GenClass<SubForm>(); // OK
            var c = new GenClass<string>(); // OK
            //var d = new GenClass<int>(); // コンパイルエラー
        }
    }
}
