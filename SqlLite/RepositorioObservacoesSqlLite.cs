using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;
using SQLite;

namespace SqlLite
{
    public class RepositorioObservacoesSqlLite : IRepositorioDeObservacoes
    {
        private readonly SQLiteAsyncConnection _conexao;
        public RepositorioObservacoesSqlLite(SQLiteAsyncConnection conexao)
        {
            _conexao = conexao;
        }
        public Task AdicionarAsync(Observacoes observacao)
        {
            return _conexao.InsertAsync(observacao);
        }
        public Task<List<Observacoes>> ListarPorContatoAsync(int contatoId)
        {
            return _conexao.Table<Observacoes>().Where(x => x.ContatoId == contatoId).ToListAsync();
        }
    }
}
