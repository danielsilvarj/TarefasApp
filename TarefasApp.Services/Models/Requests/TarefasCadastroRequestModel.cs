using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Services.Models.Requests
{
    public class TarefasCadastroRequestModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Entre com o nome da tarefa:")]
        [Required(ErrorMessage = "Por favor, Informa o nome da tarefa")]
        public string? Nome { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e hora de início:")]
        [Required(ErrorMessage = "Por favor, informe a data e hora de início")]
        public string? DataInicio { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data e hora de término:")]
        [Required(ErrorMessage = "Por favor, Informe a data e hora de término")]
        public string? DataFim { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Selecione a categoria desta tarefa:")]
        [Required(ErrorMessage = "Por favor, Selecione a categoria")]
        public string? Categoria { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informe as observações:")]
        public string? Observacoes { get; set; }
    }
}
