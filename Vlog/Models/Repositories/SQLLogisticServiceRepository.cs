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

    public LogisticService GetLogisticService(int id)
    {
      return _context.LogisticServiceItems.Find(id);
    }

    public IEnumerable<LogisticService> GetLogisticServices()
    {
      return _context.LogisticServiceItems;
    }

    public LogisticService Update(LogisticService logisticServiceChanges)
    {
      _context.Entry(logisticServiceChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticServiceChanges;
    }
  }
}
