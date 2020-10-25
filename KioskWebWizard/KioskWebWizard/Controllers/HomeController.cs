using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using KioskWebWizard.ViewModel.Home;

namespace KioskWebWizard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKioskService _kioskService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IKioskService kioskService, UserManager<IdentityUser> userManager)
        {
            _kioskService = kioskService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                NumberOfKiosks = _kioskService.GetNumberOfKiosks(_userManager.GetUserId(User))
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
