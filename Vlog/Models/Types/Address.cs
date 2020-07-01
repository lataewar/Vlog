namespace Vlog.Models.Types
{
  public class Address
  {
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Detail { get; set; }
    // public int DistrictId { get; set; }
    // public Distric District { get; set; }
    public int RegencyId { get; set; }
    public Regency Regency { get; set; }
    public string District { get; set; }
  }
}
