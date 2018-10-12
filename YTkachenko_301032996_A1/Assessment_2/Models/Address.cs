namespace Assessment_2.Models
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
            set { street = string.IsNullOrEmpty(value) ? "Default_Street" : value; }
        }

        public string Province
        {
            get { return province; }
            set { province = string.IsNullOrEmpty(value) ? "Default_Province" : value; }
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

        public Address(string street, string city, string province, string zipCode) : this()
        {
            Street = street;
            Province = province;
            ZipCode = zipCode;
            City = city;
        }

        public string GetInfo()
        {
            return $"Address: {Province} {Street}, {ZipCode}, {City}";
        }
    }
}