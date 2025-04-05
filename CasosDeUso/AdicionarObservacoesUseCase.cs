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
    public class AdicionarObservacoesUseCase : IAdicionarObservacoesUseCase
    {
        private readonly IRepositorioDeObservacoes _repositorioDeObservacoes;

        public AdicionarObservacoesUseCase(IRepositorioDeObservacoes repositorioDeObservacoes)
        {
            _repositorioDeObservacoes = repositorioDeObservacoes;
        }
        public async Task ExecutarAsync(Observacoes observacao)
        {
            await _repositorioDeObservacoes.AdicionarAsync(observacao);
        }
    }
}