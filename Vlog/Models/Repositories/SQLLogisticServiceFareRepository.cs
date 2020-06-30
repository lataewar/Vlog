using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticServiceFareRepository : ILogisticSeviceFareRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticServiceFareRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticServiceFare Add(LogisticServiceFare logisticFareNominal)
    {
      _context.LogisticServiceFarelItems.Add(logisticFareNominal);
      _context.SaveChanges();

      return logisticFareNominal;
    }

    public LogisticServiceFare Delete(int id)
    {
      LogisticServiceFare logisticFareNominal = _context.LogisticServiceFarelItems.Find(id);

      if (logisticFareNominal != null)
      {
        _context.LogisticServiceFarelItems.Remove(logisticFareNominal);
        _context.SaveChanges();
      }

      return logisticFareNominal;
    }

    public LogisticServiceFare Get(int id)
    {
      return _context.LogisticServiceFarelItems.Find(id);
    }

    public IEnumerable<LogisticServiceFare> Get()
    {
      return _context.LogisticServiceFarelItems;
    }

    public LogisticServiceFare Update(LogisticServiceFare logisticFareNominalChanges)
    {
      _context.Entry(logisticFareNominalChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticFareNominalChanges;
    }
  }
}
