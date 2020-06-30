using Microsoft.EntityFrameworkCore;
using Vlog.Models.Types;

namespace Vlog.Models
{
  public class VlogDBContext : DbContext
  {
    public VlogDBContext(DbContextOptions<VlogDBContext> options) : base(options)
    {
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Province>().HasOne(p => p.Country).WithMany(c => c.Provinces);
      modelBuilder.Entity<Regency>().HasOne(r => r.Province).WithMany(p => p.Regencies);
      modelBuilder.Entity<Rural>().HasOne(ru => ru.Regency).WithMany(r => r.Rurals);
    }*/

    public DbSet<User> UserItems { get; set; }
    public DbSet<Contact> ContactItems { get; set; }
    public DbSet<Company> CompanyItems { get; set; }
    public DbSet<Address> AddressItems { get; set; }
    public DbSet<Country> CountryItems { get; set; }
    public DbSet<LogisticFareIdentity> LogisticFareIdentityItems { get; set; }
    public DbSet<LogisticServiceFare> LogisticServiceFarelItems { get; set; }
    public DbSet<LogisticOtherService> LogisticOtherServiceItems { get; set; }
    public DbSet<LogisticOtherServiceFare> LogisticOtherServiceFareItems { get; set; }
    public DbSet<LogisticPacket> LogisticPacketItems { get; set; }
    public DbSet<LogisticService> LogisticServiceItems { get; set; }
    public DbSet<Province> ProvinceItems { get; set; }
    public DbSet<Regency> RegencyItems { get; set; }
    public DbSet<Rural> RuralItems { get; set; }
    public DbSet<UserRole> UserRoleItems { get; set; }
    public DbSet<RajaOngkirCity> RajaOngkirCityItems { get; set; }
    public DbSet<RajaOngkirProvince> RajaOngkirProvinceItems { get; set; }
  }
}
