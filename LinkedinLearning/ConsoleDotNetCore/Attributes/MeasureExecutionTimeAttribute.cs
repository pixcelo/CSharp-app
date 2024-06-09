using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Attributes
{
    /// <summary>
    /// メソッドの実行時間を計測するためのカスタム属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]

    public class MeasureExecutionTimeAttribute : Attribute
    {
        public void OnMethodExecuting()
        {
            Stopwatch = Stopwatch.StartNew();
        }

        public void OnMethodExecuted()
        {
            Stopwatch?.Stop();
            Console.WriteLine($"Method execution time: {Stopwatch?.ElapsedMilliseconds} ms");
        }

        private Stopwatch? Stopwatch { get; set; }
    }
}
