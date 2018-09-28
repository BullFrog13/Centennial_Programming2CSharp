using System.Text;

namespace Assessment_1.Models
{
    public class Event
    {
        private Strokes stroke;
        private Distances distance;

        public Strokes Stroke
        {
            get { return stroke; }
            set { stroke = value; }
        }

        public Distances Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public Event() : this(Strokes.Backstroke, Distances.A)
        {

        }

        public Event(Strokes stroke, Distances distance)
        {
            Stroke = stroke;
            Distance = distance;
        }

        public string GetInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Distance: {(int)Distance}m\n");
            stringBuilder.Append($"Strokes: {Stroke}");

            return stringBuilder.ToString();
        }
    }
}