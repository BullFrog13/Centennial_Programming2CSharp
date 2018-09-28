using System;

namespace Assessment_1.Models
{
    public struct Address
    {
        private string number;
        private string street;
        private string zipCode;
        private string city;

        public string Street
        {
            get => street;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Street name can not be null or empty");
                }

                street = value;
            }
        }

        public string Number
        {
            get => number;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Address number cannot be null or empty");
                }

                number = value;
            }
        }

        public string ZipCode
        {
            get => zipCode;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Zip code can not be null or empty");
                }

                zipCode = value;
            }
        }

        public string City
        {
            get => city;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("City value can not be null or empty");
                }

                city = value;
            }
        }

        public Address(string street, string number, string zipCode, string city) : this()
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }

        public override string ToString()
        {
            return $"Address: {Number} {Street}, {ZipCode}, {City}";
        }
    }
}