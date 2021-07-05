using System;
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
        public Todo FindById(int todoId)
        {
            return Todo[todoId];
        }
        public static Todo AddTodoItem(string description, bool done)
        {
            Todo todoToBeAdded = new Todo(description, done);
            Array.Resize(ref Todo, Size() + 1);
            Todo[^1] = todoToBeAdded;
            return Todo[^1];
        }
        public static void Clear()
        {
            Array.Empty<Person>();
        }
    }
}
