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
}
