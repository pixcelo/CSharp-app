using SampleLog.NET8.Classes;

namespace SampleLog.NET8.Forms
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            var keyValue = new KeyValue<string>();
            keyValue.Key = "Key";
            keyValue.Value = "1";
        }

        private void productCsvButton_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("Product.csv");
            bool isFirst = true;
            var entities = new List<ProductEntity>();
            foreach (var line in lines)
            {
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }

                var values = line.Split(',');
                if (values.Length != 3)
                {
                    throw new CsvException();
                }

                var product = new ProductEntity(
                    Convert.ToInt32(values[0]),
                    values[1],
                    Convert.ToInt32(values[2])
                );

                entities.Add(product);
            }

            dataGridView1.DataSource = entities;
        }

        public class CsvException : Exception {}

        /// <summary>        
        /// CSVファイルの1行を表すクラス
        /// </summary>
        public class ProductEntity
        {
            public ProductEntity(int id, string productName, int price)
            {
                this.Id = id;
                this.ProductName = productName;
                this.Price = price;
            }

            public int Id { get; }
            public string ProductName { get; }
            public int Price { get; }
        }
    }
}
