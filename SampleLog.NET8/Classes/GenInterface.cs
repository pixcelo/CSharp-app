namespace SampleLog.NET8.Classes
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public class Product : IEntity, IDisposable
    {
        public int Id { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// インターフェイスの制約を持つジェネリッククラス
    /// インターフェイスの制約は複数指定できる
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenInterface<T> where T : IEntity, IDisposable
    {
        private List<T> entities = new List<T>();

        public T? Find(int id)
        {
            // インターフェイスの制約があることでインターフェイスのプロパティを使用できる
            return this.entities.Find(x => x.Id == id);
        }
    }

    public class ClientD
    {
        public static void Use()
        {
            // インターフェイスを強制する制約
            var product = new GenInterface<Product>();
        }
    }

    /// <summary>
    /// コンストラクタ制約
    /// 使う側のクラスに空のコンストラクタが必要（またはコンストラクタなし）
    /// </summary>
    /// <see href="https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/keywords/new-constraint"/>
    /// <typeparam name="T"></typeparam>
    public class ClassA<T> where T : IEntity, new()
    {
        private T Value = new T();
        private List<T> entities = new List<T>();

        public T? Find(int id)
        {
            var result = this.entities.Find(x => x.Id == id);

            // コンストラクタ制約によって、値がnullの場合は
            // デフォルトのインスタンスを返すことができる
            if (result == null)
            {
                return new T();
            }

            return result;
        }
    }

}
