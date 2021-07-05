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
            //Assert.InRange(person1.PersonId, 0, 5);
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
            //Assert.InRange(person3.PersonId, 0 ,5);
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
            Person person4 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            Assert.IsType<ArgumentException>(person4);
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
            Person person5 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            //Assert.InRange(person5.PersonId, 0, 5);
            Assert.Equal("Testor Testy Testorsson", person5.FullName);
        }
        [Fact]
        public void TodoTest1()
        {
            //Arrange
            string description = "Första uppgiften";

            //Act
            Todo first = new Todo(description);

            //Assert
            //Assert.InRange(first.TodoId, 0, 1);
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
            //Assert.InRange(second.TodoId, 0, 1);
            Assert.Equal("Andra uppgiften", second.Description);
        }
        [Fact]
        public void PersonSequencerTest()
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
        [Fact]
        public void TodoSequencerTest()
        {
            //Arrange
            int startingTodoId = Data.TodoSequencer.TodoId;
            int expectedEndingId = startingTodoId + 2;

            //Act
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();

            //Assert
            Assert.Equal(expectedEndingId, Data.TodoSequencer.TodoId);
        }
        [Fact]
        public void PeopleTest()
        {
            //Arrange
            string firstName1 = "Lars"; 
            string middleName1 = "Einar"; 
            string lastName1 = "Karlsson";
            int age1 = 54;
            int gender1 = (int)Genders.Male;
            bool vaccinated1 = true;

            string firstName2 = "Test"; 
            string middleName2 = "Testern"; 
            string lastName2 = "Testsson";
            int age2 = 54;
            int gender2 = (int)Genders.Unknown;
            bool vaccinated2 = false;
            int expectedNoOfPeople = 2;
            
            //Act
            Person person1 = People.AddPerson(firstName1, middleName1, lastName1, age1, gender1, vaccinated1);
            People.AddPerson(firstName2, middleName2, lastName2, age2, gender2, vaccinated2);
            Person[] personer = People.FindAll();

            //Assert
            //Räkna antalet personer i People-klassen
            Assert.Equal(expectedNoOfPeople, People.Size());
            //Se att metoden FindAll gör vad den ska
            Assert.Equal(expectedNoOfPeople, personer.Length);

            Assert.Equal(firstName1, person1.FirstName);
            Assert.Equal(middleName1, person1.MiddleName);
            Assert.Equal(lastName1, person1.LastName);
            Assert.Equal(age1, person1.Age);
            Assert.Equal("Male", Enum.GetName(typeof(Genders), person1.Gender));
            Assert.Equal(vaccinated1, person1.Vaccinated);

            Assert.Equal(firstName2, personer[1].FirstName);
            Assert.Equal(middleName2, personer[1].MiddleName);
            Assert.Equal(lastName2, personer[1].LastName);
            Assert.Equal(age2, personer[1].Age);
            Assert.Equal("Unknown", Enum.GetName(typeof(Genders), personer[1].Gender));
            Assert.Equal(vaccinated2, personer[1].Vaccinated);
        }
        [Fact]
        public void TodoItemsTest()
        {
            //Arrange
            string item1Description = "Ett första steg";
            string item2Description = "Ett andra steg";
            string item3Description = "Målgång";
            bool done1 = true;
            bool done2 = false;
            bool done3 = false;
            int expectedNoOfItems= 3;
            //string assignee1fN = "Lars";
            //string assignee1lN = "Karlsson";
            //string assignee2fN = "Test";
            //string assignee2lN = "Testsson";
            //string assignee3fN = "Tessan";
            //string assignee3lN = "Testsson";

            //Act
            TodoItems.AddTodoItem(item1Description, done1);
            TodoItems.AddTodoItem(item2Description, done2);
            TodoItems.AddTodoItem(item3Description, done3);
            Todo[] items = TodoItems.FindAll();

            //Assert
            Assert.Equal(expectedNoOfItems, TodoItems.Size());
            //Se att metoden FindAll gör vad den ska
            Assert.Equal(expectedNoOfItems, items.Length);
        }
    }
}
