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

        [TestMethod]
        public void Add_OverNumber_ReturnsMaxNumber()
        {
            var calc = new Calc();

            var actual = calc.Add(999, 1);

            Assert.AreEqual(999, actual);
        }

        [DataTestMethod]
        [DataRow(3, 1, 2)]
        [DataRow(5, -1, 6)]
        [DataRow(999, 999, 1)]
        public void Add_ParamNumbers_ReturnsTotalNumber(
            int expected, int a, int b)
        {
            var calc = new Calc();

            var actual = calc.Add(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}