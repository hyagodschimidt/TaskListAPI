using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Services.Interfaces
{
    public interface IRecurringTaskService
    {
       
            public void Create(RecurringTaskRequest request);
            public List<RecurringTask> GetAll();
            public RecurringTask? GetById(int id);
            public void Update(int id, UpdateRecurringTaskRequest request);
            public void ChangeStatus(int id, ChangeRecurringTaskStatusRequest request);
            public void Delete(int id);
    }
}
