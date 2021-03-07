using Itau.Teste.Application.ViewModel;

namespace Itau.Teste.Application.Interfaces
{
    public interface ILancamentosFinanceirosService
    {
        void CadastroLancamentoFinanceiro(CadastroLancamentoFinanceiro cadastroancamentoFinanceiro);
        void AtualizacaoLancamentoFinanceiro(AtualizacaoLancamentoFinanceiro atualizacaoLancamentoFinanceiro);
    }
}
