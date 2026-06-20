using TaksList.Enuns;

namespace TaksList.Models.Classes
{
    public abstract class Tarefa
    {
        public int id { get; set; } 
        public string title { get; set; }
        public string? description { get; set; }
        public StatusTarefa status {  get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }

    public class TarefaDiaria : Tarefa
    {
        public List<DiasSemana> dias { get; set; }
        public TimeSpan? horario { get; set; }
    }

    public class TarefaAgenda : Tarefa
    {
        public int previsaoConclusao { get; set; }

        public DateTime inicio { get; set; } = DateTime.UtcNow;

        public DateTime? conclusao { get; set; }

    }
}
