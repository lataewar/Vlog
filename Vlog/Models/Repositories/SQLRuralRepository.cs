using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLRuralRepository : IRuralRepository
  {
    private readonly VlogDBContext _context;
    public SQLRuralRepository(VlogDBContext context)
    {
      _context = context;
    }
    public Rural Add(Rural rural)
    {
      _context.RuralItems.Add(rural);
      _context.SaveChanges();

      return rural;
    }

    public Rural Delete(int id)
    {
      Rural rural = _context.RuralItems.Find(id);

      if (rural != null)
      {
        _context.RuralItems.Remove(rural);
        _context.SaveChanges();
      }

      return rural;
    }

    public Rural GetRural(int id)
    {
      return _context.RuralItems.Find(id);
    }

    public IEnumerable<Rural> GetRurals()
    {
      return _context.RuralItems;
    }

    public Rural Update(Rural ruralChanges)
    {
      _context.Entry(ruralChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return ruralChanges;
    }
  }
}
