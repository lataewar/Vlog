using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticPacketRepository
  {
    LogisticPacket GetLogisticPacket(int id);
    IEnumerable<LogisticPacket> GetLogisticPackets();
    LogisticPacket Add(LogisticPacket logisticPacket);
    LogisticPacket Update(LogisticPacket logisticPacketChanges);
    LogisticPacket Delete(int id);
  }
}
