using System;

namespace Vlog.Models
{
  public class User
  {
    public int Id { get; set; }
    public string LoginName { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedDateTime { get; set; }
  }
}
