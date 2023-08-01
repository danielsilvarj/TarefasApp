using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Settings;

namespace TarefasApp.Services.Helpers
{
    public class ServicesHelper
    {
        private string? _accessToken;
        private AuthenticationHeaderValue? _authenticationHeaderValue;


        public ServicesHelper()
        {

        }

        public ServicesHelper(string accessToken)
        {
            _authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", accessToken);
            _accessToken = accessToken;
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/Json");



            using (var httpClient = new HttpClient())
            {

                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.PostAsync($"{AppSettings.BaseUrl}{endpoint}", content);

                var response = GetResponse(result);

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TResponse>(response);
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(response);
                    throw new Exception(error.Message);
                }
            }
        }

        public async Task<TResponse> Get<TResponse>(string endpoint)
        {
     
            using (var httpClient = new HttpClient())
            {

                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.GetAsync($"{AppSettings.BaseUrl}{endpoint}");

                var response = GetResponse(result);

                return JsonConvert.DeserializeObject<TResponse>(response);
            }
        }

        private string GetResponse(HttpResponseMessage result)
        {

            //Lendo a resposta obtida da API
            var builder = new StringBuilder();
            using (var r = result.Content)
            {
                Task<string> task = r.ReadAsStringAsync();
                builder.Append(task.Result);
            }


            return builder.ToString();
        }
    }

    public class ErrorResult
    {
        public string? Message { get; set; }
    }

}
