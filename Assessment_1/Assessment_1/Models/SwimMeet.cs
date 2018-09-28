using System;
using System.Text;

namespace Assessment_1.Models
{
    public class SwimMeet
    {
        private DateTime startDate;
        private DateTime endDate;
        private string name;
        private PoolType course;

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (EndDate.Date != DateTime.MinValue && value.Date > EndDate.Date)
                {
                    throw new ArgumentException($"Start date {value:d} cannot be before start date {StartDate:d}");
                }

                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (StartDate.Date != DateTime.MinValue && value.Date < StartDate.Date)
                {
                    throw new ArgumentException($"End date {value:d} cannot be before start date {StartDate:d}");
                }

                endDate = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name should not be null or empty");
                }

                name = value;
            }
        }

        public PoolType Course
        {
            get => course;
            set => course = value;
        }

        public SwimMeet()
        {
            StartDate = new DateTime();
            EndDate = new DateTime();
            Name = "Default_Name";
            Course = 0;
        }

        public SwimMeet(DateTime startDate, DateTime endDate, string name, PoolType course)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Course = course;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Swim meet starting date: {StartDate:D}\n");
            stringBuilder.Append($"Swim meet ending date: {EndDate:D}\n");
            stringBuilder.Append($"Swim meet name: {Name}\n");
            stringBuilder.Append($"Swim meet course: {Course.ToString()}");

            return stringBuilder.ToString();
        }
    }
}