using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using KioskWebWizard.ViewModel.Kiosk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KioskWebWizard.Controllers
{
    public class KioskController : Controller
    {
        private readonly IKioskService _kioskService;
        private readonly UserManager<IdentityUser> _userManager;

        public KioskController(IKioskService kioskService, UserManager<IdentityUser> userManager)
        {
            _kioskService = kioskService;
            _userManager = userManager;
        }

        // GET: KioskController
        public IActionResult Index()
        {
            var kiosksList = _kioskService.GetAll();
            List<KioskListViewModel> kioskListViewModel = new List<KioskListViewModel>();
            foreach (var plan in kiosksList)
            {
                kioskListViewModel.Add(new KioskListViewModel
                {
                    ID = plan.ID,
                    Name = plan.Name
                });
            }
            return View(kioskListViewModel);
        }

        // GET: KioskController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: KioskController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: KioskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KioskCreateViewModel kioskCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskModel
                    {
                        KioskTemplate = kioskCreateViewModel.KioskTemplate,
                        Name = kioskCreateViewModel.Name,
                        UserId = _userManager.GetUserId(User),
                    };
                    _kioskService.Create(model);
                    return RedirectToAction("Details", new { id = model.ID });
                }
                catch
                {
                    return View(kioskCreateViewModel);
                }
            }
            else
            {
                return View(kioskCreateViewModel);
            }
        }

        // GET: KioskController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kioskToBeEdited = _kioskService.Get(id);
            KioskEditViewModel kioskEditViewModel = new KioskEditViewModel
            {
                ID = kioskToBeEdited.ID,
                Name = kioskToBeEdited.Name,
                KioskTemplate = kioskToBeEdited.KioskTemplate,
            };
            return View(kioskEditViewModel);
        }

        // POST: KioskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KioskEditViewModel kioskEditViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kioskModel = _kioskService.Get(kioskEditViewModel.ID);
                    kioskModel.ID = kioskEditViewModel.ID;
                    kioskModel.Name = kioskEditViewModel.Name;
                    kioskModel.KioskTemplate = kioskEditViewModel.KioskTemplate;

                    _kioskService.Update(kioskModel);
                    return RedirectToAction("Details", new { id = kioskEditViewModel.ID });
                }
                catch
                {
                    return View(kioskEditViewModel);
                }
            }
            else
            {
                return View(kioskEditViewModel);
            }
        }

        // GET: KioskController/Delete/5
        public IActionResult Delete(int id)
        {
            var deleteKiosk = _kioskService.Get(id);
            KioskDeleteViewModel kioskDeleteViewModel = new KioskDeleteViewModel
            {
                ID = deleteKiosk.ID,
                Name = deleteKiosk.Name,
            };
            return View(kioskDeleteViewModel);
        }

        // POST: KioskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            _kioskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
