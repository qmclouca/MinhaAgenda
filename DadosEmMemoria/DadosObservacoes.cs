using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace DadosEmMemoria
{
    public class ObservacoesEmMemoria : IRepositorioDeObservacoes
    {
        private static readonly List<Observacoes> _observacoes = new();

        public ObservacoesEmMemoria()
        {
        }

        Task IRepositorioDeObservacoes.AdicionarAsync(Observacoes observacao)
        {
            _observacoes.Add(observacao);
            return Task.CompletedTask;
        }

        Task<List<Observacoes>> IRepositorioDeObservacoes.ListarPorContatoAsync(int contatoId)
        {
            var resultado = _observacoes
            .Where(o => o.ContatoId == contatoId)
            .ToList();

            return Task.FromResult(resultado);
        }
    }
}
