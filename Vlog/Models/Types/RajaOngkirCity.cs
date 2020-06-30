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
    public Regency Regency { get; set; }
    public string PostalCode { get; set; }
    public string Type { get; set; }
  }
}
