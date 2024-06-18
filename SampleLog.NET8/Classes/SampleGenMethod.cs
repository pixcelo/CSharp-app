namespace Gen
{
    /// <summary>
    /// 実装サンプル
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            //StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new ProductCsv();
            //dataGridView1.DataSource = product.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var stock = new StockCsv();
            //dataGridView1.DataSource = stock.GetAll();
        }
    }

    public class CsvException : Exception
    { }

    public interface IEntity
    {
        public int Id { get; }
    }

    public class ProductEntity : IEntity
    {
        public ProductEntity(int id, string productName, int price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }

        public int Id { get; }
        public string ProductName { get; }
        public int Price { get; }
    }

    public class StockEntity : IEntity
    {
        public StockEntity(int id, int stockCount)
        {
            Id = id;
            StockCount = stockCount;
        }

        public int Id { get; }
        public int StockCount { get; }
    }

    /// <summary>
    /// ジェネリックメソッドを提供するクラス
    /// </summary>
    public static class CsvHelper
    {
        public static IEnumerable<T> GetAll<T>(
          string path,
          int itemCount,
          Func<string[], T> func)
        {
            var lines = File.ReadAllLines(path);
            bool isFirst = true;
            var entities = new List<T>();
            foreach (var line in lines)
            {
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }

                var items = line.Split(',');
                if (items.Length != itemCount)
                {
                    throw new CsvException();
                }

                // デリゲートで個別の処理を渡す
                var entity = func(items);
                entities.Add(entity);
            }

            return entities;
        }
    }

    /// <summary>
    /// ジェネリックメソッドを使用するクラス
    /// </summary>
    public class ProductCsv
    {
        public IEnumerable<ProductEntity> GetAll()
        {
            return CsvHelper.GetAll("Product.csv", 3, GetEntity);
        }

        private ProductEntity GetEntity(string[] items)
        {
            return new ProductEntity(Convert.ToInt32(items[0]),
                                     items[1],
                                     Convert.ToInt32(items[2]));
        }
    }

    /// <summary>
    /// ジェネリックメソッドを使用するクラス
    /// </summary>
    public class StockCsv
    {
        public IEnumerable<StockEntity> GetAll()
        {
            return CsvHelper.GetAll("Stock.csv", 2, GetEntity);
        }

        private StockEntity GetEntity(string[] items)
        {
            return new StockEntity(Convert.ToInt32(items[0]),
                                   Convert.ToInt32(items[1]));
        }
    }
}