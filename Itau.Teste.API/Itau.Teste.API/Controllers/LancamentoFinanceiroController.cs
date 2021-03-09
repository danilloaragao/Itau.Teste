using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using Itau.Teste.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Itau.Teste.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoFinanceiroController : Controller
    {
        private readonly ILancamentosFinanceirosService _lancamentosFinanceirosService;

        public LancamentoFinanceiroController(ILancamentosFinanceirosService lancamentosFinanceirosService)
        {
            this._lancamentosFinanceirosService = lancamentosFinanceirosService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult Inserir(CadastroLancamentoFinanceiro cadastroLancamento)
        {
            try
            {
                this._lancamentosFinanceirosService.CadastroLancamentoFinanceiro(cadastroLancamento);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult Atualizar(AtualizacaoLancamentoFinanceiro atualizaçãoLancamento)
        {
            try
            {
                this._lancamentosFinanceirosService.AtualizacaoLancamentoFinanceiro(atualizaçãoLancamento);
                return StatusCode(204);
            }
            catch (LancamentoNaoEncontradoException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (LancamentoConciliadoException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/LancamentoFinanceiro/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult Deletar([FromRoute] int id)
        {
            try
            {
                this._lancamentosFinanceirosService.ExclusaoLancamentoFinanceiro(id);
                return StatusCode(204);
            }
            catch (LancamentoNaoEncontradoException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (LancamentoConciliadoException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/LancamentoFinanceiro/{dataInicio}/{dataFim}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultaLancamentoFinanceiro>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult ConsultarPeriodo([FromRoute] DateTime dataInicio, [FromRoute] DateTime dataFim)
        {
            try
            {
                return StatusCode(200, 
                    this._lancamentosFinanceirosService.ConsultaLancamentoFinanceiro(
                        new PeriodoConsulta(dataInicio,dataFim)));
            }
            catch(DatasConsultaException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/LancamentoFinanceiro/{data}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultaLancamentoFinanceiro>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult ConsultarDia([FromRoute] DateTime data)
        {
            return ConsultarPeriodo(data, data);
        }

        [HttpGet("/LancamentoFinanceiro/Relatorio/{mesReferencia}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RelatorioMes))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public ActionResult Relatorio(DateTime mesReferencia)
        {
            try
            {
                return StatusCode(200,
                    this._lancamentosFinanceirosService.RelatorioMensal(mesReferencia));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
