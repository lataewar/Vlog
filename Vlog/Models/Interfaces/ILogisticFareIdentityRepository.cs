using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticFareIdentityRepository
  {
    LogisticFareIdentity GetLogisticFareIdentity(int id);
    IEnumerable<LogisticFareIdentity> GetLogisticFareIdentities();
    LogisticFareIdentity Add(LogisticFareIdentity logisticFareIdentity);
    LogisticFareIdentity Update(LogisticFareIdentity logisticFareIdentityChanges);
    LogisticFareIdentity Delete(int id);
  }
}
