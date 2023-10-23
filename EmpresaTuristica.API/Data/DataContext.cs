using EmpresaTuristica.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmpresaTuristica.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 

        }

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Recorrido> Recorridos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<SitiosRecorrido> SitiosRecorridos { get; set; }
        public DbSet<SitioTuristico> SitiosTuristicos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ciudad>().HasIndex(a => a.Nombre).IsUnique();

            modelBuilder.Entity<Actividad>().HasIndex(b => b.Nombre).IsUnique();

            modelBuilder.Entity<Recorrido>().HasIndex(c => c.Nombre).IsUnique();

            modelBuilder.Entity<SitioTuristico>().HasIndex(d => d.Nombre).IsUnique();

        }
    }
}
