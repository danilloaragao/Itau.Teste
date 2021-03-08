using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using Itau.Teste.Domain.Entities;
using System;
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

        public RelatorioMes RelatorioMensal(DateTime mesReferencia)
        {
            List<ConsultaLancamentoFinanceiro> lancamentosMes = ConsultaLancamentoFinanceiro(
                new PeriodoConsulta(new DateTime(mesReferencia.Year, mesReferencia.Month, 1),
                                    new DateTime(mesReferencia.Year, mesReferencia.Month, DateTime.DaysInMonth(mesReferencia.Year, mesReferencia.Month))
                                    )
                ).ToList();

            List<DateTime> diasComLancamentos = lancamentosMes.Select(l => l.DataHoraLancamento.Date).Distinct().ToList();

            List<RelatorioDia> relatorioDias = new List<RelatorioDia>();

            foreach (DateTime dia in diasComLancamentos)
            {
                RelatorioDia relatorioDia = new RelatorioDia(dia, lancamentosMes);
                relatorioDias.Add(relatorioDia);
            }

            RelatorioMes relatorioMes = new RelatorioMes(mesReferencia.Date, relatorioDias);

            return relatorioMes;
        }
    }
}
