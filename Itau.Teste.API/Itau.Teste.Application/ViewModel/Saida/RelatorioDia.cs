using Itau.Teste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itau.Teste.Application.ViewModel.Saida
{
    public class RelatorioDia
    {
        public DateTime DiaReferencia { get; set; }
        public List<ConsultaLancamentoFinanceiro> Lancamentos {get; set;}
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal Saldo { get; set; }


        public RelatorioDia(DateTime dia, List<ConsultaLancamentoFinanceiro> lancamentos)
        {
            this.DiaReferencia = dia;
            this.Lancamentos = lancamentos.Where(l => l.DataHoraLancamento.Date == this.DiaReferencia.Date).ToList();

            this.TotalCredito = this.Lancamentos
                .Where(l => l.Tipo == TipoLancamentoFinanceiro.Credito)
                .Aggregate(0, (decimal total, ConsultaLancamentoFinanceiro corrente) => 
                    total += corrente.Valor,
                    soma => soma
                    );


            this.TotalDebito = this.Lancamentos
                .Where(l => l.Tipo == TipoLancamentoFinanceiro.Debito)
                .Aggregate(0, (decimal total, ConsultaLancamentoFinanceiro corrente) =>
                    total += corrente.Valor,
                    soma => soma
                    );

            this.Saldo = this.TotalCredito - this.TotalDebito;
        }
    }
}
