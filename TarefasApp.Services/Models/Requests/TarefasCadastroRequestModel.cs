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
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        //[DataFormDateRange(DisplayFormat = "yyyy/mm/dd", MaximumDate = "2022/07/01", MaximumDate = "2022/07/07")]
        [Display(Name = "Data e hora de início:")]
        [Required(ErrorMessage = "Por favor, informe a data de início")]
        public DateTime? DataInicio { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        
        [Display(Name = "Data e hora de término:")]
        [Required(ErrorMessage = "Por favor, Informe a data de término")]
        public DateTime? DataFim { get; set; } = DateTime.Now;

        [DataType(DataType.Text)]
        [Display(Name = "Selecione a categoria desta tarefa:")]
        [Required(ErrorMessage = "Por favor, Selecione a categoria")]
        public string? Categoria { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Informe a Descrição da tarefa:")]
        public string? Descricao { get; set; }
    }
}
