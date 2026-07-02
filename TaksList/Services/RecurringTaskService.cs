using FluentValidation;
using System.Data;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;
using TaksList.Services.Interfaces;
using TaksList.Exceptions;


namespace TaksList.Services
{


    public class RecurringTaskService : IRecurringTaskService
    {
        private readonly AppDbContext _db;
        private readonly IValidator<RecurringTaskRequest> _recurringTaskValidator;

        public RecurringTaskService(AppDbContext db, IValidator<RecurringTaskRequest> recurringTaskValidator)
        {

            _db = db;
            _recurringTaskValidator = recurringTaskValidator;
        }
        public void Create(RecurringTaskRequest request)
        {
            var resultado = _recurringTaskValidator.Validate(request);
            if (!resultado.IsValid)
                throw new Exceptions.ValidationException(resultado.Errors);

            var _tarefa = new RecurringTask

            {
                Title = request.Title,
                Description = request.Description,
                Days = request.Days,
                Schedule = request.Schedule != null ? TimeSpan.Parse(request.Schedule) : null,
                UserId = request.UserId
            };

            _db.RecurringTasks.Add(_tarefa);
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
                throw new Exceptions.BusinessException($"Tarefa recorrente com ID {id} não encontrada.");
            return task;
        }

        public void Update(int id, UpdateRecurringTaskRequest update)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null)
                throw new Exceptions.BusinessException($"Tarefa recorrente com ID {id} não encontrada.");
            if (update.Days != null)
            {
                task.Days = update.Days;
            }
            if (update.Status != null)
            {
                task.Status = update.Status.Value;
            }
            _db.SaveChanges();
            
        }
        public void Delete(int id)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null) ;
            _db.RecurringTasks.Remove(task);
            _db.SaveChanges();
           
        }
    }
}
