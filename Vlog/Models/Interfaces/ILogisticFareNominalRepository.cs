using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticFareNominalRepository
  {
    LogisticFareNominal GetLogisticFareNominal(int id);
    IEnumerable<LogisticFareNominal> GetLogisticFareNominals();
    LogisticFareNominal Add(LogisticFareNominal logisticFareNominal);
    LogisticFareNominal Update(LogisticFareNominal logisticFareNominalChanges);
    LogisticFareNominal Delete(int id);
  }
}
