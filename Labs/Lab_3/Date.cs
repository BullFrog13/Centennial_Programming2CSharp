namespace Lab_3
{
    public class Date
    {
        private int year;
        private int month;
        private int day;

        public int Year
        {
            get => year;
            set => year = value;
        }

        public int Month
        {
            get => month;
            set => month = value;
        }

        public int Day
        {
            get => day;
            set => day = value;
        }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public string TellAboutYourself()
        {
            return $"{Day}-{Month}-{Year}";
        }

        public void AddDays(int howMany)
        {
            if (Day + howMany > 30)
            {
                if (Month == 12)
                {
                    Year++;
                    Month = 1;
                }
                else
                {
                    Month++;
                    Day = Day + howMany - 30;
                }
            }
            else
            {
                Day += howMany;
            }
        }
    }
}