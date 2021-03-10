using Itau.Teste.API.Controllers;
using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.ViewModel.Entrada;
using Itau.Teste.Application.ViewModel.Saida;
using Itau.Teste.Domain.Enums;
using Itau.Teste.TestesUnitarios.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Xunit;

namespace Itau.Teste.TestesUnitarios
{
    public class LancamentoFinanceiroControllerTest
    {
        LancamentoFinanceiroController _lancamentoFinanceiroController;
        ILancamentosFinanceirosService _service;

        public LancamentoFinanceiroControllerTest()
        {
            this._service = new LancamentosFinanceirosServiceFake();
            this._lancamentoFinanceiroController = new LancamentoFinanceiroController(this._service);
        }

        [Fact]
        public void InclusaoComSucesso()
        {
            var entrada = new CadastroLancamentoFinanceiro()
            {
                DataHoraLancamento = DateTime.Now,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 10
            };

            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Inserir(entrada);
            StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(resultadoSucesso);

            Assert.Equal(204, objectResponse.StatusCode);
        }

        [Fact]
        public void AtualizacaoComSucesso()
        {
            var entrada = new AtualizacaoLancamentoFinanceiro()
            {
                Id = 6,
                DataHoraLancamento = DateTime.Now,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 10,
                Conciliado = true
            };

            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Atualizar(entrada);
            StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(resultadoSucesso);

            Assert.Equal(204, objectResponse.StatusCode);
        }

        [Fact]
        public void AtualizacaoRegistroNaoExistente()
        {
            var entrada = new AtualizacaoLancamentoFinanceiro()
            {
                Id = 600,
                DataHoraLancamento = DateTime.Now,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 10,
                Conciliado = true
            };

            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Atualizar(entrada);
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(422, objectResponse.StatusCode);
        }

        [Fact]
        public void AtualizacaoRegistroConciliado()
        {
            var entrada = new AtualizacaoLancamentoFinanceiro()
            {
                Id = 1,
                DataHoraLancamento = DateTime.Now,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 10,
                Conciliado = true
            };

            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Atualizar(entrada);
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(403, objectResponse.StatusCode);
        }

        [Fact]
        public void AtualizacaoRegistroLoteSucesso0De2()
        {
            var entrada = new List<AtualizacaoLancamentoFinanceiro>()
            {
               new AtualizacaoLancamentoFinanceiro
            {
                Id = 1,
                DataHoraLancamento = new DateTime(2021, 3, 1, 12, 4, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 30
            },
            new AtualizacaoLancamentoFinanceiro
            {
                Id = 2,
                DataHoraLancamento = new DateTime(2021, 3, 1, 13, 3, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 10
            },
            };
            var resultadoSucesso = this._lancamentoFinanceiroController.AtualizarLote(entrada);
            var result = Assert.IsType<ObjectResult>(resultadoSucesso);
            RespostaString resposta = result.Value as RespostaString;
            Assert.Equal("0 de 2 lançamentos atualizados", resposta.Mensagem);
        }


        [Fact]
        public void AtualizacaoRegistroLoteSucesso1De2()
        {
            var entrada = new List<AtualizacaoLancamentoFinanceiro>()
            {
               new AtualizacaoLancamentoFinanceiro
            {
                Id = 2,
                DataHoraLancamento = new DateTime(2021, 3, 1, 13, 3, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 100
            },
            new AtualizacaoLancamentoFinanceiro
            {
                Id = 3,
                DataHoraLancamento = new DateTime(2021, 3, 1, 14, 2, 0),
                Conciliado = false,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 55
            },
            };
            var resultadoSucesso = this._lancamentoFinanceiroController.AtualizarLote(entrada);
            var result = Assert.IsType<ObjectResult>(resultadoSucesso);
            RespostaString resposta = result.Value as RespostaString;
            Assert.Equal("1 de 2 lançamentos atualizados", resposta.Mensagem);
        }

        [Fact]
        public void AtualizacaoRegistroLoteSucesso3De3()
        {
            var entrada = new List<AtualizacaoLancamentoFinanceiro>()
            {
               new AtualizacaoLancamentoFinanceiro
            {
                Id = 5,
                DataHoraLancamento = new DateTime(2021, 3, 2, 14, 47, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 1531
            },
            new AtualizacaoLancamentoFinanceiro
            {
                Id = 6,
                DataHoraLancamento = new DateTime(2021, 3, 3, 15, 43, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 3421
            },
            new AtualizacaoLancamentoFinanceiro
            {
                Id = 7,
                DataHoraLancamento = new DateTime(2021, 3, 3, 15, 32, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Debito,
                Valor = 751
            },
            };
            var resultadoSucesso = this._lancamentoFinanceiroController.AtualizarLote(entrada);
            var result = Assert.IsType<ObjectResult>(resultadoSucesso);
            RespostaString resposta = result.Value as RespostaString;
            Assert.Equal("3 de 3 lançamentos atualizados", resposta.Mensagem);
        }


        [Fact]
        public void AtualizacaoRegistroNaoEncontrado()
        {
            var entrada = new AtualizacaoLancamentoFinanceiro()
            {
                Id = 500,
                DataHoraLancamento = DateTime.Now,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 10,
                Conciliado = false
            };
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Atualizar(entrada);
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(422, objectResponse.StatusCode);
        }

        [Fact]
        public void AtualizacaoRegistroJaConciliado()
        {
            var entrada = new AtualizacaoLancamentoFinanceiro()
            {
                Id = 1,
                DataHoraLancamento = new DateTime(2021, 3, 1, 12, 4, 0),
                Conciliado = true,
                Tipo = TipoLancamentoFinanceiro.Credito,
                Valor = 30
            };
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Atualizar(entrada);
            ObjectResult objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(403, objectResponse.StatusCode);
        }

        [Fact]
        public void ExclusaoComSucesso()
        {
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Deletar(6);
            StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(resultadoSucesso);

            Assert.Equal(204, objectResponse.StatusCode);
        }

        [Fact]
        public void ExclusaoNaoEncontrado()
        {
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Deletar(600);
            var objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(422, objectResponse.StatusCode);
        }

        [Fact]
        public void ExclusaoJaConciliado()
        {
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.Deletar(1);
            var objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);

            Assert.Equal(403, objectResponse.StatusCode);
        }

        [Fact]
        public void ConsultaPeriodoDataInicioPosteriorDataFim()
        {
            DateTime inicio = new DateTime(2021, 4, 1);
            DateTime fim = new DateTime(2021, 2, 2);
            IActionResult resultadoSucesso = this._lancamentoFinanceiroController.ConsultarPeriodo(inicio, fim);
            var objectResponse = Assert.IsType<ObjectResult>(resultadoSucesso);
            Assert.Equal(400, objectResponse.StatusCode);
        }
    }
}
