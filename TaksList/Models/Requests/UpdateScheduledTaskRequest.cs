using TaksList.Enuns;
using TaksList.Models.Classes;

namespace TaksList.Models.Requests
{
    public class UpdateScheduledTaskRequest
    {
        public ScheduledTaskStatus? Status { get; set; }
        public DateTime? DueDate { get; set; }
        
    }
}
