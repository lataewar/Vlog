using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticServiceRepository
  {
    LogisticService Get(int id);
    IEnumerable<LogisticService> Get();
    LogisticService Add(LogisticService logisticService);
    LogisticService Update(LogisticService logisticServiceChanges);
    LogisticService Delete(int id);
  }
}
