using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public interface IContactRepository
  {
    Contact GetContact(int id);
    IEnumerable<Contact> GetContacts();
    Contact Add(Contact contact);
    Contact Update(Contact contactChanges);
    Contact Delete(int id);
  }
}
