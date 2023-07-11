using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Requests;

namespace TarefasApp.UI.Models
{
    public class CriarContaViewModel
    {
        public CriarContaRequestModel criarContaRequestModel { get; set; }

        public CriarContaViewModel()
        {
            this.criarContaRequestModel = new CriarContaRequestModel();
        }
    }
}
