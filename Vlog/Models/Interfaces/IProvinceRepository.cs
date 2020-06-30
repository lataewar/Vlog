using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IProvinceRepository
  {
    Province Get(int id);
    IEnumerable<Province> Get();
    Province Add(Province province);
    Province Update(Province provinceChanges);
    Province Delete(int id);
  }
}
