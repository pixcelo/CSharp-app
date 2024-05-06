using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Generic
{
    public class GenericTips
    {
        public void Run()
        {
            var geInt = new GeClass<int>();
            geInt.value = 3;

            Console.WriteLine(geInt.value);

            var geString = new GeClass<string>();
            geString.value = "aaa";

            Console.WriteLine(geString.value);
        }
    }
}
