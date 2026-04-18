using system;

    public abstract class Tarefa
    {
        int id { get; set; }
        string title { get; set; }
        string description { get; set; }
        enum StatusTarefa status { get; set; }
    }

    public class TarefaRotina : Tarefa
    {
        public Liss
        public TimeSpan? horario { get; set; }

    }

    public class TarefaAgenda : Tarefa
    {
        public DateTime iniciotarefa { get; set; } = DateTime.UtcNow
        public Dat conclusaoTarefa { get; set; }
        public int tempoEsperado { get; set; }

    }
}