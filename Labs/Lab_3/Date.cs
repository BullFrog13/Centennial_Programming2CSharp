namespace Lab_3
{
    public class Date
    {
        private const ushort DaysInYear = 360;
        private const byte DaysInMonth = 30;

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
            var years = howMany / DaysInYear;
            howMany -= years * DaysInYear;

            var monthAdded = howMany / DaysInMonth;
            howMany -= monthAdded * DaysInMonth;

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