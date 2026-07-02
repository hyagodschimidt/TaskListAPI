using FluentValidation;
using TaksList.Data;
using TaksList.Exceptions;
using TaksList.Models.Classes;
using TaksList.Models.Requests;
using TaksList.Services.Interfaces;


namespace TaksList.Services
{


    public class RecurringTaskService : IRecurringTaskService
    {
        private readonly AppDbContext _db;
        private readonly IValidator<RecurringTaskRequest> _recurringTaskValidator;
        private readonly IValidator<UpdateRecurringTaskRequest> _updateRecurringTaskValidator;
        private readonly IValidator<ChangeRecurringTaskStatusRequest> _changeRecurringTaskStatusValidator;

        public RecurringTaskService
        (AppDbContext db,
        IValidator<RecurringTaskRequest> recurringTaskValidator,
        IValidator<UpdateRecurringTaskRequest> updateRecurringTaskValidator,
        IValidator<ChangeRecurringTaskStatusRequest> changeRecurringTaskStatusValidator)

        {
            _db = db;
            _recurringTaskValidator = recurringTaskValidator;
            _updateRecurringTaskValidator = updateRecurringTaskValidator;
            _changeRecurringTaskStatusValidator = changeRecurringTaskStatusValidator;
        }
        public void Create(RecurringTaskRequest request)
        {
            var result = _recurringTaskValidator.Validate(request);
            if (!result.IsValid)
                throw new RequestValidationException(result.Errors);

            var task = new RecurringTask

            {
                Title = request.Title,
                Description = request.Description,
                Days = request.Days,
                Schedule = request.Schedule != null ? TimeSpan.Parse(request.Schedule) : null,
                UserId = request.UserId
            };

            _db.RecurringTasks.Add(task);
            _db.SaveChanges();
        }

        public List<RecurringTask> GetAll()
        {
            return _db.RecurringTasks.ToList();
        }

        public RecurringTask GetById(int id)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null)
                throw new NotFoundException($"Tarefa recorrente com ID {id} não encontrada.");
            return task;
        }

        public void Update(int id, UpdateRecurringTaskRequest update)
        {

            var result = _updateRecurringTaskValidator.Validate(update);

            if (!result.IsValid)
                throw new RequestValidationException(result.Errors);

            var task = _db.RecurringTasks.Find(id);

            if (task == null)
                throw new NotFoundException($"Tarefa recorrente com ID {id} não encontrada.");

            if (update.Days != null)
            {
                task.Days = update.Days;
            }
            if (update.Schedule != null)
            {
                task.Schedule = TimeSpan.Parse(update.Schedule);
            }

            _db.SaveChanges();

        }

        public void ChangeStatus(int id, ChangeRecurringTaskStatusRequest request)
        {
            var result = _changeRecurringTaskStatusValidator.Validate(request);
            if (!result.IsValid)
                throw new RequestValidationException(result.Errors);
            var task = _db.RecurringTasks.Find(id);          
            if (task == null)
                throw new NotFoundException($"Tarefa recorrente com ID {id} não encontrada.");
            if (request.Status == task.Status)
                throw new BusinessException($"A tarefa recorrente com ID {id} já está com o status {request.Status}.");
            task.Status = request.Status;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null)
                throw new NotFoundException($"Tarefa recorrente com ID {id} não encontrada.");
            _db.RecurringTasks.Remove(task);
            _db.SaveChanges();

        }
    }
}
