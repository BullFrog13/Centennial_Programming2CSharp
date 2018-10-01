namespace Lab_8
{
    public class Astronaut
    {
        public static int ASTRONAUT_COUNT = 0;
        private const int THRESHOLD = 5;

        public string Name { get; private set; }
        public string Nationality { get; private set; }

        private Astronaut(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;

            ASTRONAUT_COUNT++;
        }

        public Astronaut CreateAstronaut(string name, string nationality)
        {
            return ASTRONAUT_COUNT < THRESHOLD ? new Astronaut(name, nationality) : null;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nNationality: {Nationality}";
        }
    }
}