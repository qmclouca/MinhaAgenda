using CoreBusiness.Entidades;

namespace CasosDeUso.Interface
{
    public interface IVisualizarContatosUseCase
    {
        Task<Contato> ExecutaAsync(Guid contatoId);
        Task<List<Contato>> ExecutaListAsync(string filtro);
    }
}
