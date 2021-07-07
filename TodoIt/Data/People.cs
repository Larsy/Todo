using System;
using System.Linq;
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
            int indexToFind;
            indexToFind = Array.FindIndex(Person, x => x.PersonId == personId);
            return Person[indexToFind];
        }

        public static Person AddPerson(string firstName, string middleName, string lastName, int age, object gender, bool vaccinated)
        {
            Person personToBeAdded = new Person(firstName, middleName, lastName, age, gender, vaccinated);
            Array.Resize(ref Person, Size() + 1);
            Person[^1] = personToBeAdded;
            return Person[^1];
        }

        public static void RemovePersonById(int personId)
        {
            int indexToRemove;
            indexToRemove = Array.FindIndex(Person, x => x.PersonId == personId);
            Person = Person.Where((source, index) => index != indexToRemove).ToArray();
        }

        public static void Clear()
        {
            Person = Array.Empty<Person>();
        }
    }
}
