using System;
using TodoIt.Data;

namespace TodoIt.Model
{
    public class Todo
    {
        //private static int idCounter = 0;
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public int TodoId
        {
            get { return todoId; }
        }
        public string Description
        {
            get { return description; }
            private set { description = value; }
        }
        public bool Done
        {
            get { return done; }
            private set { done = value; }
        }
        public Person Assignee
        {
            get { return assignee; }
            private set { assignee = value; }
        }
        public Todo (string description)
        {
            todoId = TodoSequencer.nextTodoId();
            Description = description;
        }
        public Todo (string description, bool done)
        {
            todoId = TodoSequencer.nextTodoId();
            Description = description;
            Done = done;
        }
    }
}
