using Microsoft.AspNetCore.Mvc;
using TaksList.Classes;
using TaksList.Métodos;
using TaksList.Services;

namespace TaksList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        [HttpPost("diarias")]
        public IActionResult CriaTarefa([FromBody] TarefaDiariaRequest request)
        {
            var _tarefa = new TarefaDiaria
            {
                title = request.title,
                description = request.description,
                dias = request.dias,
                horario = request.horario,
                status = Enuns.StatusTarefa.EmAndamento
            };
            AdicionarTarefa.AdicionarDiaria(_tarefa);
            return Ok("tarefa criada");
        }

        [HttpPost("agenda")]

        public IActionResult CriaTarefaAgenda([FromBody] TarefaAgendaRequest request)
        {
            var _tarefa = new TarefaAgenda
            {
                title = request.title,
                description = request.description,
                previsaoConclusao = request.previsaoConclusao,
                status = Enuns.StatusTarefa.EmAndamento,
                conclusao = null,
                inicio = DateTime.UtcNow

            };
            AdicionarTarefa.AdicionarAgenda(_tarefa);
            return Ok("tarefa criada");
        }

        [HttpGet("diarias")]

        public IActionResult VerListaDiaria()
        {
            var lerdiaria = GetTarefas.VerDiarias();
            return Ok(lerdiaria);
        }

        [HttpGet("agenda")]

        public IActionResult VerListaAgenda()
        {
            var leragenda = GetTarefas.VerAgendas();
            return Ok(leragenda);
        }

        [HttpGet("diarias/{id}")]

        public IActionResult VerDiariaTarefa(int id)
        {
            var lerdiaria = AdicionarTarefa.tarefaDiarias.FirstOrDefault(t => t.id == id);
            if (lerdiaria == null)
            {
                return NotFound("Tarefa diária não encontrada.");
            }
            return Ok(lerdiaria);
        }

        [HttpGet("agenda/{id}")]

        public IActionResult VerAgendaTarefa(int id)
        {
            var leragenda = AdicionarTarefa.tarefaAgendas.FirstOrDefault(t => t.id == id);
            if (leragenda == null)
            {
                return NotFound("Tarefa de agenda não encontrada.");
            }
            return Ok(leragenda);
        }


        [HttpPut("diarias/{id}")]

        public IActionResult AtualizarDiariaTarefa(int id, [FromBody] AttDiaria atualizar)
        {
            var tarefa = AdicionarTarefa.tarefaDiarias.FirstOrDefault(t => t.id == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa diária não encontrada.");
            }

            if (atualizar.dias != null)
            {
                tarefa.dias = atualizar.dias;
            }
            if (atualizar.status != null)
            {
                tarefa.status = atualizar.status.Value;
            }
            return Ok("Tarefa diária atualizada.");
        }

        [HttpPut("agenda/{id}")]

        public IActionResult AtualizarAgendaTarefa(int id, [FromBody] AttAgenda atualizar)
        {
            var tarefa = AdicionarTarefa.tarefaAgendas.FirstOrDefault(t => t.id == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa de agenda não encontrada.");
            }

            if (atualizar.status != null)
            {
                tarefa.status = atualizar.status.Value;
                if (tarefa.status == Enuns.StatusTarefa.Concluida)
                {
                    tarefa.conclusao = DateTime.UtcNow;
                }
            }
            if (atualizar.previsaoConclusao != null)
            {
                tarefa.previsaoConclusao = atualizar.previsaoConclusao.Value;
            }

            return Ok("Tarefa de agenda atualizada.");


        }

        [HttpDelete("diarias/{id}")]

        public IActionResult DeletarDiariaTarefa(int id)
        {
            var tarefa = AdicionarTarefa.tarefaDiarias.FirstOrDefault(t => t.id == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa diária não encontrada.");
            }
            AdicionarTarefa.tarefaDiarias.Remove(tarefa);
            return Ok("Tarefa diária deletada.");

        }

        [HttpDelete("agenda/{id}")]

        public IActionResult DeletarAgendaTarefa(int id)
        {
            var tarefa = AdicionarTarefa.tarefaAgendas.FirstOrDefault(t => t.id == id);
            if (tarefa == null)
            {
                return NotFound("Tarefa de agenda não encontrada.");
            }
            AdicionarTarefa.tarefaAgendas.Remove(tarefa);
            return Ok("Tarefa de agenda deletada.");
        }
}

