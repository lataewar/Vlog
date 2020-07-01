using Microsoft.AspNetCore.Mvc;
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
    private readonly ILogisticPacketRepository _logisticPacketRepo;
    public LogisticPacketController(ILogisticPacketRepository logisticPacketRepository)
    {
      _logisticPacketRepo = logisticPacketRepository;
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

    [HttpPost]
    public ActionResult<LogisticPacket> Add(LogisticPacket logisticPacket)
    {
      logisticPacket.DateCreated = DateTime.Now;
      return _logisticPacketRepo.Add(logisticPacket);
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
