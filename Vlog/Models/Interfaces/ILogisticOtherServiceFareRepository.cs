using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticOtherServiceFareRepository
  {
    LogisticOtherServiceFare Get(int id);
    IEnumerable<LogisticOtherServiceFare> Get();
    LogisticOtherServiceFare Add(LogisticOtherServiceFare logisticOtherServiceFare);
    LogisticOtherServiceFare Update(LogisticOtherServiceFare logisticOtherServiceFareChanges);
    LogisticOtherServiceFare Delete(int id);
  }
}
