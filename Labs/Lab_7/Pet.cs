using System.Text;

namespace Lab_7
{
    public class Pet
    {
        private string name;
        private Person owner;
        private int age;
        private string description;
        private bool isHouseTrained;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsHouseTrained
        {
            get { return isHouseTrained; }
            set { isHouseTrained = value; }
        }

        public Pet(string name, int age, string description)
        {
            Name = name;
            Age = age;
            Description = description;
        }

        public Pet(string name, int age, string description, Person owner)
        {
            Name = name;
            Age = age;
            Description = description;
            Owner = owner;
        }

        public string TellAboutSelf()
        {
            var stringBuilder = new StringBuilder(150);
            stringBuilder.Append($"Name: {Name}\n");
            stringBuilder.Append($"Age: {Age}\n");
            stringBuilder.Append($"Description: {Description}\n");
            if (Owner != null)
            {
                stringBuilder.Append($"Owner: {Owner.TellAboutSelf()}");
            }

            return stringBuilder.ToString();
        }
    }
}