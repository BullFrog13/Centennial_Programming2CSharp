using System.Text;
using Assessment_1.Utils;

namespace Assessment_1.Models
{
    public class Club
    {
        private const int MINIMUM_PHONE_NUMBER = 1000000000;
        private const long MAXIMUM_PHONE_NUMBER = 9999999999;

        private static readonly int[] ClubIds = new int[1000];

        private int registrationNumber;
        private string name;
        private long phoneNumber;
        private Address address;

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value < 1 || Helpers.CheckIfIdExists(ClubIds, value))
                {
                    value = Helpers.GenerateUniqueId(ClubIds);
                }

                registrationNumber = value;
                Helpers.InsertValueInArray(ClubIds, value);
            }
        }

        public string Name
        {
            get { return name; }
            set { name = string.IsNullOrEmpty(value) ? "Default_Name" : value; }
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

        public Club() : this(0, "Default_Name", MINIMUM_PHONE_NUMBER, new Address("Default_Street", "0", "000000", "Default_City"))
        {

        }

        public Club(int registrationNumber, string name, long phoneNumber, Address address)
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
            stringBuilder.Append(Address.GetInfo());

            return stringBuilder.ToString();
        }
    }
}