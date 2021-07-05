using System;
using TodoIt.Model;


namespace TodoIt.Data
{
    public class People
    {
        private static Person[] Person = new Person[0];

        public static int Size()
        {
            return Person.Length;
        }
        public static Person[] FindAll()
        {
            return Person;
        }
        public static Person FindById(int personId)
        {
            return Person[personId];
        }
        public static Person AddPerson(string firstName, string middleName, string lastName, int age, int gender, bool vaccinated)
        {
            Person personToBeAdded = new Person(firstName, middleName, lastName, age, gender, vaccinated);
            Array.Resize(ref Person, Size() + 1);
            Person[^1] = personToBeAdded;
            return Person[^1];
        }
        public static void Clear()
        {
            Array.Empty<Person>();
        }
    }
}
