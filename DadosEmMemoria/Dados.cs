using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace MinhaAgenda.Plugins.DadosEmMemoria
{   
    public class Dados : IRepositorioDeContatos
    {
        public static List<Contato> _contatos;
        
        public Dados()
        {
            _contatos = new List<Contato>()
            {
                new Contato("João","111-111-1111", "João@teste.com","endereço 1" ),
                new Contato("Lucas","222-111-1111", "Lucas@teste.com","endereço 2" ),
                new Contato("Paulo","333-111-1111", "Paulo@teste.com","endereço 3" ),
                new Contato("Mateus","4444-111-1111", "Mateus@teste.com","endereço 4" ),
                new Contato("Leonardo","111-111-1111", "Leonardo@teste.com","endereço 5" ),
            };
        }
        public Task AdicionarContato(Contato contato)
        {
            if(_contatos == null) _contatos = new List<Contato>();
            _contatos.Add(contato);
            return Task.CompletedTask;
        }

        public Task AdicionarContatoAsync(Contato contato)
        {
            if (_contatos == null) _contatos = new List<Contato>();
            _contatos.Add(contato);
            return Task.CompletedTask;
        }

        public Task AtualizarContato(Contato contato)
        {
           var contatoAtualizar = _contatos.FirstOrDefault(c => c.Id == contato.Id);
            if (contatoAtualizar != null)
            {
                contatoAtualizar.Nome = contato.Nome;
                contatoAtualizar.Fone = contato.Fone;
                contatoAtualizar.Email = contato.Email;
                contatoAtualizar.Endereco = contato.Endereco;
            }
            return Task.CompletedTask;
        }

        public Task AtualizarContatoAsync(Contato contato)
        {
            var contatoAtualizar = _contatos.FirstOrDefault(c => c.Id == contato.Id);
            if (contatoAtualizar != null)
            {
                contatoAtualizar.Nome = contato.Nome;
                contatoAtualizar.Fone = contato.Fone;
                contatoAtualizar.Email = contato.Email;
                contatoAtualizar.Endereco = contato.Endereco;
            }
            return Task.CompletedTask;
        }

        public Task<Contato> BuscarContatoPorId(Guid id)
        {
            var contato = _contatos.FirstOrDefault(c => c.Id == id);
            return contato != null ? Task.FromResult(contato) : Task.FromResult(new Contato());
        }

        public Task<List<Contato>> BuscarContatos(string filtro)
        {
            if(string.IsNullOrWhiteSpace(filtro))
            {
                return Task.FromResult(_contatos);
            }
            var contatosPorNome = _contatos.Where(x => !string.IsNullOrWhiteSpace(x.Nome) && x.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            var contatosPorFone = _contatos.Where(x => !string.IsNullOrWhiteSpace(x.Fone) && x.Fone.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            var contatosPorEmail = _contatos.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            var contatosPorEndereco = _contatos.Where(x => !string.IsNullOrWhiteSpace(x.Endereco) && x.Endereco.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
                        
            return Task.FromResult(contatosPorNome.Union(contatosPorFone).Union(contatosPorEmail).Union(contatosPorEndereco).ToList());
        }

        public Task<List<Contato>> BuscarTodosContatos()
        {
            return Task.FromResult(_contatos);
        }

        public Task ExcluirContato(Contato contato)
        {
            if(contato != null && contato.Id != Guid.Empty)
            {
               _contatos.Remove(contato);
               return Task.CompletedTask;
            }
            else
            {
                return Task.FromException(new ArgumentException("Contato não encontrado"));
            }
        }

        public Task ExcluirContatoAsync(Contato contato)
        {
            if (contato != null && contato.Id != Guid.Empty)
            {
                _contatos.Remove(contato);
                return Task.CompletedTask;
            }
            else
            {
                return Task.FromException(new ArgumentException("Contato não encontrado"));
            }
        }
    }
}
