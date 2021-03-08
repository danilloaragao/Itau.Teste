using System;
using System.Collections.Generic;

namespace Itau.Teste.Domain.Entities
{
    public interface ILancamentosFinanceirosRepository
    {
        void CadastroLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro);
        void AtualizacaoLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro);
        void ExclusaoLancamentoFinanceiro(int id);

        IEnumerable<LancamentoFinanceiro> ConsultaLancamentoFinanceiro(DateTime inicio, DateTime fim);
    }
}
