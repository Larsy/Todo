using System;
using TodoIt.Data;

namespace TodoIt.Model
{
    public enum Genders
    {
        Unknown,
        Male,
        Female,
        Other,
        NonBinary
    }

    public class Person
    {
        //private static int idCounter = 0;
        private readonly int personId;
        private int age = 0;
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private bool vaccinated = false;
        //Valt att spara gender som int, som får indexvärdet från enumen Genders.
        //Detta gör det t ex lätt att språkanpassa. Bara att initera Genders med members på det språk som önskas.
        //Standardvärde 0, vilket är första medlemmen i Genders, vilken representerar okänt
        private int genderId = 0;

        //public static int Counter
        //{
        //    get { return idCounter; }
        //}
        
        public int PersonId
        {
            get { return personId; }
        }

        public object Gender
        {
            get { return Enum.GetName(typeof(Genders), genderId); }
            private set { genderId = (int)value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            private set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
            }
        }

        public string FullName
        {
            get { return firstName + " " + (middleName.Length > 0 ? middleName + " " : "") + lastName; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public bool Vaccinated
        {
            get { return vaccinated; }
            private set { vaccinated = value; }
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            personId = PersonSequencer.nextPersonId();
        }
        public Person(string firstName, string middleName, string lastName, int age, object gender, bool isVaccinated)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Vaccinated = isVaccinated;
            personId = PersonSequencer.nextPersonId();
        }
    }
}
