using System.Text;

namespace Assessment_1.Models
{
    public class Event
    {
        private Strokes stroke;
        private Distances distance;

        public Strokes Stroke
        {
            get => stroke;
            set => stroke = value;
        }

        public Distances Distance
        {
            get => distance;
            set => distance = value;
        }

        public Event()
        {
            Stroke = Strokes.Backstroke;
            Distance = Distances.A;
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