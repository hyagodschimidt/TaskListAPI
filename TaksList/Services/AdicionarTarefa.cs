using TaksList.Classes;

namespace TaksList.Services
{
    public static class AdicionarTarefa
    {
        
        public static List<TarefaAgenda> tarefaAgendas = new();
        public static List<TarefaDiaria> tarefaDiarias = new();
        

        public static void AdicionarDiaria(TarefaDiaria tarefa)
        {
            tarefa.id = tarefaDiarias.LastOrDefault()?.id + 1 ?? 0;
            tarefaDiarias.Add(tarefa);
        }

        public static  void AdicionarAgenda(TarefaAgenda tarefa)
        {
            tarefa.id = tarefaAgendas.LastOrDefault()?.id + 1 ?? 0;
            tarefaAgendas.Add(tarefa);

        }   
    }
}
