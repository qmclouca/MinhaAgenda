using CoreBusiness.Entidades;

namespace CasosDeUso.PluginsInterfaces
{
    public interface IRepositorioDeObservacoes
    {
        Task AdicionarAsync(Observacoes observacao);
        Task<List<Observacoes>> ListarPorContatoAsync(int contatoId);
    }
}
