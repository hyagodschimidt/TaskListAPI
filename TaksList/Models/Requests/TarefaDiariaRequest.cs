using Microsoft.Extensions.Primitives;
using TaksList.Enuns;
using TaksList.Models.Classes;

namespace TaksList.Models.Requests
{
    public class TarefaDiariaRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<DiasSemana> dias {  get; set; }
        public TimeSpan? horario { get; set; }
        public StatusTarefa status { get; internal set; }

        public int userId { get; set; }
    }


}
