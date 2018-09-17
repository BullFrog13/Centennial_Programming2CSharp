using System;

namespace WhippetBus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[ , ] distanceRanges = { { 99, 25 }, { 299, 40 }, { 499, 55 }, { Int32.MaxValue, 70 } };

            Console.WriteLine("Please enter the distance traveled: ");
            var userInput = Console.ReadLine();
            var userDistance = Int32.Parse(userInput);
            int selectedPrice = 25;

            for (var i = 0; i < 3; i++)
            {
                if(userDistance > distanceRanges[i, 0])
                {
                    selectedPrice = distanceRanges[i + 1, 1];
                }
            }

            Console.WriteLine($"Your price would be {selectedPrice}");
        }
    }
}