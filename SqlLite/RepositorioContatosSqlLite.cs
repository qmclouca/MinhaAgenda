using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;
using SQLite;

namespace MinhaAgenda.Plugins.SqlLite
{
    public class RepositorioContatosSqlLite : IRepositorioDeContatos
    {
        private SQLiteAsyncConnection _database;

        public RepositorioContatosSqlLite()
        {
            _database = new SQLiteAsyncConnection(Constantes._databasepath);
            _database.CreateTableAsync<Contato>().Wait();
        }

        public Task AdicionarContato(Contato contato)
        {
            return Task.FromResult(AdicionarContatoAsync(contato));
        }

        public async Task AdicionarContatoAsync(Contato contato)
        {
            await _database.InsertAsync(contato);
        }

        public Task AtualizarContato(Contato contato)
        {
            return Task.FromResult(AtualizarContatoAsync(contato));
        }

        public async Task AtualizarContatoAsync(Contato contato)
        {
           var colunasAfetadas = await _database.UpdateAsync(contato);
            if (colunasAfetadas <= 0)
                throw new InvalidOperationException("Erro ao atualizar contato");
        }
        
        public Task<Contato> BuscarContatoPorId(Guid id)
        {
           return BuscarContatoPorIdAsync(id);
        }

        public async Task<Contato> BuscarContatoPorIdAsync(Guid id)
        {
           return await _database.Table<Contato>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public Task<List<Contato>> BuscarContatos(string filtro)
        {
            return BuscarContatosAsync(filtro);
        }

        public async Task<List<Contato>> BuscarContatosAsync(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return await _database.Table<Contato>().ToListAsync();

            return await this._database.QueryAsync<Contato>
                (
                    @"
                    SELECT * FROM Contato
                    WHERE 
                        Nome LIKE ? OR 
                        Fone LIKE ? OR 
                        Email LIKE ? OR 
                        Endereco LIKE ?",
                        $"{filtro}%",
                        $"{filtro}%",
                        $"{filtro}%",
                        $"{filtro}%"
                );
        }

        public Task<List<Contato>> BuscarTodosContatos()
        {
            return BuscarTodosContatosAsync();
        }

        public async Task<List<Contato>> BuscarTodosContatosAsync()
        {
            return await _database.Table<Contato>().ToListAsync();
        }

        public Task ExcluirContato(Contato contato)
        {
            return Task.FromResult(ExcluirContatoAsync(contato));
        }

        public async Task ExcluirContatoAsync(Contato contato)
        {
            var contatoExcluir = await BuscarContatoPorIdAsync(contato.Id);
            if (contatoExcluir != null && contato.Id.Equals(contatoExcluir.Id))
                await _database.DeleteAsync(contatoExcluir);            
        }
    }
}
