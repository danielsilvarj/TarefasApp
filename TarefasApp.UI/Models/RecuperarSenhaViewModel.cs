using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Requests;

namespace TarefasApp.UI.Models
{
    public class RecuperarSenhaViewModel
    {
        public RecuperarSenhaRequestModel RecuperarSenhaRequestModel { get; set; }

        public RecuperarSenhaViewModel()
        {
            this.RecuperarSenhaRequestModel = new RecuperarSenhaRequestModel();
        }
    }
}
