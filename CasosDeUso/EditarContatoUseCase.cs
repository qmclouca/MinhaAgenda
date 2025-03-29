using CasosDeUso.Interface;
using CasosDeUso.PluginsInterfaces;
using CoreBusiness.Entidades;

namespace CasosDeUso
{
    public class EditarContatoUseCase : IEditarContatoUseCase
    {
        private readonly IRepositorioDeContatos _contatoRepository;

        public EditarContatoUseCase(IRepositorioDeContatos contatosRepository)
        {
            _contatoRepository = contatosRepository;
        }

        public async Task ExecutaAsync(Contato contato)
        {
            Contato contatoParaAtualizar = await _contatoRepository.BuscarContatoPorId(contato.Id);
            if (contatoParaAtualizar == null)
            {
                return;                
            }
            Contato novoContato = new Contato
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email,
                Fone = contato.Fone
            };

            await _contatoRepository.AtualizarContato(novoContato);
        }
    }
}
