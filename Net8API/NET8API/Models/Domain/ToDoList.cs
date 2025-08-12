using System.ComponentModel.DataAnnotations;

namespace NET8API.Models.Domain
{
    public class ToDoList
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public ICollection<Task>? Tasks { get; set; }

    }
}
