using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticPacketRepository
  {
    LogisticPacket Get(int id);
    IEnumerable<LogisticPacket> Get();
    LogisticPacket Add(LogisticPacket logisticPacket);
    LogisticPacket Update(LogisticPacket logisticPacketChanges);
    LogisticPacket Delete(int id);
  }
}
