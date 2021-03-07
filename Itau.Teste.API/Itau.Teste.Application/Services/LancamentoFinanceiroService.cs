using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel;
using Itau.Teste.Domain.Entities;

namespace Itau.Teste.Application.Services
{
    public class LancamentoFinanceiroService : ILancamentosFinanceirosService
    {
        public ILancamentosFinanceirosRepository _lancamentosFinanceirosRepository;
        
        public LancamentoFinanceiroService(ILancamentosFinanceirosRepository lancamentosFinanceirosRepository)
        {
            this._lancamentosFinanceirosRepository = lancamentosFinanceirosRepository;
        }

        public void AtualizacaoLancamentoFinanceiro(AtualizacaoLancamentoFinanceiro atualizacaoLancamentoFinanceiro)
        {
            this._lancamentosFinanceirosRepository.AtualizacaoLancamentoFinanceiro(atualizacaoLancamentoFinanceiro.ParaLancamentoFinanceiro());
        }

        public void CadastroLancamentoFinanceiro(CadastroLancamentoFinanceiro lancamentoFinanceiro)
        {

            this._lancamentosFinanceirosRepository.CadastroLancamentoFinanceiro(lancamentoFinanceiro.ParaLancamentoFinanceiro());
        }
    }
}
