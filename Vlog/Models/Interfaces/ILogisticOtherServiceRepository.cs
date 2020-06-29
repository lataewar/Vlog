﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface ILogisticOtherServiceRepository
  {
    LogisticOtherService GetLogisticOtherService(int id);
    IEnumerable<LogisticOtherService> GetLogisticOtherServices();
    LogisticOtherService Add(LogisticOtherService logisticOtherService);
    LogisticOtherService Update(LogisticOtherService logisticOtherServiceChanges);
    LogisticOtherService Delete(int id);
  }
}
