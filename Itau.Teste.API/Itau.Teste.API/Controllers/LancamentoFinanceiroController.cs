using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel;
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
        public ActionResult Create(CadastroLancamentoFinanceiro cadastroLancamento)
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
        public ActionResult Update(AtualizacaoLancamentoFinanceiro atualizaçãoLancamento)
        {
            try
            {
                this._lancamentosFinanceirosService.AtualizacaoLancamentoFinanceiro(atualizaçãoLancamento);
                return StatusCode(204);
            }
            catch(LancamentoNaoEncontradoException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch(LancamentoConciliadoException ex)
            {
                return StatusCode(403, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("/:id")]
        public ActionResult Delete(int id)
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


    }
}
