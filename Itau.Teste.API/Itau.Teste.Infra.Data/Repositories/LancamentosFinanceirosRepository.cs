using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Exceptions;
using Itau.Teste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itau.Teste.Infra.Data.Repositories
{
    public class LancamentosFinanceirosRepository : ILancamentosFinanceirosRepository
    {
        private readonly AppDbContext _context;

        public LancamentosFinanceirosRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void ExclusaoLancamentoFinanceiro(int id)
        {
            LancamentoFinanceiro lancamento = this._context.LancamentoFinanceiros.FirstOrDefault(l => l.Id == id);

            if (lancamento == null)
                throw new LancamentoNaoEncontradoException("Lancamento não encontrado");

            if (lancamento.Conciliado)
                throw new LancamentoConciliadoException("Exclusão não permitida - Lançamento já conciliado");

            this._context.LancamentoFinanceiros.Remove(lancamento);
            this._context.SaveChanges();
        }

        public void AtualizacaoLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro)
        {
            LancamentoFinanceiro lancamento = this._context.LancamentoFinanceiros.FirstOrDefault(l => l.Id == lancamentoFinanceiro.Id);

            if (lancamento == null)
                throw new LancamentoNaoEncontradoException("Lancamento não encontrado");

            if (lancamento.Conciliado)
                throw new LancamentoConciliadoException("Atualização não permitida - Lançamento já conciliado");

            this._context.Update(lancamentoFinanceiro);
            this._context.SaveChanges();
        }

        public void CadastroLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro)
        {
            this._context.Add(lancamentoFinanceiro);
            this._context.SaveChanges();
        }

        public IEnumerable<LancamentoFinanceiro> ConsultaLancamentoFinanceiro(DateTime inicio, DateTime fim)
        {
            List<LancamentoFinanceiro> retorno = new();

            retorno = this._context.LancamentoFinanceiros.Where(l => l.DataHoraLancamento >= inicio && l.DataHoraLancamento <= fim).ToList();
            return retorno;
        }
    }
}
