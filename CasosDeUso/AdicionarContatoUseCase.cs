using CasosDeUso.Interface;
using CoreBusiness.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso
{
    
    public class AdicionarContatoUseCase : IAdicionarContatoUseCase
    {
        private readonly IAdicionarContatoUseCase _adicionarContatoUseCase;

        public AdicionarContatoUseCase(IAdicionarContatoUseCase adicionarContatoUseCase)
        {
            _adicionarContatoUseCase = adicionarContatoUseCase;
        }

        public async Task ExecutaAsync(Contato contato)
        {
            await _adicionarContatoUseCase.ExecutaAsync(contato);
        }
    }
}
