using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Services.Models.Responses
{
    public class TarefasConsultaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? DataHoraInicio { get; set; }
        public string? DataHoraFim { get; set; }
        public string? Categoria { get; set; }
        public string? Observacoes { get; set; }
    }
}
