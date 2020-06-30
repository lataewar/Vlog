using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IAddressRepository
  {
    Address Get(int id);
    IEnumerable<Address> Get();
    Address Add(Address address);
    Address Update(Address addressChanges);
    Address Delete(int id);
  }
}
