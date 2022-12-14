// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imobiliaria.Data;

#nullable disable

namespace imobiliaria.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("imobiliaria.Models.ContratoAluguel", b =>
                {
                    b.Property<int>("idContratoAluguel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAssinatura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdImovel")
                        .HasColumnType("int");

                    b.Property<int>("IdInquilino")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("idContratoAluguel");

                    b.HasIndex("IdImovel");

                    b.HasIndex("IdInquilino");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("imobiliaria.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("IdEndereco");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("imobiliaria.Models.Imovel", b =>
                {
                    b.Property<int>("IdImovel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdProprietario")
                        .HasColumnType("int");

                    b.Property<int>("QtBanheiros")
                        .HasColumnType("int");

                    b.Property<int>("QtQuartos")
                        .HasColumnType("int");

                    b.HasKey("IdImovel");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.HasIndex("IdProprietario");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("imobiliaria.Models.Inquilino", b =>
                {
                    b.Property<int>("IdInquilino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdInquilino");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("imobiliaria.Models.Proprietario", b =>
                {
                    b.Property<int>("IdProprietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdProprietario");

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("imobiliaria.Models.ContratoAluguel", b =>
                {
                    b.HasOne("imobiliaria.Models.Imovel", "Imovel")
                        .WithMany("Contratos")
                        .HasForeignKey("IdImovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobiliaria.Models.Inquilino", "Inquilino")
                        .WithMany("Contratos")
                        .HasForeignKey("IdInquilino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");

                    b.Navigation("Inquilino");
                });

            modelBuilder.Entity("imobiliaria.Models.Imovel", b =>
                {
                    b.HasOne("imobiliaria.Models.Endereco", "Endereco")
                        .WithOne("Imovel")
                        .HasForeignKey("imobiliaria.Models.Imovel", "IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobiliaria.Models.Proprietario", "Proprietario")
                        .WithMany("Imoveis")
                        .HasForeignKey("IdProprietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("imobiliaria.Models.Endereco", b =>
                {
                    b.Navigation("Imovel")
                        .IsRequired();
                });

            modelBuilder.Entity("imobiliaria.Models.Imovel", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("imobiliaria.Models.Inquilino", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("imobiliaria.Models.Proprietario", b =>
                {
                    b.Navigation("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
