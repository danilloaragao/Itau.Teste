using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Itau.Teste.Application.ViewModel.Entrada
{
    public class CadastroLancamentoFinanceiro
    {
        [Required(ErrorMessage = "Data e Hora do lançamento é obrigatório.")]
        public DateTime DataHoraLancamento { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Range(1, 2, ErrorMessage = "Tipo de lançamento inválido")]
        public TipoLancamentoFinanceiro Tipo { get; set; }

        public LancamentoFinanceiro ParaLancamentoFinanceiro()
        {
            return new LancamentoFinanceiro
            {
                DataHoraLancamento = this.DataHoraLancamento,
                Valor = this.Valor,
                Tipo = this.Tipo,
                Conciliado = false
            };
        }
    }
}
