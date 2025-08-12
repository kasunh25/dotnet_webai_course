namespace NET8API.Models.DTO
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public required string TaskName { get; set; }

        public double EstimatedHours { get; set; } = 0;

        public double ActualHours { get; set; } = 0;

        public required string Status { get; set; } // e.g., "Not Started", "In Progress", "Completed"
    }
}
