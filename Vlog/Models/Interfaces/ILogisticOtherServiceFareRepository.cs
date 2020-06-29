using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticOtherServiceFareRepository
  {
    LogisticOtherServiceFare GetLogisticOtherServiceFare(int id);
    IEnumerable<LogisticOtherServiceFare> GetLogisticOtherServiceFares();
    LogisticOtherServiceFare Add(LogisticOtherServiceFare logisticOtherServiceFare);
    LogisticOtherServiceFare Update(LogisticOtherServiceFare logisticOtherServiceFareChanges);
    LogisticOtherServiceFare Delete(int id);
  }
}
