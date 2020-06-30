using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public class StaticConfigurationService
  {
    public static IConfiguration Config { get; private set; }

    public StaticConfigurationService(IConfiguration configuration)
    {
      Config = configuration;
    }
  }
}
