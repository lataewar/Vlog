using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IDistrictRepository
  {
    District Get(int id);
    IEnumerable<District> Get();
    District Add(District district);
    District Update(District districtChanges);
    District Delete(int id);
  }
}
