using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Vlog.Models
{
  public class DbPrepare
  {
    public static void PrepPopulation(IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<VlogDBContext>());
      }
    }

    public static void SeedData(VlogDBContext context)
    {
      context.Database.Migrate();
      System.Console.WriteLine("Database created");
    }
  }
}
