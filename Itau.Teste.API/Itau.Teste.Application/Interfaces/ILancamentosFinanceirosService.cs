using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using System;
using System.Collections.Generic;

namespace Itau.Teste.Application.Interfaces
{
    public interface ILancamentosFinanceirosService
    {
        void CadastroLancamentoFinanceiro(CadastroLancamentoFinanceiro cadastroancamentoFinanceiro);
        void AtualizacaoLancamentoFinanceiro(AtualizacaoLancamentoFinanceiro atualizacaoLancamentoFinanceiro);
        string AtualizacaoLancamentoFinanceiroLote(List<AtualizacaoLancamentoFinanceiro> atualizacoesLancamentoFinanceiro);
        void ExclusaoLancamentoFinanceiro(int id);
        IEnumerable<ConsultaLancamentoFinanceiro> ConsultaLancamentoFinanceiro(PeriodoConsulta periodo);
        RelatorioMes RelatorioMensal(DateTime mesReferencia);
    }
}
