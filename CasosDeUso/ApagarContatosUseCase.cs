using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso
{
    public class ApagarContatosUseCase : IApagarContatoUseCase
    {
        private readonly IRepositorioDeContatos _contatoRepository;

        public ApagarContatosUseCase(IRepositorioDeContatos repositorioDeContatos)
        {
            _contatoRepository = repositorioDeContatos;
        }

        public async Task ExecutaAsync(Contato contato)
        {
            await _contatoRepository.ExcluirContatoAsync(contato);
        }
    }
}
