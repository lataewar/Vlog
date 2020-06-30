using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Types
{
  public class LogisticOtherServiceFare
  {
    public int Id { get; set; }
    public LogisticOtherService LogisticOtherService { get; set; }
    public LogisticUnitEnum LogisticUnit { get; set; }
    public decimal Nominal { get; set; }
  }
}
