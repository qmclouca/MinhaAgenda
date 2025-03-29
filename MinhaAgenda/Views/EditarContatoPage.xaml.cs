using CasosDeUso.Interface;
using CoreBusiness.Entidades;

namespace MinhaAgenda.Views;

[QueryProperty(nameof(ContatoId), "Id")]
public partial class EditarContatoPage : ContentPage
{
    private Contato? contato;

    private readonly IEditarContatoUseCase _editarContatoUseCase;
    private readonly IVisualizarContatosUseCase _visualizarContatosUseCase;
    public EditarContatoPage(IEditarContatoUseCase editarContatoUseCase, IVisualizarContatosUseCase visualizarContatoUseCase)
	{
		InitializeComponent();
        _editarContatoUseCase = editarContatoUseCase;
        _visualizarContatosUseCase = visualizarContatoUseCase;
    }

    public string ContatoId
    {
        set
        {
            contato = _visualizarContatosUseCase.ExecutaAsync(Guid.Parse(value)).GetAwaiter().GetResult();
            if(contato != null)
            {
                contatosCtrl.Name = contato.Nome;
                contatosCtrl.Phone = contato.Fone;
                contatosCtrl.Email = contato.Email;
                contatosCtrl.Address = contato.Endereco;
            }
        }
    }

    private async void contatoCtrl_OnCancel(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ContatosPage)}");
    }

    private void contatoCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Erro", e, "Ok");
    }

    private async void contatoCtrl_OnUpdate(object sender, EventArgs e)
    {
        contato.Nome = contatosCtrl.Name;
        contato.Fone = contatosCtrl.Phone;
        contato.Email = contatosCtrl.Email;
        contato.Endereco = contatosCtrl.Address;

        await _editarContatoUseCase.ExecutaAsync(contato);
        await Shell.Current.GoToAsync($"{nameof(ContatosPage)}");

    }
}