using System;

namespace Lab_4
{
    public class Date
    {
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
            var dateTimeDate = new DateTime(Year, (int)Month, Day);

            var newDateTime = dateTimeDate.AddDays(howMany);

            Day = newDateTime.Day;
            Month = (Months)newDateTime.Month;
            Year = newDateTime.Year;
        }
    }
}