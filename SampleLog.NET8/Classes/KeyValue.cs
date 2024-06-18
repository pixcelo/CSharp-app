namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// ジェネリッククラス
    /// </summary>
    /// <see href="https://learn.microsoft.com/ja-jp/dotnet/api/system.collections.generic?view=net-8.0"/>
    /// <typeparam name="T"></typeparam>
    public class KeyValue<T> where T : notnull
    {
        public string Key { get; set; }
        public T Value { get; set; }
    }

    public class ClientKeyValue
    {
        public static void Use()
        {
            var a = new KeyValue<int>();
            var b = new KeyValue<string>();

            // notnull制約をつけると、null許容コンテキストが有効の場合のみ警告がでる（コンパイルは通る）
            // https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
            // https://learn.microsoft.com/ja-jp/dotnet/csharp/nullable-references#nullable-contexts
            var c = new KeyValue<int?>();
            var d = new KeyValue<string?>();
        }

    }
}
