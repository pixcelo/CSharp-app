using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Biz;
using System;

namespace Prestige.BizTests
{
    [TestClass]
    public class ActorTest
    {
        [TestMethod]
        public void GetOccupation()
        {
            // Arrange
            var currentActor = new Actor();
            var expected = "Actor";

            // Act
            string result = currentActor.GetOccupation();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
