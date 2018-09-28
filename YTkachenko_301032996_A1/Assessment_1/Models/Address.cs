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
            get { return street; }
            set { street = string.IsNullOrEmpty(value) ? "Default_Street" : value; }
        }

        public string Number
        {
            get { return number; }
            set { number = string.IsNullOrEmpty(value) ? "Default_Number" : value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = string.IsNullOrEmpty(value) ? "Default_ZipCode" : value; }
        }

        public string City
        {
            get { return city; }
            set { city = string.IsNullOrEmpty(value) ? "Default_City" : value; }
        }

        public Address(string street, string number, string zipCode, string city) : this()
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }

        public string GetInfo()
        {
            return $"Address: {Number} {Street}, {ZipCode}, {City}";
        }
    }
}