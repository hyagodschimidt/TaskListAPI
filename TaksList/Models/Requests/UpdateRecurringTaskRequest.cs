using TaksList.Enuns;

namespace TaksList.Models.Requests
{
    public class UpdateRecurringTaskRequest
    {
        public List<WeekDays>? Days { get; set; }

        public string? Schedule { get; set; }
    }
}
