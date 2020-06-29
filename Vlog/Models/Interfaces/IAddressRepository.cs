using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IAddressRepository
  {
    Address GetAddress(int id);
    IEnumerable<Address> GetAddresses();
    Address Add(Address address);
    Address Update(Address addressChanges);
    Address Delete(int id);
  }
}
