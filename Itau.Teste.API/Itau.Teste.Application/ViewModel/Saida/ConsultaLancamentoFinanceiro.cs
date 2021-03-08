using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Itau.Teste.Application.ViewModel.Saida
{
    public class ConsultaLancamentoFinanceiro
    {
        [Required(ErrorMessage = "Id do lançamento é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data e Hora do lançamento é obrigatório.")]
        public DateTime DataHoraLancamento { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Range(1, 2, ErrorMessage = "Tipo de lançamento inválido")]
        public TipoLancamentoFinanceiro Tipo { get; set; }

        [Required(ErrorMessage = "Status da conciliação é obrigatório.")]
        public bool Conciliado { get; set; }

        public void DeLancamentoFinanceiro(LancamentoFinanceiro lancamento)
        {
            this.Id = lancamento.Id;
            this.DataHoraLancamento = lancamento.DataHoraLancamento;
            this.Valor = lancamento.Valor;
            this.Tipo = lancamento.Tipo;
            this.Conciliado = lancamento.Conciliado;
        }
    }
}
