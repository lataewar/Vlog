using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlog.Models
{
  public interface ICompanyRepository
  {
    Company GetCompany(int id);
    IEnumerable<Company> GetCompanies();
    Company Add(Company company);
    Company Update(Company companyChanges);
    Company Delete(int id);
  }
}
