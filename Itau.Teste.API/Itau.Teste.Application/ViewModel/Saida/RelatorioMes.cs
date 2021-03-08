using System;
using System.Collections.Generic;
using System.Linq;

namespace Itau.Teste.Application.ViewModel.Saida
{
    public class RelatorioMes
    {
        public DateTime MesReferencia { get; set; }
        public List<RelatorioDia> LancamentosDia { get; set; }
        public decimal TotalCredito { get; set; }
        public decimal TotalDebito { get; set; }
        public decimal Saldo { get; set; }


        public RelatorioMes(DateTime mesReferencia, List<RelatorioDia> relatorioDias)
        {
            this.MesReferencia = mesReferencia;
            this.LancamentosDia = relatorioDias.Where(l => l.DiaReferencia.Year == mesReferencia.Year &&
                                                           l.DiaReferencia.Month == mesReferencia.Month).ToList();



            this.TotalCredito = this.LancamentosDia.Aggregate(0, 
                                                            (decimal total, RelatorioDia corrente) =>
                    total += corrente.TotalCredito,
                    soma => soma
                    );

            this.TotalDebito = this.LancamentosDia.Aggregate(0,
                                                            (decimal total, RelatorioDia corrente) =>
                    total += corrente.TotalDebito,
                    soma => soma
                    );
     
            this.Saldo = this.TotalCredito - this.TotalDebito;
        }
    }
}
