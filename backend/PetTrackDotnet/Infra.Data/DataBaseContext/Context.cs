using System.Reflection;
using Infra.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.DataBaseContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());    
    }

    //Injeção dos dataSets
    public DbSet<Usuario> Usuario { get; set; } = null!;
    public DbSet<Pet> Pet { get; set; } = null!;
    public DbSet<Ong> Ong { get; set; } = null!;
    public DbSet<Care> Care { get; set; } = null!;
}