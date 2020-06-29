using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Types
{
  public class LogisticService
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LogisticFareIdentityId { get; set; }
    public LogisticFareIdentity LogisticFareIdentity { get; set; }
  }
}
