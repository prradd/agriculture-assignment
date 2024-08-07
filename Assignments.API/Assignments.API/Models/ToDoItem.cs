using System;

namespace Assignments.API.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public bool IsRepeating { get; set; }
        public int TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
