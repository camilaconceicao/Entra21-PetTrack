﻿using Infraestrutura.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Mapping;

public class MenuMapping : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("MENU");
        
        builder.HasKey(o => o.IdMenu);
        builder.Property(t => t.Nome).HasColumnName("Nome").IsRequired();
        builder.Property(t => t.Link).HasColumnName("Link").IsRequired();
        
        builder
            .HasOne(p => p.Modulo)
            .WithMany(b => b.lMenus)
            .HasForeignKey(p => p.IdModulo)
            .IsRequired();
    }
}