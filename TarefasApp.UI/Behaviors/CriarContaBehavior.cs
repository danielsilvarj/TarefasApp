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
    public class CriarContaBehavior : Behavior<ContentPage>
    {

        private SfDataForm _formCriarConta;
        private Button _btnCriarConta;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            _formCriarConta = bindable.FindByName<SfDataForm>("formCriarConta");
            _btnCriarConta = bindable.FindByName<Button>("btnCriarConta");


            _btnCriarConta.Clicked += OnBtnCriarContaClicked;

        }

        private async void OnBtnCriarContaClicked(object sender, EventArgs e)
        {
            //await 
            if (_formCriarConta.Validate())
            {
                try
                {

                    var model = (CriarContaRequestModel)_formCriarConta.DataObject;

                    var servicesHelper = new ServicesHelper();
                    var result = await servicesHelper.Post<CriarContaRequestModel, CriarContaResponseModel>("criar-conta", model);

                    await App.Current.MainPage.DisplayAlert("Sucesso!"
                                                           , $"Parabens {result.Nome}, sua conta de usuário foi cadastrada com sucesso!"
                                                           , "Ok");

                    await Shell.Current.GoToAsync("///MainPage");
                }
                catch (Exception ex)
                {

                    await App.Current.MainPage.DisplayAlert("Aviso!", ex.Message, "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Aviso!"
                                                       , "Ocorreram erros de validação no preenchimento do formulário, por favor verifique."
                                                       , "OK"); ;
            }
        }

    }
}
