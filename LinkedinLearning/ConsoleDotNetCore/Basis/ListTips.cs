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
            UseImmutableList();
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
    }
}
