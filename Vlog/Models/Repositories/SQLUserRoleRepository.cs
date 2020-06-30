using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Models.Repositories
{
  public class SQLUserRoleRepository : IUserRoleRepository
  {
    private readonly VlogDBContext _context;
    public SQLUserRoleRepository(VlogDBContext context)
    {
      _context = context;
    }
    public UserRole Add(UserRole userRole)
    {
      _context.UserRoleItems.Add(userRole);
      _context.SaveChanges();

      return userRole;
    }

    public UserRole Delete(int id)
    {
      UserRole userRole = _context.UserRoleItems.Find(id);

      if (userRole != null)
      {
        _context.UserRoleItems.Remove(userRole);
        _context.SaveChanges();
      }

      return userRole;
    }

    public UserRole Get(int id)
    {
      return _context.UserRoleItems.Find(id);
    }

    public IEnumerable<UserRole> Get()
    {
      return _context.UserRoleItems;
    }

    public UserRole Update(UserRole userRoleChanges)
    {
      _context.Entry(userRoleChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return userRoleChanges;
    }
  }
}
