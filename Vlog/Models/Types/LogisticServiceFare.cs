namespace Vlog.Models.Types
{
  public class LogisticServiceFare
  {
    public int Id { get; set; }
    // public int LogisticServiceId { get; set; }
    public LogisticService LogisticService { get; set; }
    public LogisticUnitEnum LogisticUnit { get; set; }
    public decimal Nominal { get; set; }
    // public int RegencyFromId { get; set; }
    public Regency RegencyFrom { get; set; }
    // public int RegencyToId { get; set; }
    public Regency RegencyTo { get; set; }
    public int MinimumEstimateDay { get; set; }
    public int MaximumEstimateDay { get; set; }
  }
}
