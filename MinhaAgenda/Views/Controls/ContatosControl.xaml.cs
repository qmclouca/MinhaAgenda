using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;

namespace MinhaAgenda.Views.Controls;

public partial class ContatosControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;

    public ContatosControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty EnderecoProperty =
        BindableProperty.Create(
            nameof(Endereco),
            typeof(string),
            typeof(ContatosControl),
            propertyChanged: async (bindable, oldvalue, newvalue) =>
            {
                if (bindable is ContatosControl control && newvalue is string endereco)
                {
                    await control.MostrarEnderecoNoMapa(endereco);
                }
            });

    public string Endereco
    {
        get => (string)GetValue(EnderecoProperty);
        set => SetValue(EnderecoProperty, value);
    }

    private async Task MostrarEnderecoNoMapa(string endereco)
    {
        try
        {
            var localizacoes = await Geocoding.GetLocationsAsync(endereco);
            var localizacao = localizacoes?.FirstOrDefault();

            if (localizacao == null)
            {
                Debug.WriteLine("Endereço não encontrado para: " + endereco);
                return; // <- Evita o erro
            }

            var posicao = new Location(localizacao.Latitude, localizacao.Longitude);
            ContatoMap.MoveToRegion(MapSpan.FromCenterAndRadius(posicao, Distance.FromKilometers(0.5)));

            var pin = new Pin
            {
                Label = "Endereço do contato",
                Location = localizacao
            };

            ContatoMap.Pins.Clear();
            ContatoMap.Pins.Add(pin);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao mostrar endereço no mapa: {ex.Message}");
        }
    }


    public string Name
    {
        get
        {
            return entryName.Text;
        }
        set
        {
            entryName.Text = value;
        }
    }

    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }

    public string Address
    {
        get => entryAddress.Text;
        set
        {
            entryAddress.Text = value;

            // Atualiza o mapa quando a tela setar o Address
            Endereco = value;
        }
    }

    private async void btnLocalizacaoAtual_Clicked(object sender, EventArgs e)
    {
        try
        {
            var localizacao = await Geolocation.GetLastKnownLocationAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao obter localização atual: {ex.Message}");
        }
    }
    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Um nome é obrigatório");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors!)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }
        OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}