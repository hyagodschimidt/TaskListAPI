using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Services.Interfaces
{
    public interface ITarefaService
    {
       
            public void CreateRecurringTask(RecurringTaskRequest request);
            public void CreateScheduledTask(ScheduledTaskRequest request);
            public List<RecurringTask> GetRecurringsTasks();
            public List<ScheduledTask> GetScheduledsTasks();
            public RecurringTask? GetRecurringTaskById(int id);
            public ScheduledTask? GetScheduledTaskByID(int id);
            public void UpdateRecurringTask(int id, UpdateRecurringTaskRequest request);
            public void UpdateScheduledTask(int id, UpdateScheduledTaskRequest request);
            public void DeleteRecurringTask(int id);
            public void DeleteScheduledTask(int id);
    }
}
