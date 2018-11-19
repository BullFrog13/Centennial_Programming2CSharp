using System;
using BusinessLogic.Managers;
using BusinessLogic.Models;
using BusinessLogic.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTest
{
    [TestClass]
    public class SwimmersManagerTest
    {
        [TestMethod]
        public void AddSwimmer_AddingValidSwimmer_IncreasesSwimmerCounter()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var swimmerManager = new SwimmersManager(clubsManager);
            var registrant = new Registrant();
            var expectedCounter = swimmerManager.NumberOfSwimmers + 1;

            // Act
            swimmerManager.AddSwimmer(registrant);

            // Assert
            Assert.AreEqual(expectedCounter, swimmerManager.NumberOfSwimmers);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSwimmer_ReachedMaximumNumberOfSwimmers_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var swimmersManager = new SwimmersManager(clubsManager);
            var registrant = new Registrant();
            var maximumNumberOfSwimmers = 100;
            for (var i = 0; i < maximumNumberOfSwimmers; i++)
            {
                swimmersManager.AddSwimmer(new Registrant());
            }

            // Act
            swimmersManager.AddSwimmer(registrant);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSwimmer_AddingExistingSwimmer_ThrowsException()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var swimmersManager = new SwimmersManager(clubsManager);
            var registrant = new Registrant();
            swimmersManager.AddSwimmer(registrant);

            // Act
            swimmersManager.AddSwimmer(registrant);
        }

        [TestMethod]
        public void GetSwimmer_GettingExistingSwimmer_ReturnsCorrectSwimmer()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var swimmersManager = new SwimmersManager(clubsManager);
            var registrant = new Registrant();
            swimmersManager.AddSwimmer(registrant);

            // Act
            var resultSwimmer = swimmersManager.GetSwimmer(registrant.RegistrationNumber);

            // Assert
            Assert.AreEqual(resultSwimmer.RegistrationNumber, resultSwimmer.RegistrationNumber);
        }

        [TestMethod]
        public void GetSwimmer_GettingByNotExistingRegId_ReturnsNull()
        {
            // Arrange
            var clubsManager = new ClubsManager();
            var swimmersManager = new SwimmersManager(clubsManager);
            var notExistingId = -1;

            // Act
            var result = swimmersManager.GetSwimmer(notExistingId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseSwimmers_Parsing3Records_Adds3SwimmersToManager()
        {
            // Arrange
            var record1 = "3004,Swimmer 1,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            var record2 = "3005,Swimmer 2,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            var record3 = "3006,Swimmer 3,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            string[] records = { record1, record2, record3 };
            var clubsManager = new ClubsManager();
            var swimmersManager = new SwimmersManager(clubsManager);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfClubs = 3;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfClubs, swimmersManager.NumberOfSwimmers);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithInvalidRegNumber_AddsExceptionToExceptionQueue()
        {
            // Arrange
            var record1 = "Invalid Reg Number,Swimmer 1,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            string[] records = { record1 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithInvalidPhoneNumber_AddsExceptionToExceptionQueue()
        {
            // Arrange
            var record1 = "1001,Swimmer 1,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,Invalid Phone,";
            string[] records = { record1 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithInvalidName_AddsExceptionToExceptionQueue()
        {
            // Arrange
            var record1 = "1001,,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            string[] records = { record1 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithInvalidDob_AddsExceptionToExceptionQueue()
        {
            // Arrange
            var record1 = "1001,Swimmer Name,1974-04-,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            string[] records = { record1 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithDuplicateId_AddsExceptionToExceptionQueue()
        {
            // Arrange
            var record1 = "1001,Swimmer Name,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            var record2 = "1001,Swimmer Name,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,";
            string[] records = { record1, record2 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }

        [TestMethod]
        public void ParseSwimmers_ParsingSwimmerWithDuplicateId_AddsExceptionToExceptionQueue1()
        {
            // Arrange
            var record1 = "1001,Swimmer Name,1974-04-04 12:00:00 AM,4 Queen St,Toronto,ON,M4M 4M4,4163333330,1";
            string[] records = { record1 };
            var clubsManager = new ClubsManager();
            var exceptionQueue = new ExceptionQueue();
            var swimmersManager = new SwimmersManager(clubsManager, exceptionQueue);
            var privateObject = new PrivateObject(swimmersManager);
            var expectedNumberOfExceptions = 1;

            // Act
            privateObject.Invoke("ParseSwimmers", records, ",");

            // Assert
            Assert.AreEqual(expectedNumberOfExceptions, exceptionQueue.ExceptionCount);
        }
    }
}