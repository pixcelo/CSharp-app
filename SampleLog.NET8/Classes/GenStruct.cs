namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// 値型の制約を持つジェネリッククラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenStruct<T> where T : struct
    {
        public string Key { get; set; }
        public T Value { get; set; }

        public void Run()
        {
            // 値型の制約でnullを許可しない
            //if (this.Value == null) { }

            Console.WriteLine($"Key: {Key}, Value: {Value}");
        }
    }

    /// <summary>
    /// ジェネリッククラスを使用するクライアントクラス
    /// </summary>
    public class ClientB
    {
        /// <summary>
        /// 参照型は制約により指定できない
        /// </summary>
        public static void Use()
        {
            //var a = new GenStruct<Form>(); // コンパイルエラー
            var b = new GenStruct<int>(); // OK
            var c = new GenStruct<double>(); // OK
            var d = new GenStruct<decimal>(); // OK
            var e = new GenStruct<float>(); // OK
            var f = new GenStruct<Point>(); // OK
            //var g = new GenStruct<string>(); // コンパイルエラー
        }
    }
}
