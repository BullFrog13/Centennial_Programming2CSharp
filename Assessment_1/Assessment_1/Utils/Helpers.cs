using System;
using System.Collections.Generic;

namespace Assessment_1.Utils
{
    public static class Helpers
    {
        public static uint GetRandomPositiveNumber()
        {
            var random = new Random();

            return (uint)random.Next(0, int.MaxValue);
        }

        public static uint GenerateIdForSequence(List<uint> sequence)
        {
            var number = GetRandomPositiveNumber();

            if (sequence.Contains(number))
            {
                number = GetRandomPositiveNumber();
            }

            return number;
        }
    }
}