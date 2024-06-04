using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDotNetCore.Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDotNetCore.Basis;

namespace ConsoleDotNetCore.Delegate.Tests
{
    [TestClass]
    public class DelegeteTipsTests
    {
        [TestMethod]
        public void DeletegeFuncTest()
        {
            var delegeteTips = new DelegeteTips();
            var expected = "DeletegeFunc";

            Func<string> actual = delegeteTips.DeletegeFunc;

            Assert.AreEqual(expected, actual());
        }
    }
}