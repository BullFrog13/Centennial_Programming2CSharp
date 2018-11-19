using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void EnterSwimmersTime_AddsSwimmerTimeForExistingSwimmer_AddsSwimmerTimeToTheSpecifiedSwim()
        {
            // Arrange
            var @event = new Event();
            @event.AddSwimmer(new Registrant());
            var testedRegistrant = new Registrant();
            @event.AddSwimmer(testedRegistrant);
            var expectedSwimTime = "00:30.13";

            // Act
            @event.EnterSwimmersTime(testedRegistrant, expectedSwimTime);

            // Assert
            Assert.AreEqual(@event.GetSwim(testedRegistrant.RegistrationNumber).FinalSwimTime, expectedSwimTime);
        }

        [TestMethod]
        public void GetSwim_GettingByNotExistingRegistrantId_ReturnsNull()
        {
            // Arrange
            var @event = new Event();
            var notExistingId = -1;

            // Act
            var result = @event.GetSwim(notExistingId);

            // Assert
            Assert.IsNull(result);
        }
    }
}