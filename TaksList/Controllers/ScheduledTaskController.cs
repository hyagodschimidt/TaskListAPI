using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;

namespace TaksList.Controllers
{

    [ApiController]
    [Route("scheduled-tasks")]
    public class ScheduledTaskController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IValidator<ScheduledTaskRequest> _scheduleTaskValidator;

        public ScheduledTaskController(AppDbContext db, IValidator<ScheduledTaskRequest> scheduleTaskValidator)
        {

            _db = db;
            _scheduleTaskValidator = scheduleTaskValidator;
        }

        [HttpPost]

        public IActionResult Create([FromBody] ScheduledTaskRequest request)
        {
            var resultado = _scheduleTaskValidator.Validate(request);
            if (!resultado.IsValid)
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
            var _tarefa = new ScheduledTask
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Status = Enuns.ScheduledTaskStatus.InProgress,
                CompleteAt = null,
                StartAt = DateTime.UtcNow,
                UserId = request.UserId

            };
            _db.ScheduledTasks.Add(_tarefa);
            _db.SaveChanges();
            return Ok("tarefa criada");
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var list = _db.ScheduledTasks.ToList();
            return Ok(list);
        }

        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            var task = _db.ScheduledTasks.Find(id);
            if (task == null) return NotFound("AppTask de agenda não encontrada.");
            return Ok(task);
        }
        [HttpPut("{Id}")]

        public IActionResult Update(int id, [FromBody] UpdateScheduledTaskRequest update)
        {
            var task = _db.ScheduledTasks.Find(id);
            if (task == null) return NotFound("AppTask de agenda não encontrada.");
            if (update.Status != null)
            {
                task.Status = update.Status.Value;
                if (task.Status == Enuns.ScheduledTaskStatus.Completed)
                {
                    task.CompleteAt = DateTime.UtcNow;
                }
            }
            if (update.DueDate != null)
            {
                task.DueDate = update.DueDate.Value;
            }
            _db.SaveChanges();

            return Ok("AppTask de agenda atualizada.");


        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            var task = _db.ScheduledTasks.Find(id);
            if (task == null) return NotFound();
            _db.ScheduledTasks.Remove(task);
            _db.SaveChanges();
            return Ok("tarefa deletada");

        }
    }
}
