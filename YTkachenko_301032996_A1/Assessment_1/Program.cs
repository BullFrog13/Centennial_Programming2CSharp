using System;
using Assessment_1.Models;

namespace Assessment_1
{
    class Program
    {
        static void Main()
        {
            var defaultAddress = new Address("ChalField Lane", "123A", "L4Z1K8", "Mississauga");

            var defaultClub = new Club();
            var club1 = new Club(1, "Manchester City", 6479706472, defaultAddress);
            var club2 = new Club(1, "Polo Club", 6479706472, defaultAddress);

            Console.WriteLine(defaultClub.GetInfo());
            Console.WriteLine();
            Console.WriteLine(club1.GetInfo());
            Console.WriteLine();
            Console.WriteLine(club2.GetInfo());
            Console.WriteLine();

            var defaultEvent = new Event();
            var event1 = new Event(Strokes.Butterfly, Distances.E);

            Console.WriteLine(defaultEvent.GetInfo());
            Console.WriteLine();
            Console.WriteLine(event1.GetInfo());
            Console.WriteLine();

            var defaultRegistrant = new Registrant();
            var registrant1 = new Registrant(1, "Bob", new DateTime(1997, 2, 5), defaultAddress, 6479706472);
            var registrant2 = new Registrant(1, "Tom", new DateTime(2015, 3, 28), defaultAddress, 6479706472);

            Console.WriteLine(defaultRegistrant.GetInfo());
            Console.WriteLine();
            Console.WriteLine(registrant1.GetInfo());
            Console.WriteLine();
            Console.WriteLine(registrant2.GetInfo());
            Console.WriteLine();

            var defaultSwim = new Swim();
            var swim1 = new Swim(1, 5, TimeSpan.FromMinutes(5));
            var swim2 = new Swim(2, 2, TimeSpan.FromHours(1));

            Console.WriteLine(defaultSwim.GetInfo());
            Console.WriteLine();
            Console.WriteLine(swim1.GetInfo());
            Console.WriteLine();
            Console.WriteLine(swim2.GetInfo());
            Console.WriteLine();

            var defaultSwimMeet = new SwimMeet();
            var swimMeet1 = new SwimMeet(new DateTime(2018, 8, 5), new DateTime(2018, 8, 6), "Cup of Trust", PoolType.SCM);
            var swimMeet2 = new SwimMeet(new DateTime(2017, 1, 10), new DateTime(2017, 1, 10), "Red bull tournament", PoolType.SCY);

            Console.WriteLine(defaultSwimMeet.GetInfo());
            Console.WriteLine();
            Console.WriteLine(swimMeet1.GetInfo());
            Console.WriteLine();
            Console.WriteLine(swimMeet2.GetInfo());
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}