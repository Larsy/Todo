using System;
using Xunit;
using TodoIt.Model;
using TodoIt.Data;

namespace TodoIt.Tests
{
    public class TodoItTests
    {
        [Fact]
        public void PersonTest1()
        {
            //Arrange
            string firstName = "Lars";
            string lastName = "Karlsson";
            //Act
            Person person1 = new Person(firstName, lastName);

            //Assert
            Assert.InRange(person1.PersonId, 0, 5);
            Assert.Equal("Lars Karlsson", person1.FullName);
        }
        [Fact]
        public void PersonTest2()
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
        public void PersonTest3()
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
            Assert.InRange(person3.PersonId, 0 ,5);
            Assert.Equal("Tessan Testy Testsson", person3.FullName);
        }
        [Fact]
        public void PersonTest4()
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
        public void PersonTest5()
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
            Assert.InRange(person6.PersonId, 0, 5);
            Assert.Equal("Testor Testy Testorsson", person6.FullName);
        }
        [Fact]
        public void TodoTest1()
        {
            //Arrange
            string description = "Första uppgiften";

            //Act
            Todo first = new Todo(description);

            //Assert
            Assert.InRange(first.TodoId, 0, 1);
            Assert.Equal("Första uppgiften", first.Description);
        }
        [Fact]
        public void TodoTest2()
        {
            //Arrange
            string description = "Andra uppgiften";
            //Act
            Todo second = new Todo(description);

            //Assert
            Assert.InRange(second.TodoId, 0, 1);
            Assert.Equal("Andra uppgiften", second.Description);
        }
        [Fact]
        public void SequencerTest()
        {
            //Arrange
            int startingPersonId = Data.PersonSequencer.PersonId;
            int expectedEndingId = startingPersonId + 2;

            //Act
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();

            //Assert
            Assert.Equal(expectedEndingId, Data.PersonSequencer.PersonId);
        }
    }
}
