using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticOtherServiceFareRepository : ILogisticOtherServiceFareRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticOtherServiceFareRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticOtherServiceFare Add(LogisticOtherServiceFare logisticOtherServiceFare)
    {
      _context.LogisticOtherServiceFareItems.Add(logisticOtherServiceFare);
      _context.SaveChanges();

      return logisticOtherServiceFare;
    }

    public LogisticOtherServiceFare Delete(int id)
    {
      LogisticOtherServiceFare logisticOtherServiceFare = _context.LogisticOtherServiceFareItems.Find(id);

      if (logisticOtherServiceFare != null)
      {
        _context.LogisticOtherServiceFareItems.Remove(logisticOtherServiceFare);
        _context.SaveChanges();
      }

      return logisticOtherServiceFare;
    }

    public LogisticOtherServiceFare Get(int id)
    {
      return _context.LogisticOtherServiceFareItems.Find(id);
    }

    public IEnumerable<LogisticOtherServiceFare> Get()
    {
      return _context.LogisticOtherServiceFareItems;
    }

    public LogisticOtherServiceFare Update(LogisticOtherServiceFare logisticOtherServiceFareChanges)
    {
      _context.Entry(logisticOtherServiceFareChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticOtherServiceFareChanges;
    }
  }
}
