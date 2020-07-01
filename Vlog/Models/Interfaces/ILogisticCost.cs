using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticCost
  {
    public decimal GetCost(LogisticService logisticService, int origin, int destination, int weight);
  }
}
