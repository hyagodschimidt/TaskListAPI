using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Services.Interfaces
{
    public interface IScheduledTaskService
    {
        public void CreateScheduledTask(ScheduledTaskRequest request);
        public List<ScheduledTask> GetScheduledsTasks();
        public ScheduledTask? GetScheduledTaskByID(int id);
        public void UpdateScheduledTask(int id, UpdateScheduledTaskRequest request);
        public void DeleteScheduledTask(int id);
    }
}
