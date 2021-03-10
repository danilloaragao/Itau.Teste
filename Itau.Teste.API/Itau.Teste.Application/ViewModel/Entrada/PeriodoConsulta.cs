using Itau.Teste.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Itau.Teste.Application.ViewModel.Entrada
{
    public class PeriodoConsulta
    {
        public PeriodoConsulta(DateTime inicio, DateTime fim)
        {
            List<String> errors = new();

            if (inicio == new DateTime())
                errors.Add("Data de início da consulta é obrigatório");

            if (fim == new DateTime())
                errors.Add("Data final da consulta é obrigatório");

            if (errors.Count > 0)
                throw new DatasConsultaException(String.Join(" - ", errors));

            this.Inicio = new DateTime(inicio.Year, inicio.Month, inicio.Day, 0,0,0);
            this.Fim = new DateTime(fim.Year, fim.Month, fim.Day, 23, 59, 59);

            if (this.Inicio > this.Fim)
            {
                throw new DatasConsultaException("Data de início da pesquisa deve ser anterior à data de fim da pesquisa");
            }
        }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new();
            if (this.Inicio > this.Fim)
            {
                errors.Add(new ValidationResult($"Data de início da pesquisa deve ser anterior à data de fim da pesquisa"));
            }
            return errors;
        }
    }
}
