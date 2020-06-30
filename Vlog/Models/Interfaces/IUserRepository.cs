using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public interface IUserRepository
  {
    User Get(int id);
    IEnumerable<User> Get();
    User Add(User user);
    User Update(User userChanges);
    User Delete(int id);
  }
}
