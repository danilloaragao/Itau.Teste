using Itau.Teste.Domain.Entities;
using Itau.Teste.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itau.Teste.Infra.Data.Repositories
{
    public class LancamentosFinanceirosRepository : ILancamentosFinanceirosRepository
    {
        private AppDbContext _context;

        public LancamentosFinanceirosRepository(AppDbContext context)
        {
            this._context = context;
        }

        public void CadastroLancamentoFinanceiro(LancamentoFinanceiro lancamentoFinanceiro)
        {
            this._context.Add(lancamentoFinanceiro);
            this._context.SaveChanges();
        }
    }
}
