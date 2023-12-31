﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Services.Models.Responses;

namespace TarefasApp.UI.Behaviors
{
    public class DashboardBehavior : Behavior<ContentPage>
    {

        private AutenticarResponseModel _autenticarResponseModel;

        private Label _nomeUsuario;
        private Label _emailUsuario;
        private Button _btnLogout;

        protected override async void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            #region Capturando Secure Storage

            var auth = await SecureStorage.GetAsync("auth_user");

            if (auth != null)
            {
                _autenticarResponseModel = JsonConvert.DeserializeObject<AutenticarResponseModel>(auth);

                #endregion


                #region Capturar os elementos da pagina
                this._nomeUsuario = bindable.FindByName<Label>("nomeUsuario");
                this._emailUsuario = bindable.FindByName<Label>("emailUsuario");
                this._btnLogout = bindable.FindByName<Button>("btnLogout");


                #endregion


                #region Criando Eventos

                _nomeUsuario.Text = _autenticarResponseModel.Nome;
                _emailUsuario.Text = _autenticarResponseModel.Email;
                _btnLogout.Clicked += OnLogoutClicked;


                #endregion
            }


        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            var isAccepted = await App.Current.MainPage.DisplayAlert("Sair da Conta"
                                                            , $"Olá {_autenticarResponseModel.Nome}, deseja realmente sair da sua conta?"
                                                            , "Sair"
                                                            , "Cancelar");

            if (isAccepted)
            {
                SecureStorage.Default.Remove("auth_user");

                await Shell.Current.GoToAsync("///MainPage");
            }
        }
    }
}
