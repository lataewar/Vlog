using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public class AirwayBill
  {
    public static string GenerateCode(int originId, int packetId, int companyId, int reserved)
    {
      return $"{originId.ToString("D5")}{packetId.ToString("D4")}{companyId.ToString("D3")}{reserved.ToString("D3")}";
    }
  }
}
