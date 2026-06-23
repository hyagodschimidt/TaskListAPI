namespace TaksList.Models.Requests
{
    public class ScheduledTaskRequest
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int UserId { get; set; }

    }
}
