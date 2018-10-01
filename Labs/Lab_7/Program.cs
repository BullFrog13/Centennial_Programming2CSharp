using System;

namespace Lab_7
{
    class Program
    {
        static void Main()
        {
            var person1 = new Person("Bob", Gender.Male, new Address { City = "Toronto", PostalCode = "M4A3LA", Province = "ON", Street = "Chalfield Lane"}, 6479706472 );
            var person2 = new Person("Anabel", Gender.Female, new Address { City = "Toronto", PostalCode = "M3$AS4", Province = "ON", Street = "Bathurst Ave" }, 6479706472);

            var pet1 = new Pet("Bucky", 2, "Dog");
            var pet2 = new Pet("Roger", 3, "Parrot", person1);

            person1.Pets[0] = pet1;
            person2.Pets[0] = pet2;

            foreach (var pet in person1.Pets)
            {
                if (pet != null)
                {
                    Console.WriteLine(pet.TellAboutSelf());
                }
            }

            object[] objects = { person1, person2, pet1, pet2 };

            foreach (var o in objects)
            {
                if (o is Person)
                {
                    var person = (Person) o;
                    Console.WriteLine(person.TellAboutSelf());
                }
                else
                {
                    var pet = (Pet) o;
                    Console.WriteLine(pet.TellAboutSelf());
                }
            }

            Console.WriteLine(pet1.TellAboutSelf());
            Console.WriteLine(pet2.TellAboutSelf());
            Console.WriteLine(person1.TellAboutSelf());
        }
    }
}