namespace Lab_4
{
    public class Date
    {
        private int year;
        private Months month;
        private int day;

        public int Year
        {
            get => year;
            set => year = value;
        }

        public Months Month
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
            Month = (Months)month;
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
                if ((int)Month == 12)
                {
                    Year++;
                    Month = Months.Jan;
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