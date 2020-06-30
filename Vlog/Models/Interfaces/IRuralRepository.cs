using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IRuralRepository
  {
    Rural Get(int id);
    IEnumerable<Rural> Get();
    Rural Add(Rural rural);
    Rural Update(Rural ruralChanges);
    Rural Delete(int id);
  }
}
