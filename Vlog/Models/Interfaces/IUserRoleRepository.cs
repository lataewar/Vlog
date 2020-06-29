using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Types;

namespace Vlog.Models.Interfaces
{
  public interface IUserRoleRepository
  {
    UserRole GetUserRole(int id);
    IEnumerable<UserRole> GetUserRoles();
    UserRole Add(UserRole userRole);
    UserRole Update(UserRole userRoleChanges);
    UserRole Delete(int id);
  }
}
