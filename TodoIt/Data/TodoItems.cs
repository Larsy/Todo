using System;
using System.Linq;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
        private static Todo[] Todo = new Todo[0];

        public static int Size()
        {
            return Todo.Length;
        }

        public static Todo[] FindAll()
        {
            return Todo;
        }

        public static Todo[] FindByDoneStatus(bool doneStatus)
        {
            return Array.FindAll(Todo, x => x.Done == doneStatus);
        }

        public static Todo[] FindByAssignee(int personId)
        {
            return Array.FindAll(Todo, x => !(x.Assignee is null) && x.Assignee.PersonId == personId);
        }

        public static Todo[] FindByAssignee(Person assignee)
        {
            return Array.FindAll(Todo, x => x.Assignee == assignee);
        }

        public static Todo[] FindUnassignedTodoItems()
        {
            return Array.FindAll(Todo, x => x.Assignee is null);
        }

        public static Todo FindById(int todoId)
        {
            int indexToFind;
            indexToFind = Array.FindIndex(Todo, x => x.TodoId == todoId);
            return Todo[indexToFind];
        }

        public static Todo AddTodoItem(string description, bool done)
        {
            Todo todoToBeAdded = new Todo(description, done);
            Array.Resize(ref Todo, Size() + 1);
            Todo[^1] = todoToBeAdded;
            return Todo[^1];
        }

        public static Todo AddTodoItem(string description, bool done, Person assignee)
        {
            Todo todoToBeAdded = new Todo(assignee, description, done);
            Array.Resize(ref Todo, Size() + 1);
            Todo[^1] = todoToBeAdded;
            return Todo[^1];
        }

        public static void RemoveTodoById(int todoId)
        {
            int indexToRemove;
            indexToRemove = Array.FindIndex(Todo, x => x.TodoId == todoId);
            Todo = Todo.Where((source, index) => index != indexToRemove).ToArray();
        }

        public static void Clear()
        {
            Todo = Array.Empty<Todo>();
        }
    }
}
