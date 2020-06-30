using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLLogisticOtherServiceRepository : ILogisticOtherServiceRepository
  {
    private readonly VlogDBContext _context;

    public SQLLogisticOtherServiceRepository(VlogDBContext context)
    {
      _context = context;
    }
    public LogisticOtherService Add(LogisticOtherService logisticOtherService)
    {
      _context.LogisticOtherServiceItems.Add(logisticOtherService);
      _context.SaveChanges();

      return logisticOtherService;
    }

    public LogisticOtherService Delete(int id)
    {
      LogisticOtherService logisticOtherService = _context.LogisticOtherServiceItems.Find(id);

      if (logisticOtherService != null)
      {
        _context.LogisticOtherServiceItems.Remove(logisticOtherService);
        _context.SaveChanges();
      }

      return logisticOtherService;
    }

    public LogisticOtherService Get(int id)
    {
      return _context.LogisticOtherServiceItems.Find(id);
    }

    public IEnumerable<LogisticOtherService> Get()
    {
      return _context.LogisticOtherServiceItems;
    }

    public LogisticOtherService Update(LogisticOtherService logisticOtherServiceChanges)
    {
      _context.Entry(logisticOtherServiceChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return logisticOtherServiceChanges;
    }
  }
}
