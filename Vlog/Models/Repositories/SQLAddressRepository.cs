using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLAddressRepository : IAddressRepository
  {
    private readonly VlogDBContext _context;

    public SQLAddressRepository(VlogDBContext context)
    {
      _context = context;
    }

    public Address Add(Address address)
    {
      _context.AddressItems.Add(address);
      _context.SaveChanges();

      return address;
    }

    public Address Delete(int id)
    {
      Address address = _context.AddressItems.Find(id);

      if (address != null)
      {
        _context.AddressItems.Remove(address);
        _context.SaveChanges();
      }

      return address;
    }

    public Address Get(int id)
    {
      return _context.AddressItems.Find(id);
    }

    public IEnumerable<Address> Get()
    {
      return _context.AddressItems;
    }

    public Address Update(Address addressChanges)
    {
     _context.Entry( addressChanges ).State = EntityState.Modified;
      _context.SaveChanges();

      return addressChanges;
    }
  }
}
