using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Enums;
using Itau.Teste.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itau.Teste.TestesUnitarios.Services
{
    public class LancamentosFinanceirosServiceFake : ILancamentosFinanceirosService
    {
        private List<LancamentoFinanceiro> _lancamentoFinanceiros = new()
        {
            new LancamentoFinanceiro
            {
                Id = 1,
                DataHoraLancamento = new DateTime(2021, 3, 1, 12, 4, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 3000
            },
            new LancamentoFinanceiro
            {
                Id = 2,
                DataHoraLancamento = new DateTime(2021, 3, 1, 13, 3, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 100
            },
            new LancamentoFinanceiro
            {
                Id = 3,
                DataHoraLancamento = new DateTime(2021, 3, 1, 14, 2, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 55
            },
            new LancamentoFinanceiro
            {
                Id = 4,
                DataHoraLancamento = new DateTime(2021, 3, 2, 14, 3, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 72
            },
            new LancamentoFinanceiro
            {
                Id = 5,
                DataHoraLancamento = new DateTime(2021, 3, 2, 14, 47, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 153
            },
            new LancamentoFinanceiro
            {
                Id = 6,
                DataHoraLancamento = new DateTime(2021, 3, 3, 15, 43, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 342
            },
            new LancamentoFinanceiro
            {
                Id = 7,
                DataHoraLancamento = new DateTime(2021, 3, 3, 15, 32, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 75
            },
            new LancamentoFinanceiro
            {
                Id = 8,
                DataHoraLancamento = new DateTime(2021, 3, 3, 16, 57, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 145
            },
            new LancamentoFinanceiro
            {
                Id = 9,
                DataHoraLancamento = new DateTime(2021, 3, 3, 17, 34, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 234
            },
            new LancamentoFinanceiro
            {
                Id = 10,
                DataHoraLancamento = new DateTime(2021, 3, 4, 17, 41, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 876
            },
            new LancamentoFinanceiro
            {
                Id = 11,
                DataHoraLancamento = new DateTime(2021, 4, 4, 18, 35, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 234
            },
            new LancamentoFinanceiro
            {
                Id = 12,
                DataHoraLancamento = new DateTime(2021, 4, 4, 11, 24, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 56
            },
            new LancamentoFinanceiro
            {
                Id = 13,
                DataHoraLancamento = new DateTime(2021, 4, 4, 11, 21, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 213
            }
        };

        public void AtualizacaoLancamentoFinanceiro(AtualizacaoLancamentoFinanceiro atualizacaoLancamentoFinanceiro)
        {
            LancamentoFinanceiro lancamento = this._lancamentoFinanceiros.FirstOrDefault(l => l.Id == atualizacaoLancamentoFinanceiro.Id);

            if (lancamento == null)
                throw new LancamentoNaoEncontradoException("Lancamento não encontrado");

            if (lancamento.Conciliado)
                throw new LancamentoConciliadoException("Atualização não permitida - Lançamento já conciliado");
        }

        public string AtualizacaoLancamentoFinanceiroLote(List<AtualizacaoLancamentoFinanceiro> atualizacoesLancamentoFinanceiro)
        {
            int falhas = 0;

            foreach (AtualizacaoLancamentoFinanceiro lancamento in atualizacoesLancamentoFinanceiro)
            {
                try
                {
                    AtualizacaoLancamentoFinanceiro(lancamento);
                }
                catch
                {
                    falhas++;
                }
            }
            return $"{atualizacoesLancamentoFinanceiro.Count - falhas} de {atualizacoesLancamentoFinanceiro.Count} lançamentos atualizados";
        }

        public void CadastroLancamentoFinanceiro(CadastroLancamentoFinanceiro cadastroancamentoFinanceiro)
        {
            
        }

        public IEnumerable<ConsultaLancamentoFinanceiro> ConsultaLancamentoFinanceiro(PeriodoConsulta periodo)
        {
            List<LancamentoFinanceiro> retorno = new();

            retorno = this._lancamentoFinanceiros.Where(l => l.DataHoraLancamento >= periodo.Inicio && l.DataHoraLancamento <= periodo.Fim).OrderBy(l => l.DataHoraLancamento).ToList();
            return (IEnumerable<ConsultaLancamentoFinanceiro>)retorno; 
        }

        public void ExclusaoLancamentoFinanceiro(int id)
        {
            LancamentoFinanceiro lancamento = this._lancamentoFinanceiros.FirstOrDefault(l => l.Id == id);

            if (lancamento == null)
                throw new LancamentoNaoEncontradoException("Lancamento não encontrado");

            if (lancamento.Conciliado)
                throw new LancamentoConciliadoException("Exclusão não permitida - Lançamento já conciliado");
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
