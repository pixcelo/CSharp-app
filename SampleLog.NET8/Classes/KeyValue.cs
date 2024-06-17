using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLog.NET8.Classes
{
    /// <summary>
    /// ジェネリッククラス
    /// </summary>
    /// <see href="https://learn.microsoft.com/ja-jp/dotnet/api/system.collections.generic?view=net-8.0"/>
    /// <typeparam name="T"></typeparam>
    public class KeyValue<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
