using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{

    public class AdicionarContatoUseCase : IAdicionarContatoUseCase
    {
        private readonly IRepositorioDeContatos _contatoRepository;

        public AdicionarContatoUseCase(IRepositorioDeContatos contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task ExecutaAsync(Contato contato)
        {
            await _contatoRepository.AdicionarContato(contato);
        }
    }
}
