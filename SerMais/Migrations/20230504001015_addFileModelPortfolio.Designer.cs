﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SerMais.Data;

#nullable disable

namespace SerMais.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20230504001015_addFileModelPortfolio")]
    partial class addFileModelPortfolio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SerMais.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ID_CLIENTEID")
                        .HasColumnType("int");

                    b.Property<int>("ID_PROFISSIONALID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ID_CLIENTEID");

                    b.HasIndex("ID_PROFISSIONALID");

                    b.ToTable("AGENDAMENTO");
                });

            modelBuilder.Entity("SerMais.Models.ClienteModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ATIVO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DT_NASCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NOME_COMPLETO")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SENHA")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TELEFONE")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("SerMais.Models.ConsultaModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DATA_HORA")
                        .HasColumnType("datetime2");

                    b.Property<string>("FORMA_DE_PAGAMENTO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ID_AGENDAMENTOID")
                        .HasColumnType("int");

                    b.Property<int>("ID_TIPO_CONSULTAID")
                        .HasColumnType("int");

                    b.Property<string>("LINK_REUNIAO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QUEIXA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("ID_AGENDAMENTOID");

                    b.HasIndex("ID_TIPO_CONSULTAID");

                    b.ToTable("CONSULTA");
                });

            modelBuilder.Entity("SerMais.Models.PortfolioModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ATENDE_CONSULTA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CELULAR")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DURACAO_SESSAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAIL")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ESPECIALIDADE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FORMACAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FORMAS_PAGAMENTO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_PROFISSIONALID")
                        .HasColumnType("int");

                    b.Property<string>("IMAGEM_PROFILE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SOBRE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TELEFONE")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("VALOR_CONSULTA")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ID_PROFISSIONALID");

                    b.ToTable("PORTFOLIO");
                });

            modelBuilder.Entity("SerMais.Models.ProfissionalModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ATIVO")
                        .HasColumnType("int");

                    b.Property<string>("BAIRRO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CIDADE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("COMPLEMENTO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("CRP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DT_NASCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ESTADO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NIVEL")
                        .HasColumnType("int");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NOME_COMPLETO")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NUMERO")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OBSERVACAO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RUA")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SOBRENOME")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("TELEFONE")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("PROFISSIONAL");
                });

            modelBuilder.Entity("SerMais.Models.TipoConsultaModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NOME_TIPO_CONSULTA")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("TIPO_CONSULTA_MODEL");
                });

            modelBuilder.Entity("SerMais.Models.UsuarioModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ATIVO")
                        .HasColumnType("int");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ID_PROFISSIONALID")
                        .HasColumnType("int");

                    b.Property<int>("POLITICA")
                        .HasColumnType("int");

                    b.Property<string>("SENHA")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ID");

                    b.HasIndex("ID_PROFISSIONALID");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("SerMais.Models.AgendamentoModel", b =>
                {
                    b.HasOne("SerMais.Models.ClienteModel", "ID_CLIENTE")
                        .WithMany()
                        .HasForeignKey("ID_CLIENTEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SerMais.Models.ProfissionalModel", "ID_PROFISSIONAL")
                        .WithMany()
                        .HasForeignKey("ID_PROFISSIONALID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ID_CLIENTE");

                    b.Navigation("ID_PROFISSIONAL");
                });

            modelBuilder.Entity("SerMais.Models.ConsultaModel", b =>
                {
                    b.HasOne("SerMais.Models.AgendamentoModel", "ID_AGENDAMENTO")
                        .WithMany()
                        .HasForeignKey("ID_AGENDAMENTOID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SerMais.Models.TipoConsultaModel", "ID_TIPO_CONSULTA")
                        .WithMany()
                        .HasForeignKey("ID_TIPO_CONSULTAID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ID_AGENDAMENTO");

                    b.Navigation("ID_TIPO_CONSULTA");
                });

            modelBuilder.Entity("SerMais.Models.PortfolioModel", b =>
                {
                    b.HasOne("SerMais.Models.ProfissionalModel", "ID_PROFISSIONAL")
                        .WithMany()
                        .HasForeignKey("ID_PROFISSIONALID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ID_PROFISSIONAL");
                });

            modelBuilder.Entity("SerMais.Models.UsuarioModel", b =>
                {
                    b.HasOne("SerMais.Models.ProfissionalModel", "ID_PROFISSIONAL")
                        .WithMany()
                        .HasForeignKey("ID_PROFISSIONALID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ID_PROFISSIONAL");
                });
#pragma warning restore 612, 618
        }
    }
}
