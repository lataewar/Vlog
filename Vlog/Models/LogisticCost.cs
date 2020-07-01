using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models
{
  public class LogisticCost : ILogisticCost
  {
    private readonly RajaOngkirClient _rajaOngkirClient;
    private readonly IRajaOngkirCityRepository _rajaOngkirCityRepository;

    public LogisticCost(IConfiguration configuration, IRajaOngkirCityRepository rajaOngkirCityRepository)
    {
      _rajaOngkirCityRepository = rajaOngkirCityRepository;
      _rajaOngkirClient = new RajaOngkirClient(configuration);
    }

    public decimal GetCost(LogisticService logisticService, int origin, int destination, int weight)
    {
      return logisticService.ROMargin + GetCostRO(origin, destination, weight);
    }

    public decimal GetCostRO(int origin, int destination, int weight)
    {
      var roCityFrom = _rajaOngkirCityRepository.Get().Where(c => c.RegencyId == origin).FirstOrDefault();
      var roCityTo = _rajaOngkirCityRepository.Get().Where(c => c.RegencyId == destination).FirstOrDefault();
      var roCostResp = _rajaOngkirClient.GetPrice(roCityFrom.ROCityId.ToString(), roCityTo.ROCityId.ToString(), weight);

      foreach (JToken eachExp in roCostResp.SelectToken("rajaongkir.results"))
      {
        if ((string)eachExp["code"] == _rajaOngkirClient.DefaultCourier)
        {
          foreach (JToken eachServ in eachExp.SelectToken("costs"))
          {
            if ((string)eachServ["service"] == _rajaOngkirClient.DefaultService)
            {

              foreach (JToken eachCost in eachServ.SelectToken("cost"))
              {
                try
                {
                  return (decimal)eachCost["value"];
                }
                catch (Exception e) { }
              }
            }
          }
        }
      }

      throw new Exception("Could not fetch cost from Raja Ongkir");
    }
  }
}
