using TaksList.Enuns;

namespace TaksList.Models.Responses
{
    public class ScheduledTaskResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public ScheduledTaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartAt { get; set; } 
        public DateTime? CompletedAt { get; set; }

    } 
}
