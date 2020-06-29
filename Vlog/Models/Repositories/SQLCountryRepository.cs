using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLCountryRepository : ICountryRepository
  {
    private readonly VlogDBContext _context;
    public SQLCountryRepository(VlogDBContext context)
    {
      _context = context;
    }
    public Country Add(Country country)
    {
      _context.CountryItems.Add(country);
      _context.SaveChanges();

      return country;
    }

    public Country Delete(int id)
    {
      Country country = _context.CountryItems.Find(id);

      if (country != null)
      {
        _context.CountryItems.Remove(country);
        _context.SaveChanges();
      }

      return country;
    }

    public IEnumerable<Country> GetCountries()
    {
      return _context.CountryItems;
    }

    public Country GetCountry(int id)
    {
      return _context.CountryItems.Find(id);
    }

    public Country Update(Country countryChanges)
    {
      _context.Entry(countryChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return countryChanges;
    }
  }
}
