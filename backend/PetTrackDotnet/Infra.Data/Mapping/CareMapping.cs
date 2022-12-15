using Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class CareMapping : IEntityTypeConfiguration<Care>
{
    public void Configure(EntityTypeBuilder<Care> builder)
    {
        builder.ToTable("Care");

        builder.HasKey(o => o.IdCare);
        builder.Property(t => t.Nome).HasColumnName("Nome").IsRequired();
        builder.Property(t => t.Descricao).HasColumnName("Descricao").IsRequired();
        builder.Property(t => t.DataCadastro).HasColumnName("DataCadastro").IsRequired();
        builder.Property(t => t.FotoBase64).HasColumnName("FotoBase64").IsRequired();
    }
}