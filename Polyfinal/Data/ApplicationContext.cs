using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Polyfinal.Models;
using System.ComponentModel;

namespace Polyfinal.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Rent> Rent { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DB;Username=postgres;Password=password");
            }
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Rent>().ToTable("Rent");
        }
    }
}
