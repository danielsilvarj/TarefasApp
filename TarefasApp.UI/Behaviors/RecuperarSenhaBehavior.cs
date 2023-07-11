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
    public class RecuperarSenhaBehavior : Behavior<ContentPage>
    {

        private SfDataForm _formRecuperarSenha;
        private Button _btnRecuperarSenha;


        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            _formRecuperarSenha = bindable.FindByName<SfDataForm>("formRecuperarSenha");
            _btnRecuperarSenha = bindable.FindByName<Button>("btnRecuperarSenha");

            _btnRecuperarSenha.Clicked += OnBtnRecuperarSenhaClicked;
        }

        private async void OnBtnRecuperarSenhaClicked(object sender, EventArgs e)
        {
            if (_formRecuperarSenha.Validate())
            {
                try
                {
                    var model = (RecuperarSenhaRequestModel)_formRecuperarSenha.DataObject;

                    var serviceHelper = new ServicesHelper();
                    var result = await serviceHelper.Post<RecuperarSenhaRequestModel, RecuperarSenhaResponseModel>("recuperar-senha", model);

                    await App.Current.MainPage.DisplayAlert("Sucesso!"
                                                           , $"Olá {result.Nome}, sua solicitação de recuperação de senha foi realizada com sucesso. Verifique sua caixa de entrada!"
                                                           , "Ok");

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
