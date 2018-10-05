using System;
using System.Collections.Generic;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var astronauts = new List<Astronaut>
            {
                Astronaut.CreateAstronaut("Bob", "USA"),
                Astronaut.CreateAstronaut("Yevgeniy", "Ukraine"),
                Astronaut.CreateAstronaut("Paul", "Inia"),
                Astronaut.CreateAstronaut("Yaonung", "China"),
                Astronaut.CreateAstronaut("Pablo", "Brazilia"),
                Astronaut.CreateAstronaut("Tom", "Canada")
            };

            foreach (var astronaut in astronauts)
            {
                Console.WriteLine(astronaut?.ToString());
            }
        }
    }
}