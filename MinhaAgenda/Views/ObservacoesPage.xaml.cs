
namespace MinhaAgenda.Views;

public partial class ObservacoesPage : ContentPage
{
	public ObservacoesPage()
	{
		InitializeComponent();
    }
    private async void btnObservacao_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ObservacoesPage));
    }

}