namespace Lab_4
{
    public class Date
    {
        private const int DAYS_IN_YEAR = 365;

        private int year;
        private Months month;
        private int day;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Months Month
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
            Month = (Months)month;
            Day = day;
        }

        public string TellAboutYourself()
        {
            return $"{Day}-{Month}-{Year}";
        }

        public void AddDays(int howMany)
        {
            var years = howMany / DAYS_IN_YEAR;
            Year += years;
            howMany -= years * DAYS_IN_YEAR;

            var daysUntilNextMonth = GetMonthDays(Month) - Day;

            if (howMany <= daysUntilNextMonth)
            {
                Day += howMany;

                return;
            }

            Day = 1;
            AddMonth();
            howMany -= daysUntilNextMonth + 1;

            while (howMany != 0)
            {
                if (howMany < GetMonthDays(Month))
                {
                    Day += howMany;
                    howMany = 0;
                }
                else
                {
                    Day = 1;
                    howMany -= GetMonthDays(Month);
                    AddMonth();
                }
            }
        }

        private void AddMonth()
        {
            if (Month == Months.Dec)
            {
                Month = Months.Jan;
                Year++;
            }
            else
            {
                Month++;
            }
        }

        private int GetMonthDays(Months month)
        {
            switch (month)
            {
                case Months.Feb:
                    return 28;
                case Months.Apr:
                case Months.Jun:
                case Months.Sep:
                case Months.Nov:
                    return 30;
                default:
                    return 31;
            }
        }
    }
}