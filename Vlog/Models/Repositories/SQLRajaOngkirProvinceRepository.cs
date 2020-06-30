using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLRajaOngkirProvinceRepository : IRajaOngkirProvinceRepository
  {
    private readonly VlogDBContext _context;
    public SQLRajaOngkirProvinceRepository(VlogDBContext context)
    {
      _context = context;
    }
    public RajaOngkirProvince Add(RajaOngkirProvince rajaOngkirProvince)
    {
      _context.RajaOngkirProvinceItems.Add(rajaOngkirProvince);
      _context.SaveChanges();

      return rajaOngkirProvince;
    }

    public RajaOngkirProvince Delete(int id)
    {
      RajaOngkirProvince province = _context.RajaOngkirProvinceItems.Find(id);

      if (province != null)
      {
        _context.RajaOngkirProvinceItems.Remove(province);
        _context.SaveChanges();
      }

      return province;
    }

    public RajaOngkirProvince Get(int id)
    {
      return _context.RajaOngkirProvinceItems.Find(id);
    }

    public IEnumerable<RajaOngkirProvince> Get()
    {
      return _context.RajaOngkirProvinceItems;
    }

    public RajaOngkirProvince Update(RajaOngkirProvince rajaOngkirProvinceChanges)
    {
      _context.Entry(rajaOngkirProvinceChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return rajaOngkirProvinceChanges;
    }

    public RajaOngkirProvince GetByROProvinceId(int ROProvinceId)
    {
      return _context.RajaOngkirProvinceItems.Where(a => a.ROProvinceId == ROProvinceId).FirstOrDefault();
    }
  }
}
