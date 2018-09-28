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
            get { return startDate; }
            set
            {
                if (EndDate.Date != DateTime.MinValue && value.Date > EndDate.Date)
                {
                    StartDate = EndDate;
                }
                else
                {
                    startDate = value;
                }
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (StartDate.Date != DateTime.MinValue && value.Date < StartDate.Date)
                {
                    EndDate = StartDate;
                }
                else
                {
                    endDate = value;
                }
            }
        }

        public string Name
        {
            get { return name; }
            set { name = string.IsNullOrEmpty(value) ? "Default_Name" : value; }
        }

        public PoolType Course
        {
            get { return course; }
            set { course = value; }
        }

        public SwimMeet() : this(new DateTime(), new DateTime(), "Default_Name", PoolType.SCM)
        {

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