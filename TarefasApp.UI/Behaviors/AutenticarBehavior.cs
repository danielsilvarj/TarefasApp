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
    public class AutenticarBehavior : Behavior<ContentPage>
    {

        private Button _btnAcesso;
        private SfDataForm _formAutenticar;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            this._btnAcesso = bindable.FindByName<Button>("btnAcesso");
            this._btnAcesso.Clicked += OnButtonClicked;

            this._formAutenticar = bindable.FindByName<SfDataForm>("formAutenticar");
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (this._formAutenticar.Validate())
            {
                try
                {
                    var model = (AutenticarRequestModel)this._formAutenticar.DataObject;

                    var serviceHelper = new ServicesHelper();

                    var result = await serviceHelper.Post<AutenticarRequestModel, AutenticarResponseModel>("autenticar", model);

                    await App.Current.MainPage.DisplayAlert($"Olá, {result.Nome}", "Sua autenticação foi realizada com sucesso, seja bem vindo!", "OK");

                    // Secure Storage
                    await SecureStorage.Default.SetAsync("auth_user", JsonConvert.SerializeObject(result));

                    // Navegação
                    await Shell.Current.GoToAsync("///Dashboard");


                }
                catch (Exception ex)
                {

                    await App.Current.MainPage.DisplayAlert("Aviso!", ex.Message, "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Aviso!", "Ocorreram erros de validação no preenchimento do formulário, por favor verifique.", "OK");
            }
        }
    }
}
