using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IUserRoleRepository
  {
    UserRole Get(int id);
    IEnumerable<UserRole> Get();
    UserRole Add(UserRole userRole);
    UserRole Update(UserRole userRoleChanges);
    UserRole Delete(int id);
  }
}
