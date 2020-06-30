using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vlog.Models.Types
{
  public class Province
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    // public int CountryId { get; set; }
    public Country Country { get; set; }

    // public List<Regency> Regencies { get; set; }
  }
}
