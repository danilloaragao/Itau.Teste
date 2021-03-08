using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpDelete("/:id")]
        public ActionResult Deletar(int id)
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

        [HttpGet("/:dataInicio/:dataFim")]
        public ActionResult Consultar(DateTime dataInicio, DateTime dataFim)
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

        [HttpGet("relatorio/:mesReferencia")]
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
