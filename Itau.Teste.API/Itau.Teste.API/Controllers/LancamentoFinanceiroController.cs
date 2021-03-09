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
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult Inserir(CadastroLancamentoFinanceiro cadastroLancamento)
        {
            try
            {
                this._lancamentosFinanceirosService.CadastroLancamentoFinanceiro(cadastroLancamento);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespostaString(ex.Message));
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult Atualizar(AtualizacaoLancamentoFinanceiro atualizacaoLancamento)
        {
            try
            {
                this._lancamentosFinanceirosService.AtualizacaoLancamentoFinanceiro(atualizacaoLancamento);
                return StatusCode(204);
            }
            catch (LancamentoNaoEncontradoException ex)
            {
                return StatusCode(422, new RespostaString(ex.Message));
            }
            catch (LancamentoConciliadoException ex)
            {
                return StatusCode(403, new RespostaString(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespostaString(ex.Message));
            }
        }

        [HttpPut("/LancamentoFinanceiro/Lote")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespostaString))]
        public ActionResult AtualizarLote(List<AtualizacaoLancamentoFinanceiro> atualizacoesLancamento)
        {
            return StatusCode(200, new RespostaString(this._lancamentosFinanceirosService.AtualizacaoLancamentoFinanceiroLote(atualizacoesLancamento)));
        }

        [HttpDelete("/LancamentoFinanceiro/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult Deletar([FromRoute] int id)
        {
            try
            {
                this._lancamentosFinanceirosService.ExclusaoLancamentoFinanceiro(id);
                return StatusCode(204);
            }
            catch (LancamentoNaoEncontradoException ex)
            {
                return StatusCode(422, new RespostaString(ex.Message));
            }
            catch (LancamentoConciliadoException ex)
            {
                return StatusCode(403, new RespostaString(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespostaString(ex.Message));
            }
        }

        [HttpGet("/LancamentoFinanceiro/{dataInicio}/{dataFim}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultaLancamentoFinanceiro>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult ConsultarPeriodo([FromRoute] DateTime dataInicio, [FromRoute] DateTime dataFim)
        {
            try
            {
                return StatusCode(200,
                    this._lancamentosFinanceirosService.ConsultaLancamentoFinanceiro(
                        new PeriodoConsulta(dataInicio, dataFim)));
            }
            catch (DatasConsultaException ex)
            {
                return StatusCode(400, new RespostaString(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespostaString(ex.Message));
            }
        }

        [HttpGet("/LancamentoFinanceiro/{data}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ConsultaLancamentoFinanceiro>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespostaString))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult ConsultarDia([FromRoute] DateTime data)
        {
            return ConsultarPeriodo(data, data);
        }

        [HttpGet("/LancamentoFinanceiro/Relatorio/{mesReferencia}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RelatorioMes))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RespostaString))]
        public ActionResult Relatorio(DateTime mesReferencia)
        {
            try
            {
                return StatusCode(200,
                    this._lancamentosFinanceirosService.RelatorioMensal(mesReferencia));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespostaString(ex.Message));
            }
        }
    }
}
