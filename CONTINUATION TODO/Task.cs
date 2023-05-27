using System;
using System.Collections.Generic;
using System.Text;

namespace CONTINUATION_TODO
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class Task
    {

        public string Name { get; set; }
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public string Completed { get; set; }
        public bool IsCompleted { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public Priority PriorityLevel { get; set; }
    }
}
