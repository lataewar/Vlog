using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLRajaOngkirCityRepository : IRajaOngkirCityRepository
  {
    private readonly VlogDBContext _context;
    public SQLRajaOngkirCityRepository(VlogDBContext context)
    {
      _context = context;
    }
    public RajaOngkirCity Add(RajaOngkirCity rajaOngkirCity)
    {
      _context.RajaOngkirCityItems.Add(rajaOngkirCity);
      _context.SaveChanges();

      return rajaOngkirCity;
    }

    public RajaOngkirCity Delete(int id)
    {
      RajaOngkirCity city = _context.RajaOngkirCityItems.Find(id);

      if (city != null)
      {
        _context.RajaOngkirCityItems.Remove(city);
        _context.SaveChanges();
      }

      return city;
    }

    public RajaOngkirCity Get(int id)
    {
      return _context.RajaOngkirCityItems.Find(id);
    }

    public IEnumerable<RajaOngkirCity> Get()
    {
      return _context.RajaOngkirCityItems;
    }

    public RajaOngkirCity Update(RajaOngkirCity rajaOngkirCityChanges)
    {
      _context.Entry(rajaOngkirCityChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return rajaOngkirCityChanges;
    }

    public RajaOngkirCity GetByROCityId(int roCityId)
    {
      return _context.RajaOngkirCityItems.Where(a => a.ROCityId == roCityId).FirstOrDefault();
    }
  }
}
