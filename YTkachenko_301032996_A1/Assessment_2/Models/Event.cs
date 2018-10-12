using System;
using System.Text;

namespace Assessment_2.Models
{
    public class Event
    {
        private static readonly byte MAXIMUM_NO_OF_SWIMMERS = 100;

        private Stroke stroke;
        private EventDistance distance;
        private SwimMeet swimMeet;
        private byte swimCounter;
        private readonly Swim[] swims = new Swim[MAXIMUM_NO_OF_SWIMMERS];

        public Stroke Stroke
        {
            get { return stroke; }
            set { stroke = value; }
        }

        public EventDistance Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public SwimMeet SwimMeet
        {
            get { return swimMeet; }
            set { swimMeet = value; }
        }

        public Event() : this(EventDistance._50, Stroke.Backstroke)
        {
        }

        public Event(EventDistance distance, Stroke stroke)
        {
            Stroke = stroke;
            Distance = distance;
        }

        public void AddSwimmer(Registrant registrant)
        {
            for (var i = 0; i < swims.Length; i++)
            {
                if (swims[i] != null)
                {
                    if (swims[i].Registrant.RegistrationNumber == registrant.RegistrationNumber)
                    {
                        throw new Exception($"Swimmer {registrant.Name}, {registrant.RegistrationNumber} is already entered");
                    }
                }
            }

            if (registrant != null)
            {
                swims[swimCounter++] = new Swim { Registrant = registrant };
            }
        }

        public void Seed()
        {
            ushort heat = 1;
            byte lane = 1;
            foreach (var swim in swims)
            {
                if (swim != null)
                {
                    swim.Heat = heat;
                    swim.Lane = lane;

                    if (lane == swimMeet.NoOfLanes)
                    {
                        lane = 1;
                        heat++;
                    }
                    else
                    {
                        lane++;
                    }
                }
            }
        }

        public void EnterSwimmersTime(Registrant swimmer, string time)
        {
            for (byte i = 0; i < swims.Length; i++)
            {
                if (swims[i] != null)
                {
                    if (swims[i].Registrant.RegistrationNumber == swimmer.RegistrationNumber)
                    {
                        swims[i].FinalSwimTime = time;
                    }
                }
            }
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Distance: {(int)Distance}m\n");
            stringBuilder.Append($"Strokes: {Stroke}");

            return stringBuilder.ToString();
        }
    }
}