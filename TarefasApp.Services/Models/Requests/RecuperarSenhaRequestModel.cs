using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TarefasApp.Services.Models.Requests
{
    public class RecuperarSenhaRequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Entre com o seu email:", Prompt = "Email@email.com")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email de acesso.")]
        public string? Email { get; set; }
    }
}
