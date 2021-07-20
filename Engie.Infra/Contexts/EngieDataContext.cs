using Engie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Engie.Infra.Contexts
{
    public class EngieDataContext : DbContext
    {
        public EngieDataContext(DbContextOptions<EngieDataContext> options) : base(options)
        {
        }

        public DbSet<PowerPlant> PowerPlants { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("Fornecedor");
            modelBuilder.Entity<Supplier>().HasKey(x => x.Id);
            modelBuilder.Entity<Supplier>().Property(x => x.Id).HasColumnType("int").UseIdentityColumn();
            modelBuilder.Entity<Supplier>().Property(x => x.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");

            modelBuilder.Entity<PowerPlant>().ToTable("Usina");
            modelBuilder.Entity<PowerPlant>().HasKey(x => x.Id);
            modelBuilder.Entity<PowerPlant>().Property(x => x.Id).HasColumnType("int").UseIdentityColumn();
            modelBuilder.Entity<PowerPlant>().Property(x => x.PowerPlantUC).IsRequired().HasMaxLength(20).HasColumnType("varchar(20)");
            modelBuilder.Entity<PowerPlant>().Property(x => x.Active).IsRequired().HasColumnType("bit");
            modelBuilder.Entity<PowerPlant>().HasOne(x => x.Supplier);


        }
    }
}