namespace TaksList.Models.Classes
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        
        public List<TarefaAgenda> TarefaAgendas { get; set; }

        public List<TarefaDiaria> TarefaDiarias { get; set; }
    }
}
