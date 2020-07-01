using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IRajaOngkirCityRepository
  {
    RajaOngkirCity Get(int id);
    IEnumerable<RajaOngkirCity> Get();
    RajaOngkirCity Add(RajaOngkirCity rajaOngkirCity);
    RajaOngkirCity Update(RajaOngkirCity rajaOngkirCityChanges);
    RajaOngkirCity Delete(int id);
    public RajaOngkirCity GetByROCityId(int roCityId);
  }
}
