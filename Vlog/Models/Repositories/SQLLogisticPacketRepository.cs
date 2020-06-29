using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticPacketRepository : ILogisticPacketRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticPacketRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticPacket Add(LogisticPacket logisticPacket)
    {
      _context.LogisticPacketItems.Add(logisticPacket);
      _context.SaveChanges();

      return logisticPacket;
    }

    public LogisticPacket Delete(int id)
    {
      LogisticPacket logisticPacket = _context.LogisticPacketItems.Find(id);

      if (logisticPacket != null)
      {
        _context.LogisticPacketItems.Remove(logisticPacket);
        _context.SaveChanges();
      }

      return logisticPacket;
    }

    public LogisticPacket GetLogisticPacket(int id)
    {
      return _context.LogisticPacketItems.Find(id);
    }

    public IEnumerable<LogisticPacket> GetLogisticPackets()
    {
      return _context.LogisticPacketItems;
    }

    public LogisticPacket Update(LogisticPacket logisticPacketChanges)
    {
      _context.Entry(logisticPacketChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticPacketChanges;
    }
  }
}
