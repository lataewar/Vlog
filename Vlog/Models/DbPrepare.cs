using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System.Linq;
using Vlog.Models.Interfaces;
using Vlog.Models.Repositories;
using Vlog.Models.Types;

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
      SeedDataFromRajaOngkir(context);
      System.Console.WriteLine("Database created");
    }

    public static void SeedDataFromRajaOngkir(VlogDBContext context)
    {
      var roClient = new RajaOngkirClient( Startup.StaticConfiguration );

      var result = roClient.GetCities();

      var roCityRepo = new SQLRajaOngkirCityRepository(context);
      var roProvinceRepo = new SQLRajaOngkirProvinceRepository(context);
      var provinceRepo = new SQLProvinceRepository(context);
      var regRepo = new SQLRegencyRepository(context);
      var countryRepo = new SQLCountryRepository(context);

      var country = countryRepo.Get().FirstOrDefault();

      // tambahin country indonesia
      if (country == null)
        country = countryRepo.Add(new Country { Name = "Indonesia" } );

      foreach (JToken city in result.SelectToken("rajaongkir.results"))
      {
        string provinceName = (string)city["province"];
        int provinceId = (int)city["province_id"];
        var roProvince = roProvinceRepo.GetByROProvinceId( provinceId );

        var province = provinceRepo.GetByROProvinceName(provinceName);

        if (roProvince == null)
        {
          // cek province dalam database
          // kalau belum ada, input province nya
          if (province == null)
            province = provinceRepo.Add(new Province { Country = country, Name = provinceName });
          
          roProvince = roProvinceRepo.Add(new RajaOngkirProvince { ROProvinceId = provinceId, Province = province });
        }

        int cityId = (int)city["city_id"];
        string cityName = (string)city["city_name"];
        string cityType = (string)city["type"];
        string postalCode = (string)city["postal_code"];

        var roCity = roCityRepo.GetByROCityId(cityId);

        if ( roCity == null )
        {
          // cek regency dalam database
          var regency = regRepo.GetByROCityName(province, cityName);

          // kalau belum ada input city nya
          if (regency == null)
            regency = regRepo.Add(new Regency { Name = cityName, Province = province });

          roCity = roCityRepo.Add(new RajaOngkirCity { ROCityId = cityId, Type = cityType, PostalCode = postalCode, Regency = regency });
        }


      }
    }
  }
}
