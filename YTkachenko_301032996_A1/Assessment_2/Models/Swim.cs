namespace Assessment_2.Models
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
            return $"Heat: {Heat}\nLane: {Lane}\nFinal swim time: {FinalSwimTime}";
        }
    }
}