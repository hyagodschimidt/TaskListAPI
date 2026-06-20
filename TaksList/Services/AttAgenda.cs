using TaksList.Enuns;
using TaksList.Models.Classes;

namespace TaksList.Services
{
    public class AttAgenda
    {
        public StatusTarefa? status { get; set; }
         public int? previsaoConclusao { get; set; }

        public TarefaAgenda AtualizarStatus(TarefaAgenda tarefa, StatusTarefa newstatus) 
        { 
            tarefa.status = newstatus;

            if(tarefa.status == StatusTarefa.Concluida)
            {
                tarefa.conclusao = DateTime.Now;
            }

            return tarefa;

        }
    }
}
