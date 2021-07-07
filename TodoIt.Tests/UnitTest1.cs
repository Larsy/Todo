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
            Assert.Equal(firstName, person2.FirstName);
        }

        [Fact]
        public void PersonTest3()
        {
            //Arrange
            string firstName = "Tessan";
            string middleName = "Testy";
            string lastName = "Testsson";
            int age = 51;
            var gender = Genders.Female;
            bool vaccinated = true;

            //Act
            Person person3 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
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
            var gender = Genders.Other;
            bool vaccinated = false;

            //Act
            Person person4 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
            Assert.Equal(lastName, person4.LastName);
        }

        [Fact]
        public void PersonTest5()
        {
            //Arrange
            string firstName = "Testor";
            string middleName = "Testy";
            string lastName = "Testorsson";
            int age = 52;
            var gender = Genders.Male;
            bool vaccinated = true;

            //Act
            
            Person person5 = new Person(firstName, middleName, lastName, age, gender, vaccinated);

            //Assert
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
            Assert.Equal("Andra uppgiften", second.Description);
        }

        [Fact]
        public void PersonSequencerTest()
        {
            //Arrange
            int startingPersonId;
            int expectedEndingId;
            int actualEndingId;

            //Act
            PersonSequencer.reset();
            startingPersonId = Data.PersonSequencer.PersonId;
            expectedEndingId = startingPersonId + 4;
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            actualEndingId = Data.PersonSequencer.PersonId;
            PersonSequencer.reset();

            //Assert
            Assert.Equal(expectedEndingId, actualEndingId);
        }

        [Fact]
        public void TodoSequencerTest()
        {
            //Arrange
            int startingTodoId;
            int expectedEndingTodoId;
            int actualEndingTodoId;

            //Act
            TodoSequencer.reset();
            startingTodoId = Data.TodoSequencer.TodoId;
            expectedEndingTodoId = startingTodoId + 5;
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            actualEndingTodoId = Data.TodoSequencer.TodoId;
            TodoSequencer.reset();

            //Assert
            Assert.Equal(expectedEndingTodoId, actualEndingTodoId);
        }

        [Fact]
        public void PeopleTest()
        {
            //Arrange
            string firstName1 = "Lars";
            string middleName1 = "Einar";
            string lastName1 = "Karlsson";
            int age1 = 54;
            var gender1 = Genders.Male;
            bool vaccinated1 = true;

            string firstName2 = "Test";
            string middleName2 = "Testern";
            string lastName2 = "Testsson";
            int age2 = 30;
            var gender2 = Genders.NonBinary;
            bool vaccinated2 = false;

            string firstName3 = "Jabba";
            string middleName3 = "The";
            string lastName3 = "Hutt";
            int age3 = 300;
            var gender3 = Genders.Unknown;
            bool vaccinated3 = false;

            int personToRemove = 1;
            int expectedNoOfPeopleInitially = 3;
            int expectedNoOfPplAfterRemoval = 2;
            int expectedNoOfPplAfterClear = 0;
            int actualNoOfPeople;
            int actualNoOfPplAfterRemoval;
            int actualNoOfPplAfterClear;

            //Act
            PersonSequencer.reset();

            People.AddPerson(firstName1, middleName1, lastName1, age1, gender1, vaccinated1);
            People.AddPerson(firstName2, middleName2, lastName2, age2, gender2, vaccinated2);
            People.AddPerson(firstName3, middleName3, lastName3, age3, gender3, vaccinated3);

            Person[] personer = People.FindAll();

            actualNoOfPeople = People.Size();

            People.RemovePersonById(personToRemove);

            actualNoOfPplAfterRemoval = People.Size();

            People.Clear();

            actualNoOfPplAfterClear = People.Size();

            PersonSequencer.reset();

            //Assert

            //Räkna antalet personer i People-klassen
            Assert.Equal(expectedNoOfPeopleInitially, actualNoOfPeople);
            Assert.Equal(expectedNoOfPplAfterRemoval, actualNoOfPplAfterRemoval);
            Assert.Equal(expectedNoOfPplAfterClear, actualNoOfPplAfterClear);

            Assert.Equal(firstName1, personer[0].FirstName);
            Assert.Equal(middleName1, personer[0].MiddleName);
            Assert.Equal(lastName1, personer[0].LastName);
            Assert.Equal(age1, personer[0].Age);
            Assert.Equal("Male", personer[0].Gender);
            Assert.Equal(vaccinated1, personer[0].Vaccinated);

            Assert.Equal(firstName2, personer[1].FirstName);
            Assert.Equal(middleName2, personer[1].MiddleName);
            Assert.Equal(lastName2, personer[1].LastName);
            Assert.Equal(age2, personer[1].Age);
            Assert.Equal("NonBinary", personer[1].Gender);
            Assert.Equal(vaccinated2, personer[1].Vaccinated);
        }

        [Fact]
        public void TodoItemsTest()
        {
            //Arrange
            string item1_Description = "Ett första steg";
            string item2_Description = "Ett andra steg";
            string item3_Description = "Målgång";

            bool item1_Done = true;
            bool item2_Done = true;
            bool item3_Done = false;

            string assignee1_fName = "Lars";
            string assignee1_lName = "Karlsson";
            string assignee2_fName = "Test";
            string assignee2_lName = "Testsson";
            string assignee3_fName = "Tessan";
            string assignee3_lName = "Testsson";

            int todoToRemove = 2;
            int expectedNoOfItemsInitially = 3;
            int expectedNoOfItemsAfterRemoval = 2;
            int expectedNoOfItemsAfterClear = 0;
            int expectedNoOfDoneItems= 2;
            int expectedNoOfUnassignedItems = 2;
            int actualNoOfItemsInitially;
            int actualNoOfItemsAfterRemoval;
            int actualNoOfItemsAfterClear;

            //Act

            TodoSequencer.reset();

            Person assignee1 = new Person(assignee1_fName, assignee1_lName);
            Person assignee2 = new Person(assignee2_fName, assignee2_lName);
            Person assignee3 = new Person(assignee3_fName, assignee3_lName);

            TodoItems.AddTodoItem(item1_Description, item1_Done, assignee1);
            TodoItems.AddTodoItem(item2_Description, item2_Done);
            TodoItems.AddTodoItem(item3_Description, item3_Done);

            Todo[] doneItems = TodoItems.FindByDoneStatus(true);
            Todo[] assignedItemsByPerson = TodoItems.FindByAssignee(assignee1);
            Todo[] assignedItemsByPersonId = TodoItems.FindByAssignee(assignee1.PersonId);

            actualNoOfItemsInitially = TodoItems.Size();

            TodoItems.RemoveTodoById(todoToRemove);

            actualNoOfItemsAfterRemoval = TodoItems.Size();

            TodoItems.Clear();

            actualNoOfItemsAfterClear = TodoItems.Size();

            TodoSequencer.reset();
            
            //Assert
            Assert.Equal(item1_Description, doneItems[0].Description);
            Assert.Equal(item2_Description, doneItems[1].Description);
            Assert.Equal(expectedNoOfDoneItems, doneItems.Length);

            Assert.Equal(expectedNoOfUnassignedItems, actualNoOfItemsInitially - assignedItemsByPerson.Length);
            Assert.Equal(expectedNoOfUnassignedItems, actualNoOfItemsInitially - assignedItemsByPersonId.Length);

            Assert.Equal(expectedNoOfItemsInitially, actualNoOfItemsInitially);
            Assert.Equal(expectedNoOfItemsAfterRemoval, actualNoOfItemsAfterRemoval);
            Assert.Equal(expectedNoOfItemsAfterClear, actualNoOfItemsAfterClear);
        }
    }
}
