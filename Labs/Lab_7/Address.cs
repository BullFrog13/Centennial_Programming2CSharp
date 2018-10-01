namespace Lab_7
{
    public struct Address
    {
        private string street;
        private string city;
        private string province;
        private string postalCode;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Province
        {
            get { return province; }
            set { province = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
    }
}
