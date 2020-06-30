using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vlog.Models.Interfaces;
using Vlog.Models.Repositories;
using Vlog.Models.Types;

namespace Vlog.Controllers.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class LogisticServiceController : Controller
  {
    private readonly ILogisticServiceRepository _logisticServiceRepo;
    public LogisticServiceController(ILogisticServiceRepository logisticServiceRepository)
    {
      _logisticServiceRepo = logisticServiceRepository;
    }

    /// <summary>
    ///  return all logistic services
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<LogisticService>> Get()
    {
      return _logisticServiceRepo.Get().ToList();
    }

    /// <summary>
    /// return specific logistic service
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<LogisticService> Get(int id)
    {
      return _logisticServiceRepo.Get(id);
    }
    
    /// <summary>
    /// add logistic service
    /// </summary>
    /// <param name="logisticService"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<LogisticService> Add(LogisticService logisticService)
    {
      return _logisticServiceRepo.Add(logisticService);
    }

    /// <summary>
    /// update logistic service
    /// </summary>
    /// <param name="id"></param>
    /// <param name="logisticService"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult<LogisticService> Update(int id, LogisticService logisticService)
    {
      if (id != logisticService.Id)
        return BadRequest();

      var logisticServiceItem = _logisticServiceRepo.Get(id);

      if (logisticServiceItem == null)
        return NotFound();

      return _logisticServiceRepo.Update(logisticService);
    }
    
    /// <summary>
    /// delete specisif logistic service
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult<LogisticService> Delete(int id)
    {
      var logisticServiceItem = _logisticServiceRepo.Get(id);

      if (logisticServiceItem == null)
        return NotFound();

      return _logisticServiceRepo.Delete(id);
    }
  }
}
