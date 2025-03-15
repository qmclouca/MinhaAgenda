using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IVisualizarContatosUseCase
    {
        Task<List<Contato>> ExecutaAsync(string filtro);
    }
}
