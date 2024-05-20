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

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange
            var currentActor = new Actor("Johnny Boy");
            var expected = "Johnny Boy";

            // Act
            string result = currentActor.ActorName;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBookActor()
        {
            // Arange
            string details = "Booking can change if actor starts trouble.";
            var currentActor = new Actor("Johnny Boy");
            var expected = "Actor Johnny Boy is booked. " + details;

            // Act
            string result = currentActor.BookActor();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestBookActorOnSpecificDate()
        {
            // Arange
            string details = "Booking can change if actor starts trouble.";
            var currentActor = new Actor("Johnny Boy");
            var theDate = DateTime.Today.ToShortTimeString();
            var expected = "Actor Johnny Boy is booked on " + theDate + ". " + details;

            // Act
            string result = currentActor.BookActor(theDate);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
