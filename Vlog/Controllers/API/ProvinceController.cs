using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vlog.Models.Interfaces;
using Vlog.Models.Types;

namespace Vlog.Controllers.API
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProvinceController : Controller
  {
    private readonly IProvinceRepository _provinceRepo;
    public ProvinceController(IProvinceRepository provinceRepository)
    {
      _provinceRepo = provinceRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Province>> Get()
    {
      return _provinceRepo.Get().ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Province> Get(int id)
    {
      return _provinceRepo.Get(id);
    }
  }
}
