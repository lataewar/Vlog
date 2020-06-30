using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticOtherServiceRepository
  {
    LogisticOtherService Get(int id);
    IEnumerable<LogisticOtherService> Get();
    LogisticOtherService Add(LogisticOtherService logisticOtherService);
    LogisticOtherService Update(LogisticOtherService logisticOtherServiceChanges);
    LogisticOtherService Delete(int id);
  }
}
