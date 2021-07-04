using System;
using Xunit;
using Todo.Model;

namespace Todo.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            string firstName = "Lars";
            string lastName = "Karlsson";
            //Act
            Person person1 = new Person(firstName, lastName);

            //Assert
            //Assert.Equal(0, person1.PersonId);
            Assert.Equal("Lars Karlsson", person1.FullName);
        }
        [Fact]
        public void Test2()
        {
            //Arrange
            string firstName = "Inger";
            string lastName = "";
            
            //Act
            Person person2 = new Person(firstName, lastName);

            //Assert
            //Assert.Equal(2, person2.PersonId);
            Assert.Throws<ArgumentException>(() => person2);
        }
        [Fact]
        public void Test3()
        {
            //Arrange
            string firstName = "Tessan";
            string middleName = "Testy";
            string lastName = "Testsson";
            int age = 51;
            int gender = (int)Genders.Female;
            bool vaccinated = true;

            //Act
            Person person3 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            //Assert.Equal(1, person3.PersonId);
            Assert.Equal("Tessan Testy Testsson", person3.FullName);
        }
        [Fact]
        public void Test4()
        {
            //Arrange
            string firstName = "";
            string middleName = "";
            string lastName = "Hutt";
            int age = 51;
            int gender = (int)Genders.Other;
            bool vaccinated = false;

            //Act
            Person person5 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            Assert.IsType<ArgumentException>(person5);
        }
        [Fact]
        public void Test5()
        {
            //Arrange
            string firstName = "Testor";
            string middleName = "Testy";
            string lastName = "Testorsson";
            int age = 52;
            int gender = (int)Genders.Female;
            bool vaccinated = true;

            //Act
            Person person6 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            //Assert.Equal(3, person6.PersonId);
            Assert.Equal("Testor Testy Testorsson", person6.FullName);
        }
    }
}
