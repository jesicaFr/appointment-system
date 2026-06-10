using AppointmentSystem.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PatientName).IsRequired();
                entity.Property(e => e.AppointmentDate).IsRequired();
                entity.Property(e => e.Reason).IsRequired();
                entity.Property(e => e.IsCancelled).HasDefaultValue(false);
            });
        }
    }
}
