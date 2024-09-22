using Microsoft.EntityFrameworkCore;
using Gym.Models;

namespace Gym.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<Branch>().ToTable("Branch").HasIndex(b=>b.Address).IsUnique();
            modelBuilder.Entity<Client>().ToTable("Client").HasIndex(c=>c.Email).IsUnique();
            modelBuilder.Entity<Subscription>().ToTable("Subscription");
        }

    }
}
