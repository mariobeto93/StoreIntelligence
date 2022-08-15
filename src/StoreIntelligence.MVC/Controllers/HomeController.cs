using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreIntelligence.Infraestructure.Services;
using StoreIntelligence.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StoreIntelligence.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var log = new LogService();
            var items = log.GetLog();

            return View(new HomeViewBag{
                LogEjecuciones = items,
                viewLog = true

              });

        }

        public ActionResult AddLog()
        {
            var log = new LogService();
            log.SaveLog("MVC");

            return View("~/Views/Home/Index.cshtml",  new HomeViewBag
            {
                LogEjecuciones = new List<LogEjecuciones>(),
                viewLog = false

            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
