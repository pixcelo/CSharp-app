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
        /// <summary>
        /// 値の比較
        /// </summary>
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

        /// <summary>
        /// 複数の値を比較
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
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

        /// <summary>
        /// 参照元が同じかどうかを比較
        /// </summary>
        [TestMethod]
        public void Compare_SameClass()
        {
            var calc = new Calc();
            
            var calc2 = calc;
            
            Assert.AreSame(calc, calc2);
        }

        /// <summary>
        /// 参照元が異なるかどうかを比較
        /// </summary>
        [TestMethod]
        public void Compare_NotSameClass()
        {
            var calc = new Calc();

            var calc2 = new Calc();            

            Assert.AreNotSame(calc, calc2);
        }

        /// <summary>
        /// コレクションの要素を比較
        /// </summary>
        [TestMethod]
        public void Compare_ListValues()
        {
            var list = new List<int>() { 1, 2 };

            var list2 = new List<int>() { 1, 2 };

            CollectionAssert.AreEqual(list, list2);
        }

        /// <summary>
        /// コレクションの要素を比較（インデックスが異なる場合）
        /// </summary>
        [TestMethod]
        public void Compare_ListValues_differentIndex()
        {
            var list = new List<int>() { 1, 2 };

            var list2 = new List<int>() { 2, 1 };

            CollectionAssert.AreNotEqual(list, list2);
        }

        /// <summary>
        /// コレクションの要素を比較（インデックスが異なる場合）
        /// </summary>
        [TestMethod]
        public void Compare_ListValues_Equivalent()
        {
            var list = new List<int>() { 1, 2 };

            var list2 = new List<int>() { 2, 1 };

            // AreEquivalentは、インデックスが異なる場合でもテスト成功とする
            CollectionAssert.AreEquivalent(list, list2);
        }

        /// <summary>
        /// コレクションの要素を比較（一意かどうか）
        /// </summary>
        [TestMethod]
        public void Compare_ListValues_IsUnique()
        {
            var list = new List<int>() { 1, 2 };
            
            CollectionAssert.AllItemsAreUnique(list);
        }

        /// <summary>
        /// コレクションの要素を比較（含まれているか）
        /// </summary>
        [TestMethod]
        public void Compare_ListValues_Contains()
        {
            var list = new List<int>() { 1, 2 };

            CollectionAssert.Contains(list, 1);
        }
    }
}