using System;
using System.IO;
using System.Text;
using BusinessLogic.Models;

namespace BusinessLogic.Managers
{
    public class ClubsManager
    {
        private static readonly int MAXIMUM_NO_OF_CLUBS = 100;

        private Club[] clubs;
        private int numberOfClubs;

        public Club[] Clubs
        {
            get { return clubs; }
            private set { clubs = value; }
        }

        public int NumberOfClubs
        {
            get { return numberOfClubs; }
            private set { numberOfClubs = value; }
        }

        public ClubsManager()
        {
            Clubs = new Club[MAXIMUM_NO_OF_CLUBS];
        }

        public void AddClub(Club club)
        {
            if (NumberOfClubs >= 100)
            {
                throw new Exception("Reached maximum number of clubs");
            }

            if (ClubExists(club.RegistrationNumber))
            {
                throw new Exception("Invalid club record. Club with the registration number already exists: " +
                                    GetClubInfoInline(club));
            }

            Clubs[NumberOfClubs++] = club;
        }

        public Club GetClub(int regNumber)
        {
            foreach (var club in clubs)
            {
                if (club?.RegistrationNumber == regNumber)
                {
                    return club;
                }
            }

            return null;
        }

        public void LoadClubs(string fileName, string delimiter) // ?delimiter is char not string!
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) // ? can i use using keyword?
            using(var reader = new StreamReader(stream))
            {
                string record = reader.ReadLine();

                while (record != null)
                {
                    string[] fields = record.Split(delimiter[0]);

                    bool isValidRegNumber = int.TryParse(fields[0], out var regNumber);
                    bool isValidPhoneNumber = long.TryParse(fields[6], out var phoneNumber);
                    var clubAddress = new Address(fields[2], fields[3], fields[4], fields[5]);
                    var club = new Club(fields[1], clubAddress, phoneNumber, regNumber);

                    if (!isValidRegNumber)
                    {
                        throw new Exception("Invalid club record. Club number is not valid: " +
                                            GetClubInfoInline(club));
                    }

                    if (!isValidPhoneNumber)
                    {
                        throw new Exception("Invalid club record. Club with the registration number already exists: " +
                                            GetClubInfoInline(club));
                    }

                    AddClub(club);

                    record = reader.ReadLine();
                }
            }
        }

        public void SaveClubs(string fileName, string delimiter)
        {
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Write)) // ? can i use using keyword?
            using (var writer = new StreamWriter(stream))
            {
                foreach (var club in Clubs)
                {
                    if (club != null)
                    {
                        writer.WriteLine(GetClubInfoInline(club));
                    }
                }
            }
        }

        private bool ClubExists(int regNumber)
        {
            foreach (var club in Clubs)
            {
                if (club?.RegistrationNumber == regNumber)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetClubInfoInline(Club club)
        {
            var stringBuilder = new StringBuilder(200);
            stringBuilder.Append(club.RegistrationNumber).Append(",").
                Append(club.Name).Append(",").
                Append(club.Address.Street ).Append(",").
                Append(club.Address.City).Append(",").
                Append(club.Address.Province).Append(",").
                Append(club.Address.ZipCode).Append(",").
                Append(club.PhoneNumber);

            return stringBuilder.ToString();
        }
    }
}