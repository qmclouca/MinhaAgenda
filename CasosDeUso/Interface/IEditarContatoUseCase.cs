using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IEditarContatoUseCase
    {
        Task ExecutaAsync(Contato contato);
    }
}
