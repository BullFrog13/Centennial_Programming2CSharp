using System;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ClubTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSwimmer_AddsExistingSwimmer_ThrowsException()
        {
            // Arrange
            var club = new Club();
            var swimmer = new Registrant();
            club.AddSwimmer(swimmer);

            // Act
            club.AddSwimmer(swimmer);
        }

        [TestMethod]
        public void AddSwimmer_AddsSwimmer_IncrementsSwimmerCounter()
        {
            // Arrange
            var club = new Club();
            var swimmer = new Registrant();
            var expectedCounter = 1;

            // Act
            club.AddSwimmer(swimmer);

            // Assert
            Assert.AreEqual(expectedCounter, club.RegistrantCounter);
        }
    }
}