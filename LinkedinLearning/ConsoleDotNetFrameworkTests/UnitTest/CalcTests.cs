using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDotNetFramework.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.UnitTest.Tests
{
    [TestClass()]
    public class CalcTests
    {
        [TestMethod()]
        public void Add_Number_ReturnsTotalNumber()
        {
            var calc = new Calc();

            var actual = calc.Add(2, 3);

            Assert.AreEqual(5, actual);
        }
    }
}