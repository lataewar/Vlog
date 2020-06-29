namespace Vlog.Models.Types
{
  public class UserRole
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public UserRoleEnum UserRoleEnum { get; set; }
    public int CompanyId { get; set; }
  }
}
