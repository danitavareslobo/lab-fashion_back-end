using LabFashion.Models;
using LabFashion.Models.Enums;

using Microsoft.EntityFrameworkCore;

using System.Reflection.Metadata;

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

            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 1, NomeCompleto = "Diego Lobo", Genero = "M", DataNascimento = new DateTime(1990, 6, 6), CpfCnpj = "000.000.000.-00", Telefone  = "9999-9999", Email  = "diego@audaces.com", TipoUsuario  = TipoUsuario.Administrador, Status = Status.Inativo });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 2, NomeCompleto = "Daniele Lobo", Genero = "F", DataNascimento = new DateTime(1989, 8, 11), CpfCnpj = "111.111.111.11", Telefone  = "8888-8888", Email  = "daniele@audaces.com", TipoUsuario  = TipoUsuario.Administrador, Status = Status.Ativo });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 3, NomeCompleto = "Marcella Lobo", Genero = "F", DataNascimento = new DateTime(1995, 7, 31), CpfCnpj = "222.222.222-22", Telefone  = "7777-7777", Email  = "marcella@audaces.com", TipoUsuario  = TipoUsuario.Criador, Status = Status.Inativo });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 4, NomeCompleto = "Isabelle Tavares", Genero = "F", DataNascimento = new DateTime(1994, 12, 20), CpfCnpj = "333.333.333-33", Telefone  = "6666-6666", Email  = "isabelle@audaces.com", TipoUsuario  = TipoUsuario.Criador, Status = Status.Ativo });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 5, NomeCompleto = "Gustavo Tavares", Genero = "M", DataNascimento = new DateTime(1993, 12, 2), CpfCnpj = "444.444.444-44", Telefone  = "5555-5555", Email  = "gustavo@audaces.com", TipoUsuario  = TipoUsuario.Gerente, Status = Status.Inativo });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Id = 6, NomeCompleto = "Enrico Tavares", Genero = "M", DataNascimento = new DateTime(1992, 6, 29), CpfCnpj = "555.555.555-55", Telefone  = "4444-4444", Email  = "enrico@audaces.com", TipoUsuario  = TipoUsuario.Gerente, Status = Status.Ativo });
        }
    }
}