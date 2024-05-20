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
        public void TestSettingObjectProperty()
        {
            // Arrange
            var currentActor = new Actor();
            currentActor.ActorName = "Johnny Boy";
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

        [TestMethod]
        public void TestAutoPropActorDescription()
        {
            // Arange
            var currentActor = new Actor { ActorName = "Sandy Love" };
            var expected = "Regular actor";

            // Act
            string result = currentActor.ActorDescription;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAutoPropInitActorAge()
        {
            // Arange
            var currentActor = new Actor { ActorName = "Sandy Love", ActorAge = 46 };
            var expected = 46;

            // Act
            int result = currentActor.ActorAge;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetAgency()
        {
            // Arange
            var currentActor = new Actor();
            var expected = "Prestige Talent";

            // Act
            string result = currentActor.GetAgency();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
