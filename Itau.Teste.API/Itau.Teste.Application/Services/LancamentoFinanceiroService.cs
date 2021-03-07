using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel;
using Itau.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.Teste.Application.Services
{
    public class LancamentoFinanceiroService : ILancamentosFinanceirosService
    {
        public ILancamentosFinanceirosRepository _lancamentosFinanceirosRepository;
        
        public LancamentoFinanceiroService(ILancamentosFinanceirosRepository lancamentosFinanceirosRepository)
        {
            this._lancamentosFinanceirosRepository = lancamentosFinanceirosRepository;
        }

        public void CadastroLancamentoFinanceiro(CadastroLancamentoFinanceiro lancamentoFinanceiro)
        {

            this._lancamentosFinanceirosRepository.CadastroLancamentoFinanceiro(lancamentoFinanceiro.ParaLancamentoFinanceiro());
        }
    }
}
