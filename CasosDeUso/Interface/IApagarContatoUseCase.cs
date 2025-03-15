using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IApagarContatoUseCase
    {
        Task ExecutaAsync(Contato contato);
    }
}
