using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点以下2桁で丸めて表示できる()
        {
            var temperature = new Temperature(12.3f);

            Assert.AreEqual("12.30 ℃", temperature.DisplayValue);
        }

        [TestMethod]
        public void 値オブジェクト同士が等しい()
        {
            var temperature1 = new Temperature(12.3f);
            var temperature2 = new Temperature(12.3f);

            Assert.IsTrue(temperature1.Equals(temperature2));
        }

        [TestMethod]
        public void 値オブジェクト同士がイコールで等しい()
        {
            var temperature1 = new Temperature(12.3f);
            var temperature2 = new Temperature(12.3f);

            Assert.AreEqual(true, temperature1 == temperature2);
        }
    }
}
