using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjSegundoCrud.Models;

namespace prjSegundoCrud.Controllers
{
    [Authorize]
    public class HomeController : Controller

    {
        #region "Contructor"

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region "Index"
        public IActionResult Index()
        {
            return View();
        }

        #endregion

    }
}
