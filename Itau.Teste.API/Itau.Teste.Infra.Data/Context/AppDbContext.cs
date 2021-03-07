using Itau.Teste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Itau.Teste.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LancamentoFinanceiro> LancamentoFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancamentoFinanceiro>(entity =>
            {
                entity.ToTable("teste_itau.LANCAMENTOS_FINANCEIROS");

                entity.HasKey(e => e.Id)
                    .HasName("ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int");

                entity.Property(e => e.DataHoraLancamento)
                    .HasColumnName("DATA_HORA_LANCAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasPrecision(10, 2)
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasColumnType("int");

                entity.Property(e => e.Conciliado)
                    .HasColumnName("CONCILIADO")
                    .HasColumnType("tinyint(1)");
            }).Entity<LancamentoFinanceiro>().Property(l => l.Id).ValueGeneratedOnAdd();
        }
    }
}
