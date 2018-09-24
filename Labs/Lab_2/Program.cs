using System;

namespace Lab_2
{
    class Program
    {
        static void Main()
        {
            var car1 = new Car(2012, "Mazda", "RX8", true, 54000);
            var car2 = new Car(2008, "Toyota", "Supra", false, 26536);
            var car3 = new Car(2002, "Nissan", "Z350", true, 30000);
            var car4 = new Car(2018, "Audi", "R7", true, 110000);

            string carDescription1 = car1.TellAboutYourself();
            string carDescription2 = car2.TellAboutYourself();
            string carDescription3 = car3.TellAboutYourself();
            string carDescription4 = car4.TellAboutYourself();

            Console.WriteLine(carDescription1);
            Console.WriteLine();
            Console.WriteLine(carDescription2);
            Console.WriteLine();
            Console.WriteLine(carDescription3);
            Console.WriteLine();
            Console.WriteLine(carDescription4);
        }
    }
}