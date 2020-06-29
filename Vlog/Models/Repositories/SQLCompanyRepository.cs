using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Vlog.Models
{
  public class SQLCompanyRepository : ICompanyRepository
  {
    private readonly VlogDBContext _context;

    public SQLCompanyRepository(VlogDBContext context)
    {
      _context = context;
    }

    public Company Add(Company company)
    {
      _context.CompanyItems.Add(company);
      _context.SaveChanges();

      return company;
    }

    public Company Delete(int id)
    {
      Company company = _context.CompanyItems.Find(id);

      if (company != null)
      {
        _context.CompanyItems.Remove(company);
        _context.SaveChanges();
      }

      return company;
    }

    public IEnumerable<Company> GetCompanies()
    {
      return _context.CompanyItems;
    }

    public Company GetCompany(int id)
    {
      return _context.CompanyItems.Find( id );
    }

    public Company Update(Company companyChanges)
    {
      _context.Entry(companyChanges).State = EntityState.Modified;
      _context.SaveChanges();

      return companyChanges;
    }
  }
}
