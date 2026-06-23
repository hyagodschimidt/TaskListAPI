using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("recurring-tasks")]


    public class RecurringTaskController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IValidator<RecurringTaskRequest> _recurringTaskValidator;

        public RecurringTaskController(AppDbContext db, IValidator<RecurringTaskRequest> recurringTaskValidator)
        {

            _db = db;
            _recurringTaskValidator = recurringTaskValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RecurringTaskRequest request)
        {
            var resultado = _recurringTaskValidator.Validate(request);
            if (!resultado.IsValid)
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
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
            return Ok("tarefa criada");
        }



        [HttpGet]

        public IActionResult GetAll()
        {
            var list = _db.RecurringTasks.ToList();
            return Ok(list);
        }



        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null) return NotFound("tarefa não encontrada");
            return Ok(task);
        }




        [HttpPut("{Id}")]

        public IActionResult Update(int id, [FromBody] UpdateRecurringTaskRequest update)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null) return NotFound("tarefa não encontrada");
            if (update.Days != null)
            {
                task.Days = update.Days;
            }
            if (update.Status != null)
            {
                task.Status = update.Status.Value;
            }
            _db.SaveChanges();
            return Ok("AppTask diária atualizada.");
        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            var task = _db.RecurringTasks.Find(id);
            if (task == null) return NotFound();
            _db.RecurringTasks.Remove(task);
            _db.SaveChanges();
            return Ok("tarefa deletada");
        }
    }
}

