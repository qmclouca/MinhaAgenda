using CasosDeUso.Interface;

namespace MinhaAgenda.Views;

public partial class AdicionarContatoPage : ContentPage
{
    private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;
	public AdicionarContatoPage(IAdicionarContatoUseCase adicionarContatoUseCase)
	{
		InitializeComponent();
        _adicionarContatoUseCase = adicionarContatoUseCase;
	}

    private async void contatoCtrl_OnSave(object sender, EventArgs e)
    {
        await _adicionarContatoUseCase.ExecutaAsync(new CoreBusiness.Entidades.Contato(contatosCtrl.Name, contatosCtrl.Phone, contatosCtrl.Email, contatosCtrl.Address));
        await Shell.Current.GoToAsync($"//{nameof(ContatosPage)}");
    }

    private void contatoCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContatosPage)}");
    }

    private void contatoCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Erro", e, "Ok");
    }
}