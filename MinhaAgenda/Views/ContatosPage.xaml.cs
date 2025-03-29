using CasosDeUso.Interface;
using CoreBusiness.Entidades;
using System.Collections.ObjectModel;

namespace MinhaAgenda.Views;

public partial class ContatosPage : ContentPage
{
    private readonly IVisualizarContatosUseCase _visualizarContatosUseCase;
    private readonly IApagarContatoUseCase _apagarContatoUseCase;
 
        
    public ContatosPage(IVisualizarContatosUseCase visualizarContatosUseCase, 
            IApagarContatoUseCase apagarContatoUseCase)
	{
		InitializeComponent();
        this._visualizarContatosUseCase = visualizarContatosUseCase;
        this._apagarContatoUseCase = apagarContatoUseCase;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        CarregarContatos();
    }

    private async void CarregarContatos()
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecutaListAsync(string.Empty));
        listaContatos.ItemsSource = contatos;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecutaListAsync(((SearchBar)sender!).Text));
        listaContatos.ItemsSource = contatos;
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        var contatos = new ObservableCollection<Contato>(await _visualizarContatosUseCase.ExecutaListAsync(((SearchBar)sender!).Text));
        listaContatos.ItemsSource = contatos;
    }

    private async void listaContatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(listaContatos.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditarContatoPage)}?Id={((Contato)listaContatos.SelectedItem).Id}");
        }
    }

    private void listaContatos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listaContatos.SelectedItem = null;
    }

    private async void Apagar_Clicked(object sender, EventArgs e)
    {
        var itemMenu = sender as MenuItem;
        var contato = itemMenu!.CommandParameter as Contato;
        await _apagarContatoUseCase.ExecutaAsync(contato!);
        CarregarContatos();
    }

    private async void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AdicionarContatoPage)}");
    }
}