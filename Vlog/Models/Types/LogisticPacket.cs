using System;

namespace Vlog.Models.Types
{
  public class LogisticPacket
  {
    public int Id { get; set; }
    public string NameFrom { get; set; }
    public string NameTo { get; set; }
    public string PhoneNumberFrom { get; set; }
    public string PhoneNumberTo { get; set; }
    public int UnitNumber { get; set; }
    public DateTime DateCreated { get; set; }
    public decimal CurrentNominal { get; set; }
    public string AirWayBill { get; set; }
    // public int AddressFromId { get; set; }
    public Address AddressFrom { get; set; }
    // public int AddressToId { get; set; }
    public Address AddressTo { get; set; }
    public int LogisticServiceId { get; set; }
    public LogisticService LogisticService { get; set; }
  }
}
