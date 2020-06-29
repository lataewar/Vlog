using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Vlog.Models
{
  public class SQLContactRepository : IContactRepository
  {
    private readonly VlogDBContext _context;

    public SQLContactRepository(VlogDBContext context)
    {
      _context = context;
    }

    public Contact Add(Contact contact)
    {
      _context.ContactItems.Add(contact);
      _context.SaveChanges();

      return contact;
    }

    public Contact Delete(int id)
    {
      Contact contact = _context.ContactItems.Find(id);

      if (contact != null)
      {
        _context.ContactItems.Remove(contact);
        _context.SaveChanges();
      }

      return contact;
    }

    public Contact GetContact(int id)
    {
      return _context.ContactItems.Find(id);
    }

    public IEnumerable<Contact> GetContacts()
    {
      return _context.ContactItems;
    }

    public Contact Update(Contact contactChanges)
    {
      _context. Entry(contactChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return contactChanges;
    }
  }
}
