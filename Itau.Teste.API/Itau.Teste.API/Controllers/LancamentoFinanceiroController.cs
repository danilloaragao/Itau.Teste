using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itau.Teste.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoFinanceiroController : Controller
    {
        private ILancamentosFinanceirosService _lancamentosFinanceirosService;

        public LancamentoFinanceiroController(ILancamentosFinanceirosService lancamentosFinanceirosService)
        {
            this._lancamentosFinanceirosService = lancamentosFinanceirosService;
        }

        [HttpPost]
        public ActionResult Create(CadastroLancamentoFinanceiro cadastroLancamento )
        {
            try
            {
                this._lancamentosFinanceirosService.CadastroLancamentoFinanceiro(cadastroLancamento);
                return StatusCode(204);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //// GET: LancamentoFinancaeiroController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: LancamentoFinancaeiroController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: LancamentoFinancaeiroController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: LancamentoFinancaeiroController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
