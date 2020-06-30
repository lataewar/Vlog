using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vlog.Models;
using Vlog.Models.Interfaces;
using Vlog.Models.Repositories;

namespace Vlog
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }
    public static IConfiguration StaticConfiguration { get; private set; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      StaticConfiguration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = $"Data Source={Configuration["Database:Docker:Server"]},{Configuration["Database:Docker:Port"]};Initial Catalog={Configuration["Database:Docker:DBName"]};User ID={Configuration["Database:Docker:User"]};Password={Configuration["Database:Docker:Password"]};";
      
      services.AddDbContext<VlogDBContext>
        (opt => opt.UseSqlServer(connectionString));

      services.AddControllersWithViews();

      services.AddScoped<IAddressRepository, SQLAddressRepository>();
      services.AddScoped<ICompanyRepository, SQLCompanyRepository>();
      services.AddScoped<IContactRepository, SQLContactRepository>();
      services.AddScoped<ICountryRepository, SQLCountryRepository>();
      services.AddScoped<ILogisticFareIdentityRepository, SQLLogisticFareIdentityRepository>();
      services.AddScoped<ILogisticSeviceFareRepository, SQLLogisticServiceFareRepository>();
      services.AddScoped<ILogisticOtherServiceRepository, SQLLogisticOtherServiceRepository>();
      services.AddScoped<ILogisticOtherServiceFareRepository, SQLLogisticOtherServiceFareRepository>();
      services.AddScoped<ILogisticPacketRepository, SQLLogisticPacketRepository>();
      services.AddScoped<ILogisticServiceRepository, SQLLogisticServiceRepository>();
      services.AddScoped<IProvinceRepository, SQLProvinceRepository>();
      services.AddScoped<IRegencyRepository, SQLRegencyRepository>();
      services.AddScoped<IRuralRepository, SQLRuralRepository>();
      services.AddScoped<IUserRepository, SQLUserRepository>();
      services.AddScoped<IUserRoleRepository, SQLUserRoleRepository>();
      services.AddScoped<IRajaOngkirCityRepository, SQLRajaOngkirCityRepository>();
      services.AddScoped<IRajaOngkirProvinceRepository, SQLRajaOngkirProvinceRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      DbPrepare.PrepPopulation(app);

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
