using Itau.Teste.Domain.Entities;
using Itau.Teste.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<LancamentoFinanceiro>().HasData(
                new LancamentoFinanceiro
                {
                    Id = 1,
                    DataHoraLancamento = new DateTime(2021, 3, 1, 12, 4, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 3000
                },
                new LancamentoFinanceiro
                {
                    Id = 2,
                    DataHoraLancamento = new DateTime(2021, 3, 1, 13, 3, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 100
                },
                new LancamentoFinanceiro
                {
                    Id = 3,
                    DataHoraLancamento = new DateTime(2021, 3, 1, 14, 2, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 55
                },
                new LancamentoFinanceiro
                {
                    Id = 4,
                    DataHoraLancamento = new DateTime(2021, 3, 2, 14, 3, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 72
                },
                new LancamentoFinanceiro
                {
                    Id = 5,
                    DataHoraLancamento = new DateTime(2021, 3, 2, 14, 47, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 153
                },
                new LancamentoFinanceiro
                {
                    Id = 6,
                    DataHoraLancamento = new DateTime(2021, 3, 3, 15, 43, 0),
                    Conciliado = true,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 342
                },
                new LancamentoFinanceiro
                {
                    Id = 7,
                    DataHoraLancamento = new DateTime(2021, 3, 3, 15, 32, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 75
                },
                new LancamentoFinanceiro
                {
                    Id = 8,
                    DataHoraLancamento = new DateTime(2021, 3, 3, 16, 57, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Debito,
                    Valor = 145
                },
                new LancamentoFinanceiro
                {
                    Id = 9,
                    DataHoraLancamento = new DateTime(2021, 3, 3, 17, 34, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 234
                },
                new LancamentoFinanceiro
                {
                    Id = 10,
                    DataHoraLancamento = new DateTime(2021, 3, 4, 17, 41, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 876
                },
                new LancamentoFinanceiro
                {
                    Id = 11,
                    DataHoraLancamento = new DateTime(2021, 4, 4, 18, 35, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 234
                },
                new LancamentoFinanceiro
                {
                    Id = 12,
                    DataHoraLancamento = new DateTime(2021, 4, 4, 11, 24, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 56
                },
                new LancamentoFinanceiro
                {
                    Id = 13,
                    DataHoraLancamento = new DateTime(2021, 4, 4, 11, 21, 0),
                    Conciliado = false,
                    Tipo = TipoLancamentoFinanceiro.Credito,
                    Valor = 213
                });
        }
    }
}
