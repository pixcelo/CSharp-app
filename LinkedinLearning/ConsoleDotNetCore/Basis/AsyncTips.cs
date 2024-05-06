using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class AsyncTips
    {
        public void Run()
        {
            SomeMethod();
        }

        private async Task SomeMethod()
        {
            Console.WriteLine("start");

            // 非同期処理を挟む
            await SomeAsync();

            Console.WriteLine("end");
        }

        Task SomeAsync()
        {
            Console.WriteLine("test");
        }
    }
}
