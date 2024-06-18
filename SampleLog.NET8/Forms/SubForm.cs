﻿using SampleLog.NET8.Classes;

namespace SampleLog.NET8.Forms
{
    public partial class SubForm : Form
    {
        public SubForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #region イベントハンドラ        
        /// <summary>
        /// CSVファイルを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="CsvException"></exception>
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

        /// <summary>
        /// CSVファイルを読み込む
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stockCsvButton_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("Stock.csv");
            bool isFirst = true;
            var entities = new List<StockEntity>();
            foreach (var line in lines)
            {
                if (isFirst)
                {
                    isFirst = false;
                    continue;
                }

                var values = line.Split(',');
                if (values.Length != 2)
                {
                    throw new CsvException();
                }

                var stock = new StockEntity(
                    Convert.ToInt32(values[0]),                    
                    Convert.ToInt32(values[1])
                );

                entities.Add(stock);
            }

            dataGridView1.DataSource = entities;
        }
        #endregion

        #region エンティティクラス
        public class CsvException : Exception { }

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

        /// <summary>        
        /// CSVファイルの1行を表すクラス
        /// </summary>
        public class StockEntity
        {
            public StockEntity(int id, int stockCount)
            {
                this.Id = id;
                this.StockCount = stockCount;
            }

            public int Id { get; }
            public int StockCount { get; }
        }
        #endregion
    }
}
