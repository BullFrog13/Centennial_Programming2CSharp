using System.Text;

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
            get { return year; }
            set { year = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public bool IsDrivable
        {
            get { return isDrivable; }
            set { isDrivable = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
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