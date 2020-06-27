using Microsoft.EntityFrameworkCore;

namespace Vlog.Models
{
  public class VlogDBContext : DbContext
  {
    public VlogDBContext(DbContextOptions<VlogDBContext> options) : base(options)
    {
    }

    public DbSet<User> UserItems { get; set; }
    public DbSet<Contact> ContactItems { get; set; }
  }
}
