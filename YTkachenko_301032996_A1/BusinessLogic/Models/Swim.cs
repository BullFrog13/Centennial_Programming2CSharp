using System.Text;

namespace BusinessLogic.Models
{
    public class Swim
    {
        private ushort heat;
        private byte lane;
        private string finalSwimTime;
        private Registrant registrant;

        public ushort Heat
        {
            get { return heat; }
            set { heat = value; }
        }

        public byte Lane
        {
            get { return lane; }
            set { lane = value; }
        }

        public string FinalSwimTime
        {
            get { return finalSwimTime; }
            set { finalSwimTime = value; }
        }

        public Registrant Registrant
        {
            get { return registrant; }
            set { registrant = value; }
        }

        public Swim() : this(0, 0, string.Empty, new Registrant())
        {
        }

        public Swim(ushort heat, byte lane, string finalSwimTime, Registrant registrant)
        {
            Heat = heat;
            Lane = lane;
            FinalSwimTime = finalSwimTime;
            Registrant = registrant;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{Registrant.Name}\n\t");

            if (Heat == 0 || Lane == 0)
            {
                stringBuilder.Append("\tNot seeded/no swim");
            }
            else
            {
                stringBuilder.Append($"\tH{Heat}L{Lane}");
                stringBuilder.Append(string.IsNullOrEmpty(FinalSwimTime)
                    ? "  time: no time"
                    : $"  time: {FinalSwimTime}");
            }

            return stringBuilder.ToString();
        }
    }
}