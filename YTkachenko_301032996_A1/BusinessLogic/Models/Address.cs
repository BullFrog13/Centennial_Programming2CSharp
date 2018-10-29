namespace BusinessLogic.Models
{
    public struct Address
    {
        private string province;
        private string street;
        private string zipCode;
        private string city;

        public string Street
        {
            get { return street; }
            set { street = string.IsNullOrEmpty(value) ? "" : value; }
        }

        public string Province
        {
            get { return province; }
            set { province = string.IsNullOrEmpty(value) ? "" : value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = string.IsNullOrEmpty(value) ? "" : value; }
        }

        public string City
        {
            get { return city; }
            set { city = string.IsNullOrEmpty(value) ? "" : value; }
        }

        public Address(string street, string city, string province, string zipCode) : this()
        {
            Street = street;
            Province = province;
            ZipCode = zipCode;
            City = city;
        }

        public string GetInfo()
        {
            return $"Address:\n\t{Street}\n\t{City}\n\t{Province}\n\t{ZipCode}\n";
        }
    }
}