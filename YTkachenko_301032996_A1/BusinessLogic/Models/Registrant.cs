using System;
using System.Globalization;
using System.Text;
using BusinessLogic.Utils;

namespace BusinessLogic.Models
{
    public class Registrant
    {
        #region Statics

        private static readonly uint MINIMUM_PHONE_NUMBER = 1000000000;
        private static readonly long MAXIMUM_PHONE_NUMBER = 9999999999;
        private static readonly byte DEFAULT_PHONE_NUMBER = 0;

        private static readonly int[] RegistrantsIds = new int[50];

        #endregion

        #region Fields

        private int registrationNumber;
        private string name;
        private DateTime dateOfBirth;
        private Address address;
        private long phoneNumber;
        private Club club;

        #endregion

        #region Properties

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value < 0)
                {
                    value = Helpers.GenerateUniqueId(RegistrantsIds);
                }

                registrationNumber = value;
                Helpers.InsertValueInArray(RegistrantsIds, value);
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value > DateTime.UtcNow ? new DateTime() : value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public long PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value < MINIMUM_PHONE_NUMBER || value > MAXIMUM_PHONE_NUMBER)
                {
                    phoneNumber = DEFAULT_PHONE_NUMBER;
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }

        public Club Club
        {
            get { return club; }
            set { value.AddSwimmer(this); }
        }

        #endregion

        public Registrant() : this(
            string.Empty,
            new DateTime(),
            new Address("", "", "", ""),
            0)
        {
        }

        public Registrant(string name, DateTime dateOfBirth, Address address, long phoneNumber, int registrationNumber = -1)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            RegistrationNumber = registrationNumber == -1 ? Helpers.GenerateUniqueId(RegistrantsIds) : registrationNumber;
        }

        public void AddClub(Club club, bool fromClubMethod = false)
        {
            if (fromClubMethod)
            {
                this.club = club;
            }
            else
            {
                Club = club;
            }
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append(Address.GetInfo());
            stringBuilder.Append($"Phone: {PhoneNumber}\n");
            stringBuilder.Append($"DOB: {DateOfBirth.ToString("yyyy-MM-dd hh:mm:ss tt", CultureInfo.CreateSpecificCulture("en"))}\n");
            stringBuilder.Append($"Reg number: {RegistrationNumber}\n");
            stringBuilder.Append(Club == null ? "Club: not assigned" : $"Club: {Club.Name}\n");

            return stringBuilder.ToString();
        }
    }
}