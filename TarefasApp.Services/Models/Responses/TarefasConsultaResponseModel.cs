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
        public string? DataInicio { get; set; }
        public string? DataFim { get; set; }
        public string? Categoria { get; set; }
        public string? Descricao { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
