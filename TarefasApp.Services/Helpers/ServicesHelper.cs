using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Settings;

namespace TarefasApp.Services.Helpers
{
    public class ServicesHelper
    {
        public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/Json");



            using (var httpClient = new HttpClient())
            {
                //Fazendo a requisição para a API
                var result = await httpClient.PostAsync($"{AppSettings.BaseUrl}{endpoint}", content);

                //Lendo a resposta obtida da API
                var builder = new StringBuilder();
                using (var r = result.Content)
                {
                    Task<string> task = r.ReadAsStringAsync();
                    builder.Append(task.Result);
                }

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TResponse>(builder.ToString());
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(builder.ToString());
                    throw new Exception(error.Message);
                }
            }
        }
    }

    public class ErrorResult
    {
        public string? Message { get; set; }
    }

}
