using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis
{
    public class ParallelTips
    {
        public void Run()
        {
            Console.WriteLine("start");

            // 並列処理で複数の処理を行う
            Parallel.Invoke(
                () => Console.WriteLine(1),
                () => Console.WriteLine(2),
                () => Console.WriteLine(3),
                () => Console.WriteLine(4),
                () => Console.WriteLine(5)
                );

            Console.WriteLine("end");

            // Parallel.For
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine(i);
            });

            Console.WriteLine("===");

            // Parallel.ForEach
            int[] intValue = Enumerable.Range(0, 10).ToArray();

            Parallel.ForEach(intValue, x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
