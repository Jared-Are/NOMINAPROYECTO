using Microsoft.EntityFrameworkCore;
using SharedModels;
using System.Reflection.Emit;

namespace migracio_api.Data
{
    public class NominaContext : DbContext
    {
        public NominaContext(DbContextOptions<NominaContext> options) : base( options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deduccion>()
                .HasKey(d => d.EmpleadoId);
            modelBuilder.Entity<Ingreso>()
                .HasKey(d => d.EmpleadoId);
            modelBuilder.Entity<Nomina>()
                .HasKey(d => d.EmpleadoId);

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Empleado> empleados { get; set; }
        DbSet<Ingreso> ingresos { get; set; }
        DbSet<Deduccion> deducciones { get; set; }
        DbSet<Nomina> nominas { get; set; }
        DbSet<User> Users { get; set; }
    }
}
