using Itau.Teste.Application.Interfaces;
using Itau.Teste.Application.Services;
using Itau.Teste.Domain.Entities;
using Itau.Teste.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Itau.Teste.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILancamentosFinanceirosService, LancamentoFinanceiroService>();
            services.AddScoped<ILancamentosFinanceirosRepository, LancamentosFinanceirosRepository>();
        }
    }
}
