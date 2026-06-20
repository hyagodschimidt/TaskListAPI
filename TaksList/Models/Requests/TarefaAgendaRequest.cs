namespace TaksList.Models.Requests
{
    public class TarefaAgendaRequest
    {
        public string title { get; set; }

        public string description { get; set; }

        public int previsaoConclusao { get; set; }

        public int userId { get; set; }

    }
}
