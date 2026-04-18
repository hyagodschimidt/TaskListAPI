using System.Reflection.Metadata.Ecma335;
using TaksList.Classes;

namespace TaksList.Services
{
    public  class GetTarefas
    {
        public static List<TarefaDiaria> VerDiarias()
        {
           

            return AdicionarTarefa.tarefaDiarias;

        }

        public static List<TarefaAgenda> VerAgendas()
        {
           
            
                return AdicionarTarefa.tarefaAgendas;

        }
        public static void VerTodas()
        {
            Console.WriteLine("Tarefas Diárias:");
            VerDiarias();
            Console.WriteLine("\nTarefas de Agenda:");
            VerAgendas();
        }
     
    }
}
