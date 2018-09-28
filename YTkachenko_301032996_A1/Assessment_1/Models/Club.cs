using System;
using System.Collections.Generic;
using System.Text;
using Assessment_1.Utils;

namespace Assessment_1.Models
{
    public class Club
    {
        private const uint MinimumPhoneNumber = 1000000000;
        private const ulong MaximumPhoneNumber = 9999999999;

        private static readonly List<uint> ExistingClubNumbers = new List<uint>();

        private uint registrationNumber;
        private string name;
        private ulong phoneNumber;
        private Address address;

        public Address Address
        {
            get => address;
            set => address = value;
        }

        public uint RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                registrationNumber = ExistingClubNumbers.Contains(value) ? Helpers.GenerateIdForSequence(ExistingClubNumbers) : value;

                ExistingClubNumbers.Add(registrationNumber);
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

        public ulong PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (value < MinimumPhoneNumber || value > MaximumPhoneNumber)
                {
                    throw new ArgumentException($"Phone number {value} is out of range. It should be 10 digits.");
                }

                phoneNumber = value;
            }
        }

        public Club()
        {
            RegistrationNumber = Helpers.GenerateIdForSequence(ExistingClubNumbers);
            Name = "Default_Name";
            PhoneNumber = MinimumPhoneNumber;
            Address = new Address("Default_Street", "0", "000000", "Default_City");
        }

        public Club(uint registrationNumber, string name, ulong phoneNumber, Address address)
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Registration number: {RegistrationNumber}\n");
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Phone number: {PhoneNumber}\n");
            stringBuilder.Append(Address.ToString());

            return stringBuilder.ToString();
        }
    }
}