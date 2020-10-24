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
        public ActionResult Index()
        {
            return View();
        }

        // GET: KioskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KioskController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: KioskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KioskCreateViewModel kioskCreateViewModel)
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
        public ActionResult Edit(int id)
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
        public ActionResult Edit(int id, KioskEditViewModel kioskEditViewModel)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KioskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
