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
    public class VisualizarContatosUseCase : IVisualizarContatosUseCase
    {
        private readonly IRepositorioDeContatos _contatoRepository;

        public VisualizarContatosUseCase(IRepositorioDeContatos repositorioDeContatos)
        {
            _contatoRepository = repositorioDeContatos;
        }
        public async Task<Contato> ExecutaAsync(Guid contatoId)
        {
            return await _contatoRepository.BuscarContatoPorId(contatoId); ;
        }

        public async Task<List<Contato>> ExecutaListAsync(string filtro)
        {
            return await _contatoRepository.BuscarContatos(filtro);
        }
    }
}
