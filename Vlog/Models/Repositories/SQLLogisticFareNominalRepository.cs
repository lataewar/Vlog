using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticFareNominalRepository : ILogisticFareNominalRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticFareNominalRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticFareNominal Add(LogisticFareNominal logisticFareNominal)
    {
      _context.LogisticFareNominalItems.Add(logisticFareNominal);
      _context.SaveChanges();

      return logisticFareNominal;
    }

    public LogisticFareNominal Delete(int id)
    {
      LogisticFareNominal logisticFareNominal = _context.LogisticFareNominalItems.Find(id);

      if (logisticFareNominal != null)
      {
        _context.LogisticFareNominalItems.Remove(logisticFareNominal);
        _context.SaveChanges();
      }

      return logisticFareNominal;
    }

    public LogisticFareNominal GetLogisticFareNominal(int id)
    {
      return _context.LogisticFareNominalItems.Find(id);
    }

    public IEnumerable<LogisticFareNominal> GetLogisticFareNominals()
    {
      return _context.LogisticFareNominalItems;
    }

    public LogisticFareNominal Update(LogisticFareNominal logisticFareNominalChanges)
    {
      _context.Entry(logisticFareNominalChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticFareNominalChanges;
    }
  }
}
