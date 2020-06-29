using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ICountryRepository
  {
    Country GetCountry(int id);
    IEnumerable<Country> GetCountries();
    Country Add(Country country);
    Country Update(Country countryChanges);
    Country Delete(int id);
  }
}
