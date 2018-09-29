using System;

namespace Lab_5
{
    class Program
    {
        static void Main()
        {
            //create a medal object
            Medal m1 = new Medal("Horace Gwynne", "Boxing", "Gold", 2012, true);
            //print the object
            Console.WriteLine(m1.TellAboutYourSelf());
            //print only the name of the medal holder
            Console.WriteLine(m1.Name);
            //assign a new object to m1
            m1 = new Medal("Michael Phelps", "Swimming", "Gold", 2012, false);
            //print the update m1
            Console.WriteLine(m1.TellAboutYourSelf());

            Medal[] medals =
            {
                new Medal("Ryan Cochrane", "Swimming", "Silver", 2012, false),
                new Medal("Adam van Koeverden", "Canoeing", "Silver", 2012, false),
                new Medal("Rosie MacLennan", "Gymnastics", "Gold", 2012, false),
                new Medal("Christine Girard", "Weightlifting", "Bronze", 2012, false),
                new Medal("Charles Hamelin", "Short Track", "Gold", 2014, true),
                new Medal("Alexandre Bilodeau", "Freestyle skiing", "Gold", 2012, true),
                new Medal("Jennifer Jones", "Curling", "Gold", 2014, false),
                new Medal("Charle Cournoyer", "Short Track", "Bronze", 2014, false),
                new Medal("Mark McMorris", "Snowboarding", "Bronze", 2014, false),
                new Medal("Sidney Crosby ", "Ice Hockkey", "Gold", 2014, false),
                new Medal("Brad Jacobs", "Curling", "Gold", 2014, false),
                new Medal("Ryan Fry", "Curling", "Gold", 2014, false),
                new Medal("Antoine Valois-Fortier", "Judo", "Bronze", 2012, false),
                new Medal("Brent Hayden", "Swimming", "Bronze", 2012, false)
            };

            foreach (var medal in medals)
            {
                Console.WriteLine(medal.TellAboutYourSelf());
                Console.WriteLine();
            }

            foreach (var medal in medals)
            {
                Console.WriteLine(medal.Name);
                Console.WriteLine();
            }

            foreach (var medal in medals)
            {
                if (medal.Color == Colors.Gold)
                {
                    Console.WriteLine(medal.TellAboutYourSelf());
                    Console.WriteLine();
                }
            }

            foreach (var medal in medals)
            {
                if (medal.Year == 2012)
                {
                    Console.WriteLine(medal.TellAboutYourSelf());
                    Console.WriteLine();
                }
            }

            foreach (var medal in medals)
            {
                if (medal.IsRecord)
                {
                    Console.WriteLine(medal.TellAboutYourSelf());
                    Console.WriteLine();
                }
            }
        }
    }
}