using System;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class ClubsManagerTest
    {
        [TestMethod]
        public void AddClub_AddingValidClub_AddsClubToArray()
        {
            // Arrange
            var clubManager = new ClubsManager();
            var club = new Club();

            // Act
            clubManager.AddClub(club);

            // Assert
            Assert.AreEqual(club.RegistrationNumber, clubManager.GetClub(club.RegistrationNumber).RegistrationNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddClub_ReachedMaximumNumberOfClubs_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var club = new Club();
            var maximumNumberOfClubs = 100;
            for (var i = 0; i < maximumNumberOfClubs; i++)
            {
                clubsManager.AddClub(new Club());
            }

            // Act
            clubsManager.AddClub(club);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddClub_AddingExistingClub_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var club = new Club();
            clubsManager.AddClub(club);

            // Act
            clubsManager.AddClub(club);
        }

        [TestMethod]
        public void AddClub_AddingValidClub_IncrementsClubCounter()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var club = new Club();
            var expectedCounter = clubsManager.NumberOfClubs + 1;

            // Act
            clubsManager.AddClub(club);

            // Assert
            Assert.AreEqual(expectedCounter, clubsManager.NumberOfClubs);
        }

        [TestMethod]
        public void GetClub_ByExistingId_ReturnsCorrectClub()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var club = new Club();
            clubsManager.AddClub(club);

            // Act
            var actualClub = clubsManager.GetClub(club.RegistrationNumber);

            // Assert
            Assert.AreEqual(club.RegistrationNumber, actualClub.RegistrationNumber);
        }

        [TestMethod]
        public void GetClub_ByNotExistingId_ReturnsNull()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var notExistingId = -1;

            // Act
            var result = clubsManager.GetClub(notExistingId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseClubs_Parsing3ValidRecords_Adds3Clubs()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var record1 = "3005,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            var record2 = "3006,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            var record3 = "3007,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            string[] records = { record1, record2, record3 };
            var privateObject = new PrivateObject(clubsManager);
            var expectedNumberOfClubs = 3;

            // Act
            privateObject.Invoke("ParseClubs", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfClubs, clubsManager.NumberOfClubs);
        }

        [TestMethod]
        public void ParseClubs_ParsingClubWithInvalidPhoneNumber_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var record1 = "3005,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            var record2 = "3006,Club,35 River St,Toronto,ON,M2M 5M5,invalidPhone";
            string[] records = { record1, record2 };
            var privateObject = new PrivateObject(clubsManager);

            // Act
            try
            {
                privateObject.Invoke("ParseClubs", records, ",");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(Exception));

                return;
            }

            // Assert
            Assert.Fail("Exception was not thrown");
        }

        [TestMethod]
        public void ParseClubs_ParsingClubWithInvalidRegNumber_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var record1 = "3005,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            var record2 = "invalidNum,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            string[] records = { record1, record2 };
            var privateObject = new PrivateObject(clubsManager);

            // Act
            try
            {
                privateObject.Invoke("ParseClubs", records, ",");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));

                return;
            }

            Assert.Fail("Exception was not thrown");
        }

        [TestMethod]
        public void ParseClubs_WithDuplicateRegNumber_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var record1 = "3005,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            var record2 = "3005,Club,35 River St,Toronto,ON,M2M 5M5,4165555555";
            string[] records = { record1, record2 };
            var privateObject = new PrivateObject(clubsManager);
        
            // Act
            try
            {
                privateObject.Invoke("ParseClubs", records, ",");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));

                return;
            }

            Assert.Fail("Exception was not thrown");
        }
    }
}