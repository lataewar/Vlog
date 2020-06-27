using System;

namespace Vlog.Models
{
  public class Company
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime EstablishedDateTime { get; set; }
  }
}
