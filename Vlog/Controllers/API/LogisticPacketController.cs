using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Controllers.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class LogisticPacketController : Controller
  {
    private readonly ILogisticServiceRepository _logisticServiceRepo;
    private readonly ILogisticPacketRepository _logisticPacketRepo;
    private readonly IRajaOngkirCityRepository _rajaOngkirCityRepository;
    private readonly RajaOngkirClient _rajaOngkirClient;

    public LogisticPacketController(ILogisticPacketRepository logisticPacketRepository, IRajaOngkirCityRepository rajaOngkirCityRepository, ILogisticServiceRepository logisticServiceRepository, IConfiguration configuration)
    {
      _logisticServiceRepo = logisticServiceRepository;
      _logisticPacketRepo = logisticPacketRepository;
      _rajaOngkirCityRepository = rajaOngkirCityRepository;
      _rajaOngkirClient = new RajaOngkirClient(configuration);
    }

    [HttpGet]
    public ActionResult<IEnumerable<LogisticPacket>> Get()
    {
      return _logisticPacketRepo.Get().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<LogisticPacket> Get(int id)
    {
      return _logisticPacketRepo.Get(id);
    }

    private LogisticPacket UpdateCostBasedOnMargin(LogisticPacket logisticPacket)
    {
      logisticPacket.CurrentNominal = logisticPacket.CurrentNominal + _logisticServiceRepo.Get(logisticPacket.LogisticServiceId).ROMargin;
      return logisticPacket;
    }

    private LogisticPacket UpdateCostBasedOnRO(LogisticPacket logisticPacket)
    {
      var roCityFrom = _rajaOngkirCityRepository.Get().Where(c => c.RegencyId == logisticPacket.AddressFrom.RegencyId).FirstOrDefault();
      var roCityTo = _rajaOngkirCityRepository.Get().Where(c => c.RegencyId == logisticPacket.AddressTo.RegencyId).FirstOrDefault();

      var roCostResp = _rajaOngkirClient.GetPrice(roCityFrom.ROCityId.ToString(), roCityTo.ROCityId.ToString(), logisticPacket.UnitNumber);

      bool found = false;

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
                  logisticPacket.CurrentNominal = (decimal)eachCost["value"];
                  found = true;
                  break;
                } catch (Exception e) {}
              }

              if (found)
                break;
            }
          }
        }

        if (found)
          break;
      }

      if (!found)
        throw new Exception("Could not fetct cost from Raja Ongkir");

      return logisticPacket;
    }

    private LogisticPacket UpdateCreatedDate(LogisticPacket logisticPacket)
    {
      logisticPacket.DateCreated = DateTime.Now;

      return logisticPacket;
    }

    private LogisticPacket GenerateAWB(LogisticPacket logisticPacket)
    {
      int reserved = 0;
      string generatedCode;

      do
      {
        reserved++;

        if (reserved > 999)
          throw new Exception("Out of reserved int");

        generatedCode = AirwayBill.GenerateCode(logisticPacket.AddressFrom.RegencyId, logisticPacket.Id, 1, reserved);
      } while (_logisticPacketRepo.Get().Where(p => p.AirWayBill == generatedCode).ToList().Count() > 0);

      logisticPacket.AirWayBill = generatedCode;

      return logisticPacket;
    }

    [HttpPost]
    public ActionResult<LogisticPacket> Add(LogisticPacket logisticPacket)
    {
      return _logisticPacketRepo.Update (
        UpdateCreatedDate(
          GenerateAWB(
            _logisticPacketRepo.Add(
              UpdateCostBasedOnMargin(
                UpdateCostBasedOnRO(logisticPacket)
              )
            )
          )
        )
      ); 
    }

    [HttpPut("{id}")]
    public ActionResult<LogisticPacket> Update(int id, LogisticPacket logisticPacket)
    {
      if (id != logisticPacket.Id)
        return BadRequest();

      var logisticPacketItem = _logisticPacketRepo.Get(id);

      if (logisticPacketItem == null)
        return NotFound();

      return _logisticPacketRepo.Update(logisticPacket);
    }

    [HttpDelete("{id}")]
    public ActionResult<LogisticPacket> Delete(int id)
    {
      var logisticPacketItem = _logisticPacketRepo.Get(id);

      if (logisticPacketItem == null)
        return NotFound();

      return _logisticPacketRepo.Delete(id);
    }
  }
}
