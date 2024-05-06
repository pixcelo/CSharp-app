using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class TaskTips
    {
        //public void Run()
        //{
        //    // 並列化された処理
        //    Task.Run(() =>
        //    {
        //        Thread.Sleep(5000);
        //        Console.WriteLine("非同期1");
        //    });

        //    Task.Run(() =>
        //    {
        //        Thread.Sleep(2000);
        //        Console.WriteLine("非同期2");
        //    });

        //    Console.WriteLine("同期");

        //    Thread.Sleep(10000);

        //    Console.WriteLine("終了");
        //}

        /// <summary>
        /// 非同期の処理を待ってから、以降の処理を受け取る
        /// </summary>
        public void Run()
        {            
            Task task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("非同期1");
            });

            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("非同期2");
            });

            task.Wait();
            task2.Wait();

            Console.WriteLine("同期");

            Thread.Sleep(10000);

            Console.WriteLine("終了");
        }
    }
}
