namespace Vlog.Models.Types
{
  public class LogisticFareNominal
  {
    public int Id { get; set; }
    public LogisticFareIdentity LogisticFareIdentity { get; set; }
    public LogisticUnitEnum LogisticUnit { get; set; }
    public decimal Nominal { get; set; }
    public int RuralFromId { get; set; }
    public Rural RuralFrom { get; set; }

    public int RuralToId { get; set; }
    public Rural RuralTo { get; set; }
  }
}
