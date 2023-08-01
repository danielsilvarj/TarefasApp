using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Models
{
    public class TarefasConsultaViewModel
    {
        public List<TarefasConsultaResponseModel> Tarefas { get; set; }

        public TarefasConsultaViewModel()
        {
            var auth = SecureStorage.Default.GetAsync("auth_user").Result;
        }
    }
}
