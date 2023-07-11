using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Requests;

namespace TarefasApp.UI.Models
{
    public class AutenticarViewModel
    {
        public AutenticarRequestModel AutenticarRequestModel { get; set; }


        public AutenticarViewModel()
        {
            this.AutenticarRequestModel = new AutenticarRequestModel();
        }





    }
}
