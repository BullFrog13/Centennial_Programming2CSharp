using System;
using System.Text;
using Assessment_2.Utils;

namespace Assessment_2.Models
{
    public class Club
    {
        #region Statics

        private static readonly int MINIMUM_PHONE_NUMBER = 1000000000;
        private static readonly long MAXIMUM_PHONE_NUMBER = 9999999999;
        private static readonly byte DEFAULT_PHONE_NUMBER = 0;
        private static readonly byte MAXIMUM_NUMBER_OF_MEMBERS = 20;

        private static readonly int[] ClubIds = new int[20];

        #endregion

        #region Fields

        private int registrationNumber;
        private string name;
        private long phoneNumber;
        private Address address;

        private readonly Registrant[] Swimmers = new Registrant[MAXIMUM_NUMBER_OF_MEMBERS];
        private byte registrantCounter;

        #endregion

        #region Properties

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
                    phoneNumber = DEFAULT_PHONE_NUMBER;
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }

        #endregion

        public Club() : this(
            "Default_Name",
            new Address("Default_Street", "0", "000000", "Default_City"),
            DEFAULT_PHONE_NUMBER)
        {
        }

        public Club(string name, Address address, long phoneNumber, int registrationNumber = 0)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            RegistrationNumber = registrationNumber == 0 ? Helpers.GenerateUniqueId(ClubIds) : registrationNumber;
        }

        public void AddSwimmer(Registrant registrant)
        {
            if (IsSwimmerRegistered(registrant) || registrant.Club != null)
            {
                throw new Exception($"Swimmer already assigned to {registrant.Club.Name} club");
            }

            registrant.AddClub(this, true);

            Swimmers[registrantCounter++] = registrant;
        }

        public bool IsSwimmerRegistered(Registrant registrant)
        {
            foreach (var swimmer in Swimmers)
            {
                if (swimmer != null)
                {
                    if (swimmer.RegistrationNumber == registrant.RegistrationNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append(Address.GetInfo());
            stringBuilder.Append($"Phone: {PhoneNumber}\n");
            stringBuilder.Append($"Reg number: {RegistrationNumber}\n");
            stringBuilder.Append("Swimmers:\n");

            foreach (var swimmer in Swimmers)
            {
                if (swimmer != null)
                {
                    stringBuilder.Append($"\t{swimmer.Name}\n");
                }
            }

            return stringBuilder.ToString();
        }
    }
}