using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ICountryRepository
  {
    Country Get(int id);
    IEnumerable<Country> Get();
    Country Add(Country country);
    Country Update(Country countryChanges);
    Country Delete(int id);
  }
}
