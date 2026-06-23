using TaksList.Enuns;

namespace TaksList.Models.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TaskType Type { get; set; }
        public string Status { get; set; } = null!;
        public TimeSpan? Schedule { get; set; }
        public List<string>? Days { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
