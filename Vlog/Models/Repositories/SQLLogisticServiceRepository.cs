using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticServiceRepository : ILogisticServiceRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticServiceRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticService Add(LogisticService logisticService)
    {
      _context.LogisticServiceItems.Add(logisticService);
      _context.SaveChanges();

      return logisticService;
    }

    public LogisticService Delete(int id)
    {
      LogisticService logisticService = _context.LogisticServiceItems.Find(id);

      if (logisticService != null)
      {
        _context.LogisticServiceItems.Remove(logisticService);
        _context.SaveChanges();
      }

      return logisticService;
    }

    public LogisticService Get(int id)
    {
      return _context.LogisticServiceItems.Find(id);
    }

    public IEnumerable<LogisticService> Get()
    {
      return _context.LogisticServiceItems;
    }

    public LogisticService Update(LogisticService logisticServiceChanges)
    {
      var local = _context.Set<LogisticService>().Local.FirstOrDefault(entry => entry.Id.Equals(logisticServiceChanges.Id));
      
      if (local != null)
      {
        _context.Entry(local).State = EntityState.Detached;
      }

      _context.Entry(logisticServiceChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticServiceChanges;
    }
  }
}
