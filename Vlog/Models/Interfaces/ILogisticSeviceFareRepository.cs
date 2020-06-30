using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticSeviceFareRepository
  {
    LogisticServiceFare Get(int id);
    IEnumerable<LogisticServiceFare> Get();
    LogisticServiceFare Add(LogisticServiceFare logisticServiceFare);
    LogisticServiceFare Update(LogisticServiceFare logisticServiceFareChanges);
    LogisticServiceFare Delete(int id);
  }
}
