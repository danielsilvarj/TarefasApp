using TarefasApp.UI.Views;

namespace TarefasApp.UI;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}


	private async void EsqueciMinhaSenhaTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new PasswordRecover());
	}


	private async void CriarContaTapped(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Register());
    }
}

