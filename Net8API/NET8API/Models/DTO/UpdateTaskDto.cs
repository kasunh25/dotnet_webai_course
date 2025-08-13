namespace NET8API.Models.DTO
{
    public class UpdateTaskDto
    {

        public double? ActualHours { get; set; } = 0;

        public required string? Status { get; set; }
    }
}