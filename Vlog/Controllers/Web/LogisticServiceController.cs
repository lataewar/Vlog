﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vlog.Controllers.Web
{
  public class LogisticServiceController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult New()
    {
      return View();
    }

    public IActionResult Edit()
    {
      return View();
    }
  }
}
