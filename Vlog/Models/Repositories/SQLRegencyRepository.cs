using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLRegencyRepository : IRegencyRepository
  {
    private readonly VlogDBContext _context;
    public SQLRegencyRepository(VlogDBContext context)
    {
      _context = context;
    }
    public Regency Add(Regency regency)
    {
      _context.RegencyItems.Add(regency);
      _context.SaveChanges();

      return regency;
    }

    public Regency Delete(int id)
    {
      Regency regency = _context.RegencyItems.Find(id);

      if (regency != null)
      {
        _context.RegencyItems.Remove(regency);
        _context.SaveChanges();
      }

      return regency;
    }

    public IEnumerable<Regency> Get()
    {
      return _context.RegencyItems;
    }

    public Regency Get(int id)
    {
      return _context.RegencyItems.Find(id);
    }

    public Regency Update(Regency regencyChanges)
    {
      _context.Entry(regencyChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return regencyChanges;
    }

    public Regency GetByROCityName(Province province, string cityName)
    {
      return _context.RegencyItems.Where( a => a.Name == cityName && a.Province.Id == province.Id ).FirstOrDefault();
    }
  }
}
