using Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class OngMapping : IEntityTypeConfiguration<Ong>
{
    public void Configure(EntityTypeBuilder<Ong> builder)
    {
        builder.ToTable("Ong");

        builder.HasKey(o => o.IdOng);
        builder.Property(t => t.Nome).HasColumnName("Nome").IsRequired();
        builder.Property(t => t.Descricao).HasColumnName("Descricao").IsRequired();
        builder.Property(t => t.Email).HasColumnName("Email").IsRequired();
        builder.Property(t => t.RazaoSocial).HasColumnName("RazaoSocial").IsRequired();
        builder.Property(t => t.Pix).HasColumnName("Pix").IsRequired();
        builder.Property(t => t.DataCadastro).HasColumnName("DataCadastro").IsRequired();
        builder.Property(t => t.FotoBase64).HasColumnName("FotoBase64").IsRequired();
    }
}