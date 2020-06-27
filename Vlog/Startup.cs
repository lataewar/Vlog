using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vlog.Models;

namespace Vlog
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = $"Data Source={Configuration["Database:Docker:Server"]},{Configuration["Database:Docker:Port"]};Initial Catalog={Configuration["Database:Docker:DBName"]};User ID={Configuration["Database:Docker:User"]};Password={Configuration["Database:Docker:Password"]};";
      
      services.AddDbContext<VlogDBContext>
        (opt => opt.UseSqlServer(connectionString));
      services.AddControllersWithViews();
      services.AddScoped<IContactRepository, SQLContactRepository>();
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
