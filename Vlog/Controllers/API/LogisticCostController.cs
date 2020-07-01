using Microsoft.AspNetCore.Mvc;
using Vlog.Models.Interfaces;

namespace Vlog.Controllers.API
{
  public class LogisticCostType
  {
    public int Origin { get; set; }
    public int Destination { get; set; }
    public int Weight { get; set; }
    public decimal Cost { get; set; }
  }

  [Route("api/[controller]")]
  [ApiController]
  public class LogisticCostController : ControllerBase
  {
    private readonly ILogisticCost _logisticCost;
    private readonly ILogisticServiceRepository _logisticServiceRepo;

    public LogisticCostController(ILogisticCost logisticCost, ILogisticServiceRepository logisticServiceRepository)
    {
      _logisticCost = logisticCost;
      _logisticServiceRepo = logisticServiceRepository;
    }

    [Route("logisticserviceid/{serviceId}/regencyFromId/{origin}/regencyToId/{destination}/weight/{weight}")]
    [HttpGet]
    public ActionResult<LogisticCostType> Get(int serviceId, int origin, int destination, int weight)
    {
      return new LogisticCostType { Origin = origin, Destination = destination, Weight = weight, Cost = _logisticCost.GetCost(_logisticServiceRepo.Get(serviceId), origin, destination, weight) };
    }
  }
}
