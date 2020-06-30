using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLProvinceRepository : IProvinceRepository
  {
    private readonly VlogDBContext _context;

    public SQLProvinceRepository(VlogDBContext context)
    {
      _context = context;
    }

    public Province Add(Province province)
    {
      _context.ProvinceItems.Add(province);
      _context.SaveChanges();

      return province;
    }

    public Province Delete(int id)
    {
      Province province = _context.ProvinceItems.Find(id);

      if (province != null)
      {
        _context.ProvinceItems.Remove(province);
        _context.SaveChanges();
      }

      return province;
    }

    public Province Get(int id)
    {
      return _context.ProvinceItems.Find(id);
    }

    public IEnumerable<Province> Get()
    {
      return _context.ProvinceItems;
    }

    public Province Update(Province provinceChanges)
    {
      _context.Entry(provinceChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return provinceChanges;
    }

    public Province GetByROProvinceName(string provinceName)
    {
      return _context.ProvinceItems.Where(a => a.Name == provinceName).FirstOrDefault();
    }
  }
}
