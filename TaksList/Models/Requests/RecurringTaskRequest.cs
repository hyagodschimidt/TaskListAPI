using TaksList.Enuns;

namespace TaksList.Models.Requests
{
    public class RecurringTaskRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public List<WeekDays> Days { get; set; } = null!;
        public string? Schedule { get; set; } = null;
        public int UserId { get; set; }
    }


}
