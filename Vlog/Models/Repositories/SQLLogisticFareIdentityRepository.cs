using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticFareIdentityRepository : ILogisticFareIdentityRepository
  {
    private readonly VlogDBContext _context;
    public SQLLogisticFareIdentityRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticFareIdentity Add(LogisticFareIdentity logisticFareIdentity)
    {
      _context.LogisticFareIdentityItems.Add(logisticFareIdentity);
      _context.SaveChanges();

      return logisticFareIdentity;
    }

    public LogisticFareIdentity Delete(int id)
    {
      LogisticFareIdentity logisticFareIdentity = _context.LogisticFareIdentityItems.Find(id);

      if (logisticFareIdentity != null)
      {
        _context.LogisticFareIdentityItems.Remove(logisticFareIdentity);
        _context.SaveChanges();
      }

      return logisticFareIdentity;
    }

    public IEnumerable<LogisticFareIdentity> GetLogisticFareIdentities()
    {
      return _context.LogisticFareIdentityItems;
    }

    public LogisticFareIdentity GetLogisticFareIdentity(int id)
    {
      return _context.LogisticFareIdentityItems.Find(id);
    }

    public LogisticFareIdentity Update(LogisticFareIdentity logisticFareIdentityChanges)
    {
      _context.Entry(logisticFareIdentityChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticFareIdentityChanges;
    }
  }
}
