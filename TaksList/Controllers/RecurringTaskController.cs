using Microsoft.AspNetCore.Mvc;
using TaksList.Models.Requests;
using TaksList.Services.Interfaces;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("recurring-tasks")]


    public class RecurringTaskController : ControllerBase
    {
        private readonly IRecurringTaskService _service;

        public RecurringTaskController(IRecurringTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] RecurringTaskRequest request)
        {
            _service.Create(request);
            return StatusCode(201, "tarefa criada");
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var list = _service.GetAll();
            return Ok(list);
        }

        [HttpGet("{Id}")]

        public IActionResult GetById(int id)
        {
            var task = _service.GetById(id);
            return Ok(task);
        }

        [HttpPatch("{Id}")]

        public IActionResult Update(int id, [FromBody] UpdateRecurringTaskRequest update)
        {
            _service.Update(id, update);
            return NoContent();
        }

        [HttpPatch("{id}/status")]

        public IActionResult ChangeStatus(int id, [FromBody] ChangeRecurringTaskStatusRequest request)
        {
            _service.ChangeStatus(id, request);
            return NoContent();
        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}

