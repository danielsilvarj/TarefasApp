using Newtonsoft.Json;
using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Helpers;
using TarefasApp.Services.Models.Requests;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Behaviors
{
    public class TarefasCadastroBehavior : Behavior<ContentPage>
    {
        private SfDataForm _formCriarTarefa;
        private Button _btnCriarTarefa;


        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            _formCriarTarefa = bindable.FindByName<SfDataForm>("formCriarTarefa");
            _btnCriarTarefa = bindable.FindByName<Button>("btnCriarTarefa");

            _btnCriarTarefa.Clicked += OnBtnCriarTarefaClicked;
        }

        private async void OnBtnCriarTarefaClicked(object sender, EventArgs e)
        {
            if (_formCriarTarefa.Validate())
            {
                try
                {
                    var model = (TarefasCadastroRequestModel)_formCriarTarefa.DataObject;

                    var auth = await SecureStorage.Default.GetAsync("auth_user");
                    var user = JsonConvert.DeserializeObject<AutenticarResponseModel>(auth);

                    var servicesHelper = new ServicesHelper(user.AccessToken);
                    var result = await servicesHelper.Post<TarefasCadastroRequestModel, TarefasConsultaResponseModel>("tarefas", model);


                    await App.Current.MainPage.DisplayAlert("Sucesso!"
                                                            , $"Tarefa {result.Nome}, Cadastrada com sucesso"
                                                            , "OK");
                }
                catch (Exception ex)
                {

                    await App.Current.MainPage.DisplayAlert("Erro!"
                                                        , ex.Message
                                                        , "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Aviso!"
                                                        , "Ocorreram erros de validação no formulario, porfavor verifique."
                                                        , "OK");
            }

        }
    }
}
