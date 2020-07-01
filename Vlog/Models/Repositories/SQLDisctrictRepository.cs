using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLDisctrictRepository : IDistrictRepository
  {
    private readonly VlogDBContext _context;
    public SQLDisctrictRepository(VlogDBContext context)
    {
      _context = context;
    }
    public District Add(District district)
    {
      _context.DistrictItems.Add(district);
      _context.SaveChanges();

      return district;
    }

    public District Delete(int id)
    {
      District district = _context.DistrictItems.Find(id);

      if (district != null)
      {
        _context.DistrictItems.Remove(district);
        _context.SaveChanges();
      }

      return district;
    }

    public District Get(int id)
    {
      return _context.DistrictItems.Find(id);
    }

    public IEnumerable<District> Get()
    {
      return _context.DistrictItems;
    }

    public District Update(District districtChanges)
    {
      _context.Entry(districtChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return districtChanges;
    }
  }
}
