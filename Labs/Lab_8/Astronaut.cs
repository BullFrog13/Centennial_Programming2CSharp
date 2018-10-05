namespace Lab_8
{
    public class Astronaut
    {
        public static int Count = 0;
        private const int THRESHOLD = 5;

        public string Name { get; private set; }
        public string Nationality { get; private set; }

        private Astronaut(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;

            Count++;
        }

        public static Astronaut CreateAstronaut(string name, string nationality)
        {
            return Count < THRESHOLD ? new Astronaut(name, nationality) : null;
        }

        public void ChangeAstronautNumber(int number)
        {
            Count = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nNationality: {Nationality}";
        }
    }
}