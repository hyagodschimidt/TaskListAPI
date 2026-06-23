namespace TaksList.Models.Classes
{
    public class User
    { 
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public List<ScheduledTask> ScheduledTasks { get; set; } = null!;

        public List<RecurringTask> RecurringTasks { get; set; } = null!;
    }
}
