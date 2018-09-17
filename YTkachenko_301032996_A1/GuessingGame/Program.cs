using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomNumber = GenerateRandomNumber(1, 12);

            Console.WriteLine("#####Welcome to the guessing game#####");
            Console.WriteLine("The program has generated a number. What is that?");
            Console.Write("Enter the number from 1 to 11: ");

            var userInput = Console.ReadLine();
            Console.WriteLine($"The guessed number was {randomNumber}");
            var userInputNumber = Int32.Parse(userInput);

            AnalyzeResult(userInputNumber, randomNumber);

            Console.ReadKey();
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            var ranNumberGenerator = new Random();

            return ranNumberGenerator.Next(1, 11);
        }

        private static void AnalyzeResult(int userInput, int numberToGuess)
        {
            if (userInput < numberToGuess)
            {
                Console.WriteLine("Your number was lower");
            }
            else if (userInput > numberToGuess)
            {
                Console.WriteLine("Your number was higher");
            }
            else
            {
                Console.WriteLine("You guessed correctly!");
            }
        }
    }
}