using Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class PetMapping : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pet");

        builder.HasKey(o => o.IdPet);
        builder.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
        builder.Property(t => t.Descricao).HasColumnName("Descricao").HasMaxLength(200).IsRequired();
        builder.Property(t => t.Raca).HasColumnName("Raca").HasMaxLength(30).IsRequired();
        builder.Property(t => t.Tamanho).HasColumnName("Tamanho").IsRequired();
        builder.Property(t => t.DataCadastro).HasColumnName("DataCadastro").IsRequired();
        builder.Property(t => t.FotoBase64).HasColumnName("FotoBase64").IsRequired();
        builder.Property(t => t.UsuarioCadastroId).HasColumnName("UsuarioCadastroId").IsRequired();
        builder.Property(t => t.TipoCadastro).HasColumnName("TipoCadastro").IsRequired();
        builder.Property(t => t.Cep).HasColumnName("Cep").IsRequired();
        builder.Property(t => t.Bairro).HasColumnName("Cidade").IsRequired();
        builder.Property(t => t.Rua).HasColumnName("Rua").IsRequired();
        builder.Property(t => t.Latitude).HasColumnName("Latitude");
        builder.Property(t => t.Longitude).HasColumnName("Longitude");
        
        builder
            .HasOne(t => t.Usuario)
            .WithMany(t => t.LPetz)
            .HasForeignKey(t => t.UsuarioCadastroId);
    }
}