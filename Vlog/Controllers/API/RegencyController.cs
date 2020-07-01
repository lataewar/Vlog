using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Controllers.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class RegencyController : ControllerBase
  {
    private readonly IRegencyRepository _regencyRepo;
    public RegencyController(IRegencyRepository regencyRepository)
    {
      _regencyRepo = regencyRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Regency>> Get()
    {
      return _regencyRepo.Get().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Regency> Get(int id)
    {
      return _regencyRepo.Get(id);
    }   

    [Route("[action]/{provinceId}")]
    [HttpGet]
    public ActionResult<IEnumerable<Regency>> GetByProvince(int provinceId)
    {
      return _regencyRepo.Get().Where(r => r.ProvinceId == provinceId).ToList();
    }
  }
}
