using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Attributes
{
    ///// <summary>
    ///// クラスのバージョン情報を示す属性
    ///// <see href="https://learn.microsoft.com/ja-jp/dotnet/api/system.attribute?view=net-8.0">属性<see>
    ///// </summary>
    /// <inheritdoc/>を使用すると、基底クラスの説明が継承される


    /// <inheritdoc/>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Struct, Inherited = false)]
    public class VersionAttribute : Attribute
    {
        // 属性として管理する情報
        public string  Number { get; }
        public bool Beta { get; set; } = false;

        // Numberプロパティを初期化
        public VersionAttribute(string number)
        {
            this.Number = number;
        }
    }
}
