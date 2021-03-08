using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using Itau.Teste.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ConsultaLancamentoFinanceiro> ConsultaLancamentoFinanceiro(PeriodoConsulta periodo)
        {
            List<ConsultaLancamentoFinanceiro> retorno = new();
            List<LancamentoFinanceiro> consulta = this._lancamentosFinanceirosRepository.ConsultaLancamentoFinanceiro(periodo.Inicio, periodo.Fim).ToList();

            foreach (LancamentoFinanceiro lancamentoFinanceiro in consulta)
            {
                ConsultaLancamentoFinanceiro lancamentoConsulta = new();
                lancamentoConsulta.DeLancamentoFinanceiro(lancamentoFinanceiro);
                retorno.Add(lancamentoConsulta);
            }

            return retorno;
        }

        public void ExclusaoLancamentoFinanceiro(int id)
        {
            this._lancamentosFinanceirosRepository.ExclusaoLancamentoFinanceiro(id);
        }
    }
}
