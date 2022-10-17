using imobiliaria.Models;
using Microsoft.EntityFrameworkCore;

namespace imobiliaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Imovel)
                .WithOne(imovel => imovel.Endereco)
                .HasForeignKey<Imovel>(imovel => imovel.IdEndereco);

            builder.Entity<Imovel>()
                .HasOne(imovel => imovel.Proprietario)
                .WithMany(proprietario => proprietario.Imoveis)
                .HasForeignKey(imovel => imovel.IdProprietario);

            builder.Entity<ContratoAluguel>()
                .HasOne(contratoAluguel => contratoAluguel.Inquilino)
                .WithMany(inquilino => inquilino.Contratos)
                .HasForeignKey(contratoAluguel => contratoAluguel.IdInquilino);

            builder.Entity<ContratoAluguel>()
                .HasOne(contratoAluguel => contratoAluguel.Imovel)
                .WithMany(imovel => imovel.Contratos)
                .HasForeignKey(contratoAluguel => contratoAluguel.IdImovel);

        }

        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<ContratoAluguel> Contratos { get; set;}

    }
}
