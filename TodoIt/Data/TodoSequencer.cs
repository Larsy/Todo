using System;

namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;
        public static int TodoId
        {
            get { return todoId; }
        }
        public static int nextTodoId()
        {
            return todoId++;
        }
        public static void reset()
        {
            todoId = 0;
        }
    }
}
