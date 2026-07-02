using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;
using TaksList.Services;
using TaksList.Services.Interfaces;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("recurring-tasks")]


    public class RecurringTaskController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IValidator<RecurringTaskRequest> _recurringTaskValidator;
        private readonly RecurringTaskService _service;

        public RecurringTaskController(AppDbContext db, IValidator<RecurringTaskRequest> recurringTaskValidator)
        {
            _service = new RecurringTaskService(db, recurringTaskValidator);
            _db = db;
            _recurringTaskValidator = recurringTaskValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RecurringTaskRequest request)
        {
            _service.Create(request);
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

