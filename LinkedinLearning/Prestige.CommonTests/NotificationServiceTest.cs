using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Common;
using System;

namespace Prestige.CommonTests
{
    [TestClass]
    public class NotificationServiceTest
    {
        [TestMethod]
        public void TestNotifyTalent()
        {
            // Arrange            
            var expected = "Notifying talent: rey";

            // Act
            var actual = NotificationService.NotifyTalent("rey");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
