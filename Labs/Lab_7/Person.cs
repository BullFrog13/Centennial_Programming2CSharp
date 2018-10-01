using System.Text;

namespace Lab_7
{
    public class Person
    {
        private string name;
        private Gender gender;
        private Address address;
        private long phone;

        public Pet[] Pets = new Pet[10];

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Gender Gender
        {
            get { return gender; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public long Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Person(string name, Gender gender)
        {
            Name = name;
            this.gender = gender;
        }

        public Person(string name, Gender gender, Address address, long phone)
        {
            Name = name;
            this.gender = gender;
            Address = address;
            Phone = phone;
        }

        public string TellAboutSelf()
        {
            var stringBuilder = new StringBuilder(150);
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Gender: {Gender}");
            stringBuilder.Append($"Address: {address.Street} {address.City} {address.PostalCode} {address.Province}");
            stringBuilder.Append($"Phone: {Phone}");

            return stringBuilder.ToString();
        }
    }
}