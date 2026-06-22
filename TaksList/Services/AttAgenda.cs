using TaksList.Enuns;
using TaksList.Models.Classes;

namespace TaksList.Services
{
    public class AttAgenda
    {
        public StatusAgenda? status { get; set; }
         public int? previsaoConclusao { get; set; }

        public TarefaAgenda AtualizarStatus(TarefaAgenda tarefa, StatusAgenda newstatus) 
        { 
            tarefa.status = newstatus;

            if(tarefa.status == StatusAgenda.Concluida)
            {
                tarefa.conclusao = DateTime.Now;
            }

            return tarefa;

        }
    }
}
