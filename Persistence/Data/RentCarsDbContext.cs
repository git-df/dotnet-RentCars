using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class RentCarsDbContext : DbContext
    {
        public DbSet<UserApp> UsersApp { get; set; }
        public DbSet<UserEmployee> UsersEmployees { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<UserEmployee2Branch> UserEmployees2Branches { get; set; }
        public DbSet<User2Address> Users2Addresses { get; set; }
        public DbSet<CarsModel> CarsModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarAttribute> CarAttributes { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentPayment> RentsPayments { get; set; }
        
        public RentCarsDbContext(DbContextOptions<RentCarsDbContext> options) : base(options)
        {  
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Offer>(e =>
            {
                e.Property(e => e.PricePerHour)
                    .HasColumnType("decimal(19,4)");

                e.Property(e => e.PricePreDay)
                    .HasColumnType("decimal(19,4)");
            });

            mb.Entity<RentPayment>(e =>
            {
                e.Property(e => e.Price)
                    .HasColumnType("decimal(19,4)");
            });
        }
    }
}
