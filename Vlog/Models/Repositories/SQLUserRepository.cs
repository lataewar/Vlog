using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models.Repositories
{
  public class SQLUserRepository : IUserRepository
  {
    private readonly VlogDBContext _context;
    public SQLUserRepository(VlogDBContext context)
    {
      _context = context;
    }
    public User Add(User user)
    {
      _context.UserItems.Add(user);
      _context.SaveChanges();

      return user;
    }

    public User Delete(int id)
    {
      User user = _context.UserItems.Find(id);

      if (user != null)
      {
        _context.UserItems.Remove(user);
        _context.SaveChanges();
      }

      return user;
    }

    public User Get(int id)
    {
      return _context.UserItems.Find(id);
    }

    public IEnumerable<User> Get()
    {
      return _context.UserItems;
    }

    public User Update(User userChanges)
    {
      _context.Entry(userChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return userChanges;
    }
  }
}
