using System.Text;
using System.Threading;

namespace Lab_2
{
    public class Car
    {
        private int year;
        private string manufacturer;
        private string model;
        private bool isDrivable;
        private double price;

        public int Year
        {
            get => year;
            set => year = value;
        }

        public string Manufacturer
        {
            get => manufacturer;
            set => manufacturer = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public bool IsDrivable
        {
            get => isDrivable;
            set => isDrivable = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public Car(int year, string manufacturer, string model, bool isDrivable, double price)
        {
            Year = year;
            Manufacturer = manufacturer;
            Model = model;
            IsDrivable = isDrivable;
            Price = price;
        }

        public string TellAboutYourself()
        {
            var stringBuilder = new StringBuilder(150);
            stringBuilder.Append($"Car was manufactured by {Manufacturer} in {Year}\n");
            stringBuilder.Append($"Car model: {Model}\n");
            stringBuilder.Append($"Car status: {(isDrivable ? "drivable" : "not drivable")}'n");
            stringBuilder.Append($"Car price: {Price}$\n");

            return stringBuilder.ToString();
        }
    }
}