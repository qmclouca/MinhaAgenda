using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace DadosEmMemoria
{
    // All the code in this file is included in all platforms.
    public class Dados : IRepositorioDeContatos
    {
        public Task AdicionarContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task AdicionarContatoAsync(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarContatoAsync(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task<Contato> BuscarContatoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contato>> BuscarContatos(string filtro)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contato>> BuscarTodosContatos()
        {
            throw new NotImplementedException();
        }

        public Task ExcluirContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirContatoAsync(Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
