using System;
using System.Globalization;
using System.Text;

namespace BusinessLogic.Models
{
    public class SwimMeet
    {
        private static readonly byte MAXIMUM_NO_OF_EVENTS = 50;

        #region Fields

        private DateTime startDate;
        private DateTime endDate;
        private string name;
        private readonly PoolType course;
        private byte noOfLanes;
        private byte eventCounter;
        private readonly Event[] events = new Event[MAXIMUM_NO_OF_EVENTS];

        #endregion

        #region Properties

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
        }

        public byte NoOfLanes
        {
            get { return noOfLanes; }
            set { noOfLanes = value; }
        }

        #endregion

        public SwimMeet() : this("Default_Name", new DateTime(), new DateTime(), PoolType.SCM, 8)
        {
        }

        public SwimMeet(string name, DateTime startDate, DateTime endDate, PoolType course, byte noOfLanes)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            this.course = course;
            NoOfLanes = noOfLanes;
        }

        public void AddEvent(Event @event)
        {
            events[eventCounter++] = @event;
            @event.SwimMeet = this;
        }

        public void Seed()
        {
            foreach (var @event in events)
            {
                @event?.Seed();
            }
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Swim meet name: {Name}\n");
            stringBuilder.Append(
                $"From-to: {StartDate.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en"))} to " +
                $"{EndDate.ToString("yyyy-MM-dd", CultureInfo.CreateSpecificCulture("en"))}\n");
            stringBuilder.Append($"Pool type: {Course.ToString()}\n");
            stringBuilder.Append($"No lanes: {NoOfLanes}\n");
            stringBuilder.Append("Events: \n");

            foreach (var @event in events)
            {
                if (@event != null)
                {
                    stringBuilder.Append($"\t{@event.GetInfo()}\n");
                }
            }

            return stringBuilder.ToString();
        }
    }
}