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
            Tarefas = new List<TarefasConsultaResponseModel>();

            for (int i = 0; i < 6; i++)
            {
                Tarefas.Add(new TarefasConsultaResponseModel
                {
                    Nome = $"Tarefa {i} Modelo - Agenda",
                    DataHoraInicio = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    DataHoraFim = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    Categoria = "Categoria teste",
                    Observacoes = "Observações Teste"
                });
            }
        }
    }
}
