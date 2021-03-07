using Itau.Teste.Infra.Data.Context;
using Itau.Teste.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Itau.Teste.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string connString = Configuration.GetConnectionString("Connection");

            services.AddEntityFrameworkMySql()
                .AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseMySql(connString,
                        new MySqlServerVersion(new Version(5, 7, 10)),
                        sqlOpt =>
                    {
                        sqlOpt.MigrationsAssembly("Itau.Teste.Infra.Data");
                        sqlOpt.EnableRetryOnFailure(
                            maxRetryCount: 4,
                            maxRetryDelay: TimeSpan.FromMilliseconds(2000),
                            errorNumbersToAdd: null
                            );
                    }
                    );

                });

            RegisterServices(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Itau.Teste.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Itau.Teste.API v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Itau.Teste.API v1"));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {

                var context = scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.Migrate();
            }

            app.UseRouting();

            app.UseCors(opt =>
            {
                opt.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
