using System;
using TodoIt.Model;

namespace TodoIt
{
    class Program
    {
        static void Main()
        {
            Person person1 = new Person("Lars", "Karlsson");
            
            Console.WriteLine("Id".PadRight(15) + person1.PersonId);
            Console.WriteLine("Förnamn:".PadRight(15) + person1.FirstName);
            Console.WriteLine("Efternamn:".PadRight(15) + person1.LastName);
            Console.WriteLine();
 
            Person person2 = new Person("Tessan", "Testy", "Testsson", 51, (int)Genders.Female, true);
            
            Console.WriteLine("Id".PadRight(15) + person2.PersonId);
            Console.WriteLine("Namn:".PadRight(15) + person2.FullName);
            Console.WriteLine("Ålder:".PadRight(15) + person2.Age);
            Console.WriteLine("Kön:".PadRight(15) + Enum.GetName(typeof(Genders), person2.Gender));
            Console.WriteLine("Vaccinerad:".PadRight(15) + person2.Vaccinated);
            Console.WriteLine();

            Person person3 = new Person("Testor", "Testy", "Testorsson", 54, (int)Genders.Male, true);

            Console.WriteLine("Id".PadRight(15) + person3.PersonId);
            Console.WriteLine("Namn:".PadRight(15) + person3.FullName);
            Console.WriteLine("Ålder:".PadRight(15) + person3.Age);
            Console.WriteLine("Kön:".PadRight(15) + Enum.GetName(typeof(Genders), person3.Gender));
            Console.WriteLine("Vaccinerad:".PadRight(15) + person3.Vaccinated);
        }
    }
}
