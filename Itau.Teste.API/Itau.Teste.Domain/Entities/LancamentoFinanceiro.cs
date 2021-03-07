using Itau.Teste.Domain.Enums;
using System;

namespace Itau.Teste.Domain.Entities
{
    public class LancamentoFinanceiro
    {
        public int Id { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamentoFinanceiro Tipo { get; set; }
        public bool Conciliado { get; set; }

    }
}
