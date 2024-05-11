using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleDotNetCore.Basis
{
    public class LinqTips
    {
        public void Run()
        {
            int[] intArray = { 1, 2, 3, 4, 5, 6 };

            // クエリ構文：「句」という単位で構成
            var queryList = from n in intArray where (n > 3) select n;

            // メソッド構文：クエリメソッドを直接呼び出す
            var methodList = intArray.Where(n => n > 3);

            //RunInto();
            //RunJoin();
            //RunLet();
            RunSkipTake();
        }

        private void RunSkipTake()
        {
            var list = Enumerable.Range(1, 20);

            var result = list.Skip(2).Take(5);

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();

            // 10未満の要素をスキップ
            var result2 = list.SkipWhile(n => n < 10);

            foreach (var r in result2)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();

            // 10未満の要素だけ取得
            var result3 = list.TakeWhile(n => n < 10);

            foreach (var r in result3)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();

            // すべての要素が条件を満たしているか
            string[] fruits = { "apple", "banana", "cherry", "grape", "garpefruit" };
            bool a = fruits.All(s => s.Length >= 5); // すべての文字列が5文字以上か？

            // 要素が一つでもあるか
            bool b = fruits.Any();

            // いずれかの要素が条件を満たしているか
            bool c = fruits.Any(s => s.Length >= 8);
        }

        

        /// <summary>
        /// let句でクエリ内の変数を作成する
        /// </summary>
        private void RunLet()
        {
            string[] maxim =
            {
                "The grass is always greener on the other side of the fence.",
                "Too many cooks spoil the broth.",
                "Strike while the iron is hot."
            };

            // デリミタで区切って一つのコレクションに格納
            var result = from m in maxim
                         let words = m.Split(new
                            char[] { ' ', ',', ':', '\t', '\n' })
                         from word in words
                         where word.Trim() != ""
                         select word;

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }

        /// <summary>
        /// into句による継続
        /// </summary>
        private void RunInto()
        {
            string[] month =
            {
                "January",
                "Feburary",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "Septemper",
                "October",
                "November",
                "December"
            };

            // 1. 文字列の配列から8文字以上のものを取得
            // 2. erで終わるものを3文字に短縮し、末尾に「.」を付ける

            // into句：クエリの継続
            // 構文：into 新たな範囲変数 クエリ本体
            var result = from x in month
                         where x.Length >= 8
                         select x into y // ここで範囲変数 yに取得結果が格納される
                         where y.EndsWith("er")
                         select y.Substring(0, 3) + ".";

            foreach ( var y in result )
            {
                Console.WriteLine(y);
            }            
        }

        private void RunJoin()
        {
            var products = new List<Product>
            {
                new Product("P1", "デスクトップ"),
                new Product("P2", "ノートパソコン"),
                new Product("P3", "ハードディスク"),
                new Product("P4", "マウス"),
                new Product("P5", "キーボード"),
                new Product("P6", "ディスプレイ"),
                new Product("P7", "タブレット"),
            };

            var orders = new List<Order>
            {
                new Order("2024/5/1", "P2", 120),
                new Order("2024/5/15", "P1", 120),
                new Order("2024/5/22", "P4", 120),
                new Order("2024/5/30", "P8", 120),
                new Order("2024/6/1", "P1", 120),
                new Order("2024/6/8", "P3", 120),
            };

            // 内部結合
            var result = from p in products
                         join o in orders on p.Code equals o.Code
                         select new
                         {
                             OrderDate = o.OrderDate,
                             Name = p.Name,
                             Quantity = o.Quantity
                         };

            foreach (var o in result )
            {
                Console.WriteLine($"{o.OrderDate} {o.Name} {o.Quantity}");
            }
            Console.WriteLine();

            // 内部結合をメソッド構文に変換
            var result_method = products.Join(orders, p => p.Code, o => o.Code,
                                    (p, o) => new
                                    {
                                        OrderDate = o.OrderDate,
                                        Name = p.Name,
                                        Quantity = o.Quantity
                                    });

            /* グループ結合
               構文
                  from 範囲変数A in データソースA
                  join 範囲変数B in データソースB
                  on 範囲変数A.プロパティ equals 範囲変数B.プロパティ into 変数
            */

            // 製品別に何個売れたか？等を求める
            var result2 = from p in products
                          join o in orders on p.Code equals o.Code into grp
                          select new
                          {
                              Code = p.Code,
                              Name = p.Name,
                              pgrp = grp
                          };

            foreach (var r in result2)
            {
                Console.WriteLine($"{r.Code} {r.Name}");
                foreach (var r2 in r.pgrp)
                {
                    Console.WriteLine($"   {r2.OrderDate} {r2.Quantity}");
                }
            }
            Console.WriteLine();

            // メソッド構文での複数のグループ化の書き方
            var result3 = products.GroupJoin(
                            orders,
                            p => p.Code,
                            o => o.Code,
                            (p, grp) => new
                            {
                                Code = p.Code,
                                Name = p.Name,
                                pgrp = grp
                            });

            foreach (var r in result3)
            {
                Console.WriteLine($"{r.Code} {r.Name}");
                foreach (var r2 in r.pgrp)
                {
                    Console.WriteLine($"   {r2.OrderDate} {r2.Quantity}");
                }
            }
        }

        public void SelectCalender()
        {
            var calenders = new List<HistoryCalender>();

            var cal = new HistoryCalender();
            cal.Decade = "Seventies";
            cal.Years = Enumerable.Range(1970, 10).ToList();
            calenders.Add(cal);

            cal = new HistoryCalender();
            cal.Decade = "Eighties";
            cal.Years = Enumerable.Range(1980, 10).ToList();
            calenders.Add(cal);

            var selectResult = calenders.Select(m => m);
            var manyResult = calenders.SelectMany(m => m.Years);
        }

        public class HistoryCalender
        {
            public string Decade { get; set; }
            public List<int> Years { get; set; }
        }

        public class Product
        {
            public Product(string code, string name)
            {
                Code = code;
                Name = name;
            }

            public string Code { get; set; }
            public string Name { get; set; }
        }

        public class Order
        {
            public Order(string orderDate, string code, int quantity)
            {
                OrderDate = orderDate;
                Code = code;
                Quantity = quantity;
            }

            public string OrderDate { get; set; }
            public string Code { get; set; }
            public int Quantity { get; set; }
        }
    }
}
