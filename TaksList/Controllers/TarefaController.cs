using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TaksList.Data;
using TaksList.Models.Classes;
using TaksList.Models.Requests;
using TaksList.Services;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class TarefaController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IValidator<TarefaAgendaRequest> _agendaValidator;
        private readonly IValidator<TarefaDiariaRequest> _diariaValidator;

        public TarefaController(AppDbContext db, IValidator<TarefaDiariaRequest> diariaValidator, IValidator<TarefaAgendaRequest> agendaValidator)
        {

            _db = db;
            _diariaValidator = diariaValidator;
            _agendaValidator = agendaValidator;
        }

        [HttpPost("diarias")]
        public IActionResult CriaTarefa([FromBody] TarefaDiariaRequest request)
        {
            var resultado = _diariaValidator.Validate(request);
            if (!resultado.IsValid)        
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));       
            var _tarefa = new TarefaDiaria
            
            {
                title = request.title,
                description = request.description,
                dias = request.dias,
                horario = request.horario != null ? TimeSpan.Parse(request.horario) : null,   
                userId = request.userId
            };                
               
            _db.TarefaDiarias.Add(_tarefa);
            _db.SaveChanges();
            return Ok("tarefa criada");
        }

        [HttpPost("agenda")]

        public IActionResult CriaTarefaAgenda([FromBody] TarefaAgendaRequest request)
        {
            var resultado = _agendaValidator.Validate(request);
            if (!resultado.IsValid)
                return BadRequest(resultado.Errors.Select(e => e.ErrorMessage));          
            var _tarefa = new TarefaAgenda
            {
                title = request.title,
                description = request.description,
                previsaoConclusao = request.previsaoConclusao,
                status = Enuns.StatusAgenda.EmAndamento,
                conclusao = null,
                inicio = DateTime.UtcNow,
                userId = request.userId

            };
            _db.TarefaAgendas.Add(_tarefa);
            _db.SaveChanges();
            return Ok("tarefa criada");
        }

        [HttpGet("diarias")]

        public IActionResult VerListaDiaria()
        {
            var lista = _db.TarefaDiarias.ToList();
            return Ok(lista);
        }

        [HttpGet("agenda")]

        public IActionResult VerListaAgenda()
        {
            var lista = _db.TarefaAgendas.ToList();
            return Ok(lista);
        }

        [HttpGet("diarias/{id}")]

        public IActionResult VerDiariaTarefa(int id)
        {
            var tarefa = _db.TarefaDiarias.Find(id);
            if (tarefa == null) return NotFound("tarefa não encontrada");
            return Ok(tarefa);
        }

        [HttpGet("agenda/{id}")]

        public IActionResult VerAgendaTarefa(int id)
        {
            var tarefa = _db.TarefaAgendas.Find(id);
            if (tarefa == null)  return NotFound("Tarefa de agenda não encontrada.");            
            return Ok(tarefa);
        }


        [HttpPut("diarias/{id}")]

        public IActionResult AtualizarDiariaTarefa(int id, [FromBody] AttDiaria atualizar)
        {
            var tarefa = _db.TarefaDiarias.Find(id);
            if (tarefa == null) return NotFound("tarefa não encontrada");
            if (atualizar.dias != null)
            {
                tarefa.dias = atualizar.dias;
            }
            if (atualizar.status != null)
            {
                tarefa.status = atualizar.status.Value;
            }
            _db.SaveChanges();
            return Ok("Tarefa diária atualizada.");
        }

        [HttpPut("agenda/{id}")]

        public IActionResult AtualizarAgendaTarefa(int id, [FromBody] AttAgenda atualizar)
        {
            var tarefa = _db.TarefaAgendas.Find(id); if (tarefa == null) return NotFound("Tarefa de agenda não encontrada.");
            if (atualizar.status != null)
            {
                tarefa.status = atualizar.status.Value;
                if (tarefa.status == Enuns.StatusAgenda.Concluida)
                {
                    tarefa.conclusao = DateTime.UtcNow;
                }
            }
            if (atualizar.previsaoConclusao != null)
            {
                tarefa.previsaoConclusao = atualizar.previsaoConclusao.Value;
            }
            _db.SaveChanges();

            return Ok("Tarefa de agenda atualizada.");


        }

        [HttpDelete("diarias/{id}")]

        public IActionResult DeletarDiariaTarefa(int id)
        {
          var tarefa = _db.TarefaDiarias.Remove(_db.TarefaDiarias.Find(id));
            if (tarefa == null) return NotFound();
            _db.SaveChanges();
          return Ok("tarefa deletada");
        }

        [HttpDelete("agenda/{id}")]

        public IActionResult DeletarAgendaTarefa(int id)
        {
            var tarefa =_db.TarefaAgendas.Remove(_db.TarefaAgendas.Find(id));
            if (tarefa == null) return NotFound();
            _db.SaveChanges();
            return Ok("tarefa deletada");

        }
    }
}

