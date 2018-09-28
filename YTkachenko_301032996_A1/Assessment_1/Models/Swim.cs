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
            get => heat;
            set => heat = value;
        }

        public byte Lane
        {
            get => lane;
            set => lane = value;
        }

        public TimeSpan FinalSwimTime
        {
            get => finalSwimTime;
            set
            {
                if (value < TimeSpan.Zero || value > TimeSpan.FromDays(1))
                {
                    throw new ArgumentException($"Final swim time {value} is out of range");
                }

                finalSwimTime = value;
            }
        }

        public Swim()
        {
            Heat = 0;
            Lane = 0;
            FinalSwimTime = TimeSpan.Zero;
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