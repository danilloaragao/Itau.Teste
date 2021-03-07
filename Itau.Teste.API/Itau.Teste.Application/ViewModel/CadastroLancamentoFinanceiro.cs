using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itau.Teste.Application.ViewModel
{
    public class CadastroLancamentoFinanceiro //: IValidatableObject
    {
        [Required(ErrorMessage = "Data e Hora do lançamento é obrigatório.")]
        public DateTime DataHoraLancamento { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Range(1, 2, ErrorMessage = "Tipo de lançamento inválido")]
        public TipoLancamentoFinanceiro Tipo { get; set; }

        public LancamentoFinanceiro ParaLancamentoFinanceiro()
        {
            //if(this.Validate(new ValidationContext(this, null, null)).)
            return new LancamentoFinanceiro
            {
                DataHoraLancamento = this.DataHoraLancamento,
                Valor = this.Valor,
                Tipo = this.Tipo,
                Conciliado = false
            };
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var results = new List<ValidationResult>();
        //    Validator.TryValidateProperty(this.DataHoraLancamento,new ValidationContext(this, null, null) { MemberName = "DataHoraLancamento" }, results);
        //    Validator.TryValidateProperty(this.Valor, new ValidationContext(this, null, null) { MemberName = "Valor" }, results);
        //    Validator.TryValidateProperty(this.Tipo, new ValidationContext(this, null, null) { MemberName = "Tipo" }, results);
        //    return results;
        //}
    }
}
