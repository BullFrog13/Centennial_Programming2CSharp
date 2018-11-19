using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class SwimMeetTest
    {
        [TestMethod]
        public void AddEvent_AddsValidEvent_IncrementsEventCounter()
        {
            // Arrange
            var swimMeet = new SwimMeet();
            var @event = new Event();
            var expectedEventCounter = swimMeet.EventCounter + 1;

            // Act
            swimMeet.AddEvent(@event);

            // Assert
            Assert.AreEqual(expectedEventCounter, swimMeet.EventCounter);
        }

        [TestMethod]
        public void Seed_Seeds7SwimsInOneEventWith8Lanes_SeedsTheLastSwimmerCorrectly()
        {
            // Arrange
            var swimMeet = new SwimMeet();
            var event1 = new Event();
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            event1.AddSwimmer(new Registrant());
            var registrant9 = new Registrant();
            event1.AddSwimmer(registrant9);
            swimMeet.AddEvent(event1);

            var expectedRegistrant9Heat = 2;
            var expectedRegistrant9Lane = 1;

            // Act
            swimMeet.Seed();

            // Assert
            var seededSwim = event1.GetSwim(registrant9.RegistrationNumber);
            Assert.AreEqual(expectedRegistrant9Heat, seededSwim.Heat);
            Assert.AreEqual(expectedRegistrant9Lane, seededSwim.Lane);
        }
    }
}