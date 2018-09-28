using System;
using System.Text;
using Assessment_1.Utils;

namespace Assessment_1.Models
{
    public class Registrant
    {
        private const uint MINIMUM_PHONE_NUMBER = 1000000000;
        private const long MAXIMUM_PHONE_NUMBER = 9999999999;

        private static readonly int[] RegistrantsIds = new int[1000];

        private int registrationNumber;
        private string name;
        private DateTime dateOfBirth;
        private Address address;
        private long phoneNumber;

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value < 1 || Helpers.CheckIfIdExists(RegistrantsIds, value))
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
            set { name = string.IsNullOrEmpty(value) ? "Default_Name" : value; }
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
                    phoneNumber = MINIMUM_PHONE_NUMBER;
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }

        public Registrant() : this(0, "Default_Name", new DateTime(), new Address("Default_Street", "0", "000000", "Default_City"), MINIMUM_PHONE_NUMBER)
        {

        }

        public Registrant(int registrationNumber, string name, DateTime dateOfBirth, Address address, long phoneNumber)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Registration number: {RegistrationNumber}\n");
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Date of birth: {DateOfBirth:D}\n");
            stringBuilder.Append($"Phone number: {PhoneNumber}\n");
            stringBuilder.Append(Address.GetInfo());

            return stringBuilder.ToString();
        }
    }
}