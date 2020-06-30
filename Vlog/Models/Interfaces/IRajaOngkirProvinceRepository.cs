using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IRajaOngkirProvinceRepository
  {
    RajaOngkirProvince Get(int id);
    IEnumerable<RajaOngkirProvince> Get();
    RajaOngkirProvince Add(RajaOngkirProvince rajaOngkirProvince);
    RajaOngkirProvince Update(RajaOngkirProvince rajaOngkirProvinceChanges);
    RajaOngkirProvince Delete(int id);
  }
}
