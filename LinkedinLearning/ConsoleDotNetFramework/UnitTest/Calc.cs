using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.UnitTest
{
    /// <summary>
    /// ユニットテスト対象クラス
    /// </summary>
    public class Calc
    {
        public int Add(int a, int b)
        {
            const int max_result = 999;

            if ((a + b) > max_result)
            {
                return max_result;
            }

            return a + b;
        }
    }
}
