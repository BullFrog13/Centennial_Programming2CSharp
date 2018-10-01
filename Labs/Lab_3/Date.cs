namespace Lab_3
{
    public class Date
    {
        private const ushort DAYS_IN_YEAR = 360;
        private const byte DAYS_IN_MONTH = 30;

        private int year;
        private int month;
        private int day;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
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
            var years = howMany / DAYS_IN_YEAR;
            howMany -= years * DAYS_IN_YEAR;

            var monthAdded = howMany / DAYS_IN_MONTH;
            howMany -= monthAdded * DAYS_IN_MONTH;

            Year += years;
            Month += monthAdded;
            Day += howMany;

            if (Month > 12)
            {
                Year++;
                Month -= 12;
            }

            if (Day > 30)
            {
                Day -= 30;
                Month++;
            }
        }
    }
}