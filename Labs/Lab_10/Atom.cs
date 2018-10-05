using System;
using System.Globalization;

namespace Lab_10
{
    public class Atom
    {
        public string name;
        public string symbol;
        public int proton;
        public int neutron;
        public double weight;

        public Atom()
        {

        }

        public Atom(string name, int proton, int neutron, double weight, string symbol)
        {
            this.name = name;
            this.proton = proton;
            this.neutron = neutron;
            this.weight = weight;
            this.symbol = symbol;
        }

        public static Atom Parse(string objectData)
        {
            var inputStrings = objectData.Split();

            if (inputStrings.Length != 5)
            {
                throw new ArgumentException("The should be 5 input parameters!");
            }

            return new Atom(inputStrings[0], int.Parse(inputStrings[1]), int.Parse(inputStrings[2]), double.Parse(inputStrings[3], new CultureInfo("en")), inputStrings[4]);
        }

        public override string ToString()
        {
            return $"{symbol}-{name}: {proton}, {neutron}, {weight}";
        }
    }
}