using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class ListTips
    {
        public void Run()
        {
            //UseMutableList();

            // 変更できないリストの使い方
            //UseImmutableList();

            // 配列から取り出す
            int[] intArray = { 1, 2, 3, 4, 5, 6 };
            //var result = GetEventNumber(intArray);
            var result = GetEventNumber2(intArray).ToList();
        }

        private void UseMutableList()
        {
            var list = new List<string>() { "abc", "def" };
            list.Add("ghi");

            foreach (var item in list)
            { 
                Console.WriteLine(item);
            }
        }

        private void UseImmutableList()
        {
            var list = ImmutableList.Create<string>("abc", "def");
            list = list.Add("ghi"); // 変更不可のリストにAddする場合、新しいインスタンスが作成される

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 配列から特定の要素を取り出す
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private List<int> GetEventNumber(int[] array)
        {
            var result = new List<int>();

            foreach (var i in array)
            {
                if (i %  2 == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// GetEventNumber の yield を利用したバージョン
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private IEnumerable<int> GetEventNumber2(int[] array)
        {          
            foreach (var i in array)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }
}
