using TaksList.Enuns;

namespace TaksList.Models.Classes
{
    public abstract class AppTask
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

    }

    public class RecurringTask : AppTask
    {
        public List<WeekDays> Days { get; set; } = null!;
        public TimeSpan? Schedule { get; set; }

        public RecurringTaskStatus Status { get; set; }
    }

    public class ScheduledTask : AppTask
    {
        public ScheduledTaskStatus Status { get; set; }
        public DateTime DueDate { get; set; }

        public DateTime StartAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompleteAt { get; set; }

    }
}
