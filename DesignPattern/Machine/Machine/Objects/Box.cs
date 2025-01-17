using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine
{
    internal class Box
    {
        private Random _random = new Random();
        public int GetInternalTemperature()
        {
            return _random.Next(10, 80);
        }

        public int GetExternalTemperature()
        {
            return _random.Next(10, 80);
        }
    }
}
