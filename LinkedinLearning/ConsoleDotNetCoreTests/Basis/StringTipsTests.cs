using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDotNetCore.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetCore.Basis.Tests
{
    [TestClass]
    public class StringTipsTests
    {
        [TestMethod]
        public void TestNormalizeString()
        {
            var expected = "hello there buddy";

            var actual = StringTips.NormalizeString(" Hello There, BUDDY  ");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsUppercaseReturnTrue()
        {
            var actual = StringTips.IsUppercase("HELLO");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestIsUppercaseReturnFalse()
        {
            var actual = StringTips.IsUppercase("Hello");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestIsLowercaseReturnTrue()
        {
            var actual = StringTips.IsLowercase("hello");

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestIsLowercaseReturnFalse()
        {
            var actual = StringTips.IsLowercase("Hello");

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestIsPasswordComplexReturnTrue()
        {
            var actual = StringTips.IsPasswordComplex("Hell0");

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("Hello")]
        [DataRow("HellO")]
        [DataRow("HeLlo")]
        [DataRow("hello")]
        [DataRow(" ")]
        public void TestIsPasswordComplexReturnFalse(string input)
        {
            var actual = StringTips.IsPasswordComplex(input);

            Assert.IsFalse(actual);
        }

        [DataTestMethod]
        [DataRow("HeLLo", 'L')]        
        [DataRow("HeLLo", 'H')]        
        public void TestIsAtEvenIndexReturnTrue(string input, char item)
        {
            var actual = StringTips.IsAtEvenIndex(input, item);

            Assert.IsTrue(actual);
        }

        [DataTestMethod]        
        [DataRow("HeLLo", 'T')]        
        [DataRow("", 'H')]
        [DataRow(null, 'H')]
        public void TestIsAtEvenIndexReturnFalse(string input, char item)
        {
            var actual = StringTips.IsAtEvenIndex(input, item);

            Assert.IsFalse(actual);
        }
    }
}