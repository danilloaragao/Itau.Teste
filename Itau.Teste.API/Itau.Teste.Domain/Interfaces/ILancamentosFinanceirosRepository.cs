namespace Itau.Teste.Domain.Entities
{
    public interface ILancamentosFinanceirosRepository
    {
        void CadastroLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro);
        void AtualizacaoLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro);
    }
}
