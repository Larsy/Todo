using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
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
        private static int idCounter = 0;
        private readonly int personId;
        private int age = 0;
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private bool vaccinated = false;
        //Valt att spara gender som int, som får indexvärdet från enumen Genders. Detta gör det lätt att språkanpassa. Bara att initera Genders med members på det språk som önskas.
        private int gender = 0;

        public static int Counter
        {
            get { return idCounter; }
        }
        
        public int PersonId
        {
            get { return personId; }
        }

        public int Gender
        {
            get { return gender; }
            private set { gender = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentException("Förnamn får inte vara tomt!");
                }
                else
                { firstName = value; }
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
                if (value is null || value == string.Empty)
                {
                    throw new ArgumentException("Efternamn får inte vara tomt!");
                }
                else
                { lastName = value; }
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
            personId = idCounter++;
            FirstName = firstName;
            LastName = lastName;
        }
        public Person(string firstName, string middleName, string lastName, int age, int gender, bool isVaccinated)
        {
            personId = idCounter++;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Vaccinated = isVaccinated;
        }
    }
}
