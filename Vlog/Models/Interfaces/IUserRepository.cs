using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public interface IUserRepository
  {
    User GetUser(int id);
    IEnumerable<User> GetUsers();
    User Add(User user);
    User Update(User userChanges);
    User Delete(int id);
  }
}
