using LabFashion.Models;

using Microsoft.EntityFrameworkCore;

namespace LabFashion.Database
{
    public class LabFashionContext : DbContext
    {
        public LabFashionContext(DbContextOptions<LabFashionContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}