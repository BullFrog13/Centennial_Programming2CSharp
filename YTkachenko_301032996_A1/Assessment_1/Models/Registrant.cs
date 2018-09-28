using System;
using System.Collections.Generic;
using System.Text;
using Assessment_1.Utils;

namespace Assessment_1.Models
{
    public class Registrant
    {
        private const uint MinimumPhoneNumber = 1000000000;
        private const ulong MaximumPhoneNumber = 9999999999;

        private static readonly List<uint> RegistrantsIds = new List<uint>();

        private uint registrationNumber;
        private string name;
        private DateTime dateOfBirth;
        private Address address;
        private ulong phoneNumber;

        public uint RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                registrationNumber = RegistrantsIds.Contains(value) ? Helpers.GenerateIdForSequence(RegistrantsIds) : value;

                RegistrantsIds.Add(registrationNumber);
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty");
                }

                name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (value > DateTime.UtcNow)
                {
                    throw new ArgumentException($"The date of birth {value:d} is incorrect");
                }

                dateOfBirth = value;
            }
        }

        public Address Address
        {
            get => address;
            set => address = value;
        }

        public ulong PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value < MinimumPhoneNumber || value > MaximumPhoneNumber)
                {
                    throw new ArgumentException($"Phone number {value} is out of range. It should be 10 digits");
                }

                phoneNumber = value;
            }
        }

        public Registrant()
        {
            RegistrationNumber = Helpers.GenerateIdForSequence(RegistrantsIds);
            Name = "Default_Name";
            DateOfBirth = new DateTime();
            Address = new Address("Default_Street", "0", "000000", "Default_City");
            PhoneNumber = 1000000000;
        }

        public Registrant(uint registrationNumber, string name, DateTime dateOfBirth, Address address, ulong phoneNumber)
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
            stringBuilder.Append(Address.ToString());

            return stringBuilder.ToString();
        }
    }
}