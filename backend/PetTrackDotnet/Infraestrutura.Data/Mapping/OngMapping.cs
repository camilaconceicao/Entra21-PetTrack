using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Mapping;

public class OngMapping : IEntityTypeConfiguration<Ong>
{
    public void Configure(EntityTypeBuilder<Ong> builder)
    {
        builder.ToTable("Ong");

        builder.HasKey(o => o.IdOng);
        builder.Property(t => t.Nome).IsRequired();
        builder.Property(t => t.Cpf).HasMaxLength(14).HasColumnName("CPF").IsRequired();
        builder.Property(t => t.Email).HasMaxLength(100).HasColumnName("Email").IsRequired();
        builder.Property(t => t.Senha).HasColumnName("Senha").IsRequired();
        builder.Property(t => t.Telefone).HasColumnName("Telefone").IsRequired();
        builder.Property(t => t.DataNascimento).HasColumnName("DataNascimento").IsRequired();
        builder.Property(t => t.Cep).HasColumnName("Cep");
        builder.Property(t => t.Bairro).HasColumnName("Cidade");
        builder.Property(t => t.Rua).HasColumnName("Rua");
        builder.Property(t => t.Numero).HasColumnName("Numero");
    }
}