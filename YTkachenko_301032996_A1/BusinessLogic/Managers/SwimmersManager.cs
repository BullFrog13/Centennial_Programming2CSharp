using System;
using System.IO;
using System.Text;
using BusinessLogic.Models;
using BusinessLogic.Utils;

namespace BusinessLogic.Managers
{
    public class SwimmersManager
    {
        private static readonly int MAXIMUM_NO_OF_SWIMMERS = 100;
        private int numberOfSwimmers;
        private Registrant[] swimmers;
        private readonly ClubsManager clubsManager;
        private readonly ExceptionQueue exceptionQueue;

        public int NumberOfSwimmers
        {
            get { return numberOfSwimmers; }
            private set { numberOfSwimmers = value; }
        }

        public Registrant[] Swimmers
        {
            get { return swimmers; }
            private set { swimmers = value; }
        }

        public SwimmersManager(ClubsManager clubsManager)
        {
            Swimmers = new Registrant[MAXIMUM_NO_OF_SWIMMERS];
            this.clubsManager = clubsManager;
            exceptionQueue = new ExceptionQueue();
        }

        public SwimmersManager(ClubsManager clubsManager, ExceptionQueue exceptionQueue)
        {
            Swimmers = new Registrant[MAXIMUM_NO_OF_SWIMMERS];
            this.clubsManager = clubsManager;
            this.exceptionQueue = exceptionQueue;
        }

        public void AddSwimmer(Registrant registrant)
        {
            if (NumberOfSwimmers >= MAXIMUM_NO_OF_SWIMMERS)
            {
                throw new Exception("Reached maximum number of swimmers");
            }

            if (SwimmerExists(registrant.RegistrationNumber))
            {
                throw new Exception("Invalid swimmer record. Swimmer with the registration number already exists: " +
                                    GetSwimmerInfoInline(registrant));
            }

            Swimmers[NumberOfSwimmers++] = registrant;
        }

        public Registrant GetSwimmer(int regNumber)
        {
            foreach (var swimmer in Swimmers)
            {
                if (swimmer?.RegistrationNumber == regNumber)
                {
                    return swimmer;
                }
            }

            return null;
        }

        public void LoadSwimmers(string fileName, string delimiter)
        {
            string[] records = Helpers.ReadRecordsFromFile(fileName);
            ParseSwimmers(records, delimiter);
        }

        public void SaveSwimmers(string fileName, string delimiter)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            var writer = new StreamWriter(stream);

            foreach (var swimmer in Swimmers)
            {
                if (swimmer != null)
                {
                    writer.WriteLine(GetSwimmerInfoInline(swimmer));
                }
            }

            writer.Close();
            stream.Close();
        }

        private void ParseSwimmers(string[] records, string delimiter)
        {
            foreach (var record in records)
            {
                if (record == null)
                {
                    continue;
                }

                string[] fields = record.Split(delimiter[0]);

                bool isValidRegNumber = int.TryParse(fields[0], out var regNumber);
                bool isValidName = !string.IsNullOrWhiteSpace(fields[1]);
                bool isValidDob = DateTime.TryParse(fields[2], out var dob);
                bool isValidPhoneNumber = long.TryParse(fields[7], out var phoneNumber);
                var swimmerAddress = new Address(fields[3], fields[4], fields[5], fields[6]);

                if (!isValidRegNumber || !isValidName || !isValidDob || !isValidPhoneNumber)
                {
                    if (!isValidRegNumber)
                    {
                        exceptionQueue.Add(new Exception("Invalid swimmer record. Invalid registration number: " +
                                                         GetSwimmerInfoInline(fields)));
                    }

                    if (!isValidPhoneNumber)
                    {
                        exceptionQueue.Add(new Exception("Invalid swimmer record. Phone number wrong format: " +
                                                         GetSwimmerInfoInline(fields)));
                    }

                    if (!isValidName)
                    {
                        exceptionQueue.Add(new Exception("Invalid swimmer record. Invalid swimmer name: " +
                                                         GetSwimmerInfoInline(fields)));
                    }

                    if (!isValidDob)
                    {
                        exceptionQueue.Add(new Exception("Invalid swimmer record. Birth date is invalid: " +
                                                         GetSwimmerInfoInline(fields)));
                    }

                    continue;
                }

                var swimmer = new Registrant(fields[1], dob, swimmerAddress, phoneNumber, regNumber);

                try
                {
                    AddSwimmer(swimmer);
                }
                catch (Exception ex)
                {
                    exceptionQueue.Add(ex);

                    continue;
                }

                if (int.TryParse(fields[8], out var clubNumber))
                {
                    var club = clubsManager.GetClub(clubNumber);
                    if (club == null)
                    {
                        exceptionQueue.Add(new Exception($"Club with id {clubNumber} does not exists"));
                    }
                    else
                    {
                        swimmer.AddClub(club);
                    }
                }
            }

            exceptionQueue.PrintQueue();
        }

        private bool SwimmerExists(int registrantNumber)
        {
            foreach (var registrant in Swimmers)
            {
                if (registrant?.RegistrationNumber == registrantNumber)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetSwimmerInfoInline(Registrant swimmer)
        {
            var stringBuilder = new StringBuilder(200);
            stringBuilder.Append(swimmer.RegistrationNumber).Append(",").
                Append(swimmer.Name).Append(",").
                Append(swimmer.DateOfBirth).Append(",").
                Append(swimmer.Address.Street).Append(",").
                Append(swimmer.Address.City).Append(",").
                Append(swimmer.Address.Province).Append(",").
                Append(swimmer.Address.ZipCode).Append(",").
                Append(swimmer.PhoneNumber).Append(",").
                Append(swimmer.Club?.RegistrationNumber);

            return stringBuilder.ToString();
        }

        private string GetSwimmerInfoInline(string[] fields)
        {
            var stringBuilder = new StringBuilder(200);
            stringBuilder.Append(fields[0]).Append(",").
                Append(fields[1]).Append(",").
                Append(fields[2]).Append(",").
                Append(fields[3]).Append(",").
                Append(fields[4]).Append(",").
                Append(fields[5]).Append(",").
                Append(fields[6]).Append(",").
                Append(fields[7]).Append(",").
                Append(fields[8]);

            return stringBuilder.ToString();
        }
    }
}