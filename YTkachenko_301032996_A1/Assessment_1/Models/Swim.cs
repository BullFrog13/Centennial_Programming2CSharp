using System;

namespace Assessment_1.Models
{
    public class Swim
    {
        private ushort heat;
        private byte lane;
        private TimeSpan finalSwimTime;

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

        public TimeSpan FinalSwimTime
        {
            get { return finalSwimTime; }
            set
            {
                if (value < TimeSpan.Zero || value > TimeSpan.FromDays(1))
                {
                    finalSwimTime = TimeSpan.Zero;
                }
                else
                {
                    finalSwimTime = value;
                }
            }
        }

        public Swim() : this(0, 0, TimeSpan.Zero)
        {

        }

        public Swim(ushort heat, byte lane, TimeSpan finalSwimTime)
        {
            Heat = heat;
            Lane = lane;
            FinalSwimTime = finalSwimTime;
        }

        public string GetInfo()
        {
            return $"Heat: {Heat}\nLane: {Lane}\nFinal swim time: {FinalSwimTime}";
        }
    }
}