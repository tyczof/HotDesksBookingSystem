using HotDesks.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotDesks
{
    public class HotDeskContext : DbContext
    {
        public HotDeskContext(DbContextOptions<HotDeskContext> options)
            : base(options)
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desk>()
                .HasOne(d => d.Location)
                .WithMany(l => l.Desks)
                .HasForeignKey(d => d.LocationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Desk)
                .WithMany(d => d.Reservations)
                .HasForeignKey(r => r.DeskId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EmployeeId);
        }
    }

}
