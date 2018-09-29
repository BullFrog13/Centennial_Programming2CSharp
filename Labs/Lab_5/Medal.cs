using System;

namespace Lab_5
{
    public class Medal
    {
        private Colors colors;
        private bool isRecord;
        private string name;
        private string theEvent;
        private int year;

        public Colors Color
        {
            get => colors;
            private set => colors = value;
        }

        public bool IsRecord
        {
            get => isRecord;
            private set => isRecord = value;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public string TheEvent
        {
            get => theEvent;
            private set => theEvent = value;
        }

        public int Year
        {
            get => year;
            private set => year = value;
        }

        public Medal(string name, string theEvent, string color, int year, bool isRecord)
        {
            Name = name;
            TheEvent = theEvent;
            Year = year;
            IsRecord = isRecord;
            Color = GetColorForString(color);
        }

        public string TellAboutYourSelf()
        {
            return $"{Year} - {TheEvent}{(IsRecord ? "(R)" : string.Empty)} {Name}({Color.ToString()})\n";
        }

        private Colors GetColorForString(string color)
        {
            var colorLowerCase = color.ToLower();

            switch (colorLowerCase)
            {
                case "gold":
                    return Colors.Gold;
                case "silver":
                    return Colors.Silver;
                case "bronze":
                    return Colors.Bronze;
                default:
                    throw new ArgumentException("Input color string was not a valid color");
            }
        }
    }
}