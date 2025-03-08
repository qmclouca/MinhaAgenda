using CoreBusiness.Entidades;

namespace CasosDeUso.PluginsInterfaces
{
    public interface IRepositorioDeContatos
    {
        Task<List<Contato>> BuscarContatos(string filtro);
        Task<List<Contato>> BuscarTodosContatos();
        Task AdicionarContato(Contato contato);
        Task AtualizarContato(Contato contato);
        Task ExcluirContato(Contato contato);
        Task<Contato> BuscarContatoPorId(Guid id);
        Task AtualizarContatoAsync(Contato contato);
        Task AdicionarContatoAsync(Contato contato);
        Task ExcluirContatoAsync(Contato contato);
    }
}
