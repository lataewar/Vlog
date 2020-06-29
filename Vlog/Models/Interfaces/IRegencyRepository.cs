using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IRegencyRepository
  {
    Regency GetRegency(int id);
    IEnumerable<Regency> GetRegencies();
    Regency Add(Regency regency);
    Regency Update(Regency regencyChanges);
    Regency Delete(int id);
  }
}
