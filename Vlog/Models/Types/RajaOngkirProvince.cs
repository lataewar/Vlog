using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Types
{
  public class RajaOngkirProvince
  {
    public int Id { get; set; }
    public int ROProvinceId { get; set; }
    public Province Province { get; set; }
  }
}
