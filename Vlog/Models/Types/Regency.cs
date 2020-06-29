using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Types
{
  public class Regency
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
    
  }
}
