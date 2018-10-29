using System;
using System.IO;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic.Managers
{
    public class SwimmersManager
    {
        private static readonly int MAXIMUM_NO_OF_SWIMMERS = 100;
        private int numberOfSwimmers;
        private Registrant[] swimmers;
        private readonly ClubsManager clubsManager;

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
        }

        public void AddSwimmer(Registrant registrant)
        {
            if (NumberOfSwimmers >= 100)
            {
                throw new Exception("Reached maximum number of swimmers");
            }

            if (SwimmerExists(registrant.RegistrationNumber))
            {
                throw new Exception("Invalid swimmer record. Swimmer with the registration number already exists" +
                                    GetSwimmerInfoInline(registrant));
            }

            Swimmers[NumberOfSwimmers++] = registrant;
        }

        public Registrant GetSwimmer(uint regNumber)
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
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) // ? can i use using keyword?
            using (var reader = new StreamReader(stream))
            {
                string record = reader.ReadLine();

                while (record != null)
                {
                    string[] fields = record.Split(delimiter[0]);

                    bool isValidRegNumber = int.TryParse(fields[0], out var regNumber);
                    bool isValidName = string.IsNullOrWhiteSpace(fields[1]);
                    bool isValidDob = DateTime.TryParse(fields[2], out var dob);
                    bool isValidPhoneNumber = long.TryParse(fields[7], out var phoneNumber);
                    var swimmerAddress = new Address(fields[3], fields[4], fields[5], fields[6]);
                    var swimmer = new Registrant(fields[1], dob, swimmerAddress, phoneNumber, regNumber);

                    if (!isValidRegNumber)
                    {
                        throw new Exception("Invalid swimmer record. Invalid registration number: " +
                                            GetSwimmerInfoInline(swimmer));
                    }

                    if (!isValidPhoneNumber)
                    {
                        throw new Exception("Invalid swimmer record. Phone number wrong format: " +
                                            GetSwimmerInfoInline(swimmer));
                    }

                    if (!isValidName)
                    {
                        throw new Exception("Invalid swimmer record. Invalid swimmer name: " +
                                            GetSwimmerInfoInline(swimmer));
                    }

                    if (!isValidDob)
                    {
                        throw new Exception("Invalid swimmer record. Birth date is invalid: " +
                                            GetSwimmerInfoInline(swimmer));
                    }

                    AddSwimmer(swimmer);

                    if (int.TryParse(fields[7], out var clubNumber))
                    {
                        swimmer.AddClub(clubsManager.GetClub(clubNumber));
                    }

                    record = reader.ReadLine();
                }
            }
        }

        public void SaveSwimmers(string fileName, string delimiter)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Write)) // ? can i use using keyword?
            using (var writer = new StreamWriter(stream))
            {
                foreach (var swimmer in Swimmers)
                {
                    if (swimmer != null)
                    {
                        writer.WriteLine(GetSwimmerInfoInline(swimmer));
                    }
                }
            }
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
    }
}