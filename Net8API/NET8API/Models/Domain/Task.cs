namespace NET8API.Models.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public required string TaskName { get; set; }

        public double EstimatedHours { get; set; } = 0;

        public double ActualHours { get; set; } = 0;

        public required string Status { get; set; } // e.g., "Not Started", "In Progress", "Completed"
    }
}
