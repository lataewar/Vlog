using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Types
{
  public class RajaOngkirCity
  {
    public int Id { get; set; }
    public int ROCityId { get; set; }
    public int ROProvinceId { get; set; }
    public string Name { get; set; }
    public int PostalCode { get; set; }
  }
}
