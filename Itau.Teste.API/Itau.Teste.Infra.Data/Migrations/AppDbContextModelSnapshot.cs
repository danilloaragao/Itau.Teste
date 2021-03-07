﻿// <auto-generated />
using Itau.Teste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace Itau.Teste.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Itau.Teste.Domain.Entities.LancamentoFinanceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<bool>("Conciliado")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("CONCILIADO");

                    b.Property<DateTime>("DataHoraLancamento")
                        .HasColumnType("datetime")
                        .HasColumnName("DATA_HORA_LANCAMENTO");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("TIPO");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("VALOR");

                    b.HasKey("Id")
                        .HasName("ID");

                    b.ToTable("teste_itau.LANCAMENTOS_FINANCEIROS");
                });
#pragma warning restore 612, 618
        }
    }
}
