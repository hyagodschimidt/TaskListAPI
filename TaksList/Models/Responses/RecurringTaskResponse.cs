using TaksList.Enuns;

namespace TaksList.Models.Responses
{
    public class RecurringTaskResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public List<WeekDays> Days { get; set; } = null!;
        public RecurringTaskStatus Status { get; set; }
        public TimeSpan? Schedule { get; set; }

    }
}
