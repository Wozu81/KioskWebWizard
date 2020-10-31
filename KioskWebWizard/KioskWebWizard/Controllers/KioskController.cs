using System;
using System.Collections.Generic;
using KioskWebWizard.Models;
using KioskWebWizard.Services.Interfaces;
using KioskWebWizard.ViewModel.Kiosk;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using KioskWebWizard.ViewModel.Kiosk.Run;

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
            var kiosksList = _kioskService.GetAllByLoggedUser(User.Identity.Name);
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
        [HttpGet]
        // GET: KioskController/Details/5
        public IActionResult Details(int KioskID)
        {
            if (_kioskService.CheckForTemplateID(KioskID) == 1)
            {
                return RedirectToAction(nameof(Details1), new { KioskID });
            }
            if (_kioskService.CheckForTemplateID(KioskID) == 2)
            {
                return RedirectToAction(nameof(Details2), new { KioskID });
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Details1(int KioskID)
        {
            try
            {
                var kioskModel = _kioskService.Get(KioskID);
                var result = new KioskDetailViewModel1
                {
                    ID = kioskModel.ID,
                    Name = kioskModel.Name,
                    TemplateName = _kioskService.GetTemplateNameByID(KioskID),
                };
                return View(result);
            }
            catch (Exception e)
            {
                //return Content(e.ToString());
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details2(int KioskID)
        {
            try
            {
                var kioskModel = _kioskService.Get(KioskID);
                var result = new KioskDetailViewModel2
                {
                    ID = kioskModel.ID,
                    Name = kioskModel.Name,
                    TemplateName = _kioskService.GetTemplateNameByID(KioskID)
                };
                return View(result);
            }
            catch (Exception e)
            {
                //return Content(e.ToString());
            }
            return View();
        }

        // GET: KioskController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KioskTemplate"] = _kioskService.GetKioskTemplateList();
            return View();
        }

        // POST: KioskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KioskInitialCreateViewModel kioskInitialCreateView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskModel
                    {
                        KioskTemplateID = kioskInitialCreateView.KioskTemplateID,
                        Name = kioskInitialCreateView.Name,
                        UserId = _userManager.GetUserId(User),
                    };
                    _kioskService.Create(model);

                    if (model.KioskTemplateID == 1)
                    {
                        var model1 = new KioskCreateViewModel1
                        {
                            KioskID = model.ID
                        };
                        TempData["kioskCreate1"] = JsonSerializer.Serialize(model1);
                        return RedirectToAction(nameof(Create1));
                    }

                    if (model.KioskTemplateID == 2)
                    {
                        var model2 = new KioskCreateViewModel2
                        {
                            KioskID = model.ID
                        };
                        TempData["kioskCreate2"] = JsonSerializer.Serialize(model2);
                        return RedirectToAction(nameof(Create2));
                    }
                    else
                        return default;

                    //return RedirectToAction(nameof(CreateNext), new { kioskID = model.ID });
                }
                catch
                {
                    return View(kioskInitialCreateView);
                }
            }
            else
            {
                return View(kioskInitialCreateView);
            }
        }


        [HttpGet]
        public IActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create1(KioskCreateViewModel1 kioskCreateViewModel1)
        {
            KioskCreateViewModel1 tempModel = JsonSerializer.Deserialize<KioskCreateViewModel1>((string)TempData["kioskCreate1"]);
            kioskCreateViewModel1.KioskID = tempModel.KioskID;
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskLoyaltyTemplateDataModel
                    {
                        LoyaltyName = kioskCreateViewModel1.LoyaltyName,
                        LoyaltyDescription = kioskCreateViewModel1.LoyaltyDescription,
                        LoyaltyCarouselData1 = kioskCreateViewModel1.LoyaltyCarouselData1,
                        LoyaltyCarouselData2 = kioskCreateViewModel1.LoyaltyCarouselData2,
                        LoyaltyCarouselData3 = kioskCreateViewModel1.LoyaltyCarouselData3,
                        LoyaltyCarouselData4 = kioskCreateViewModel1.LoyaltyCarouselData4,
                        LoyaltyCarouselData5 = kioskCreateViewModel1.LoyaltyCarouselData5
                    };
                    _kioskService.Create1(model);
                    var kioskModel = _kioskService.Get(kioskCreateViewModel1.KioskID);
                    kioskModel.KioskLoyaltyTemplateDataID = model.ID;
                    _kioskService.Update(kioskModel);
                    return RedirectToAction("Details", new { KioskID = kioskModel.ID });
                }
                catch
                {
                    return View(kioskCreateViewModel1);
                }
            }
            else
            {
                return View(kioskCreateViewModel1);
            }
        }

        [HttpGet]
        public IActionResult Create2()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create2(KioskCreateViewModel2 kioskCreateViewModel2)
        {
            KioskCreateViewModel2 tempModel = JsonSerializer.Deserialize<KioskCreateViewModel2>((string)TempData["kioskCreate2"]);
            kioskCreateViewModel2.KioskID = tempModel.KioskID;
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskMapTemplateDataModel
                    {
                        MapName = kioskCreateViewModel2.MapName,
                    };
                    _kioskService.Create2(model);
                    var kioskModel = _kioskService.Get(kioskCreateViewModel2.KioskID);
                    kioskModel.KioskMapTemplateDataID = model.ID;
                    _kioskService.Update(kioskModel);
                    return RedirectToAction("Details", new { KioskID = kioskModel.ID });

                }
                catch
                {
                    return View(kioskCreateViewModel2);
                }
            }
            else
            {
                return View(kioskCreateViewModel2);
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

        [HttpGet]
        public IActionResult CreateTemplate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTemplate(TemplateCreateViewModel templateCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskTemplatesModel
                    {
                        TemplateName = templateCreateViewModel.TemplateName
                    };
                    _kioskService.CreateTemplate(model);
                    return RedirectToAction("ListTemplate");
                }
                catch
                {
                    return View(templateCreateViewModel);
                }
            }
            else
            {
                return View(templateCreateViewModel);
            }
        }


        public IActionResult ListTemplate()
        {
            var templateList = _kioskService.GetAllTemplates();
            List<TemplateListViewModel> templateListViewModel = new List<TemplateListViewModel>();
            foreach (var template in templateList)
            {
                templateListViewModel.Add(new TemplateListViewModel
                {
                    ID = template.ID,
                    TemplateName = template.TemplateName
                });
            }
            return View(templateListViewModel);
        }

        public IActionResult Run(int KioskID)
        {
            if (_kioskService.CheckForTemplateID(KioskID) == 1)
            {
                return RedirectToAction(nameof(Run1), new { KioskID });
            }
            if (_kioskService.CheckForTemplateID(KioskID) == 2)
            {
                return RedirectToAction(nameof(Run2), new { KioskID });
            }
            else
                return View();
        }
        [HttpGet]
        public IActionResult Run1(int KioskID)
        {
            try
            {
                var runKiosk = _kioskService.Get(KioskID);
                var result = new KioskRun1ViewModelPart1
                {
                    OriginalKioskID = KioskID,
                    LoyaltyName = _kioskService.GetLoyaltyNameByID(KioskID),
                    LoyaltyDescription = _kioskService.GetLoyaltyDescriptionByID(KioskID),
                    LoyaltyCarouselData1 = _kioskService.GetLoyaltyCarouselData1ByID(KioskID),
                    LoyaltyCarouselData2 = _kioskService.GetLoyaltyCarouselData2ByID(KioskID),
                    LoyaltyCarouselData3 = _kioskService.GetLoyaltyCarouselData3ByID(KioskID),
                    LoyaltyCarouselData4 = _kioskService.GetLoyaltyCarouselData4ByID(KioskID),
                    LoyaltyCarouselData5 = _kioskService.GetLoyaltyCarouselData5ByID(KioskID),
                };

                var model = new LoyaltyUsersModel
                {
                    OriginalKioskID = KioskID
                };
                TempData["LoyaltyUser"] = JsonSerializer.Serialize(model);
                return View(result);
            }
            catch (Exception e)
            {
                //return Content(e.ToString());
            }
            return View();
        }

        [HttpGet]
        public IActionResult Run11()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Run11(KioskRun11CreateUserViewModel kioskRun11CreateUserViewModel)
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);

            if (ModelState.IsValid)
            {
                try
                {
                    var model = new LoyaltyUsersModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = kioskRun11CreateUserViewModel.EmailAddress,
                        Password = kioskRun11CreateUserViewModel.Password
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(model);
                    return RedirectToAction("Run12");
                }
                catch
                {
                    return View(kioskRun11CreateUserViewModel);
                }
            }
            else
            {
                return View(kioskRun11CreateUserViewModel);
            }
        }

        [HttpGet]
        public IActionResult Run12()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Run12(KioskRun12CreateUserViewModel kioskRun12CreateUserViewModel)
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new LoyaltyUsersModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = kioskRun12CreateUserViewModel.Firstname,
                        Lastname = kioskRun12CreateUserViewModel.Lastname,
                        AllowAddress = kioskRun12CreateUserViewModel.AllowAddress
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(model);
                    if (model.AllowAddress == true) return RedirectToAction("Run13");
                    else
                    {
                        return RedirectToAction(nameof(Run14));
                    }
                }
                catch
                {
                    return View(kioskRun12CreateUserViewModel);
                }
            }
            else
            {
                return View(kioskRun12CreateUserViewModel);
            }
        }

        [HttpGet]
        public IActionResult Run13()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Run13(KioskRun13CreateUserViewModel kioskRun13CreateUserViewModel)
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new LoyaltyUsersModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress,
                        Street = kioskRun13CreateUserViewModel.Street,
                        BuildingNumber = kioskRun13CreateUserViewModel.BuildingNumber,
                        ApartmentNumber = kioskRun13CreateUserViewModel.ApartmentNumber,
                        PostalCode = kioskRun13CreateUserViewModel.PostalCode,
                        City = kioskRun13CreateUserViewModel.City,
                        Country = kioskRun13CreateUserViewModel.Country
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(model);
                    return RedirectToAction(nameof(Run14));

                }
                catch
                {
                    return View(kioskRun13CreateUserViewModel);
                }
            }
            else
            {
                return View(kioskRun13CreateUserViewModel);
            }
        }

        [HttpGet]
        public IActionResult Run14()
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            try
            {
                if (tempModel.AllowAddress == true)
                {
                    var modelToBeShown = new KioskRun14CreateUserViewModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress,
                        Street = tempModel.Street,
                        BuildingNumber = tempModel.BuildingNumber,
                        ApartmentNumber = tempModel.ApartmentNumber,
                        PostalCode = tempModel.PostalCode,
                        City = tempModel.City,
                        Country = tempModel.Country
                    };

                    var modelToBeSaved = new LoyaltyUsersModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress,
                        Street = tempModel.Street,
                        BuildingNumber = tempModel.BuildingNumber,
                        ApartmentNumber = tempModel.ApartmentNumber,
                        PostalCode = tempModel.PostalCode,
                        City = tempModel.City,
                        Country = tempModel.Country
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(modelToBeSaved);
                    //_kioskService.CreateUser(modelToBeSaved);
                    return View(modelToBeShown);
                }
                else
                {
                    var modelToBeShown = new KioskRun14CreateUserViewModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress
                    };

                    var modelToBeSaved = new LoyaltyUsersModel
                    {
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(modelToBeSaved);
                    //_kioskService.CreateUser(modelToBeSaved);
                    return View(modelToBeShown);
                }
            }
            catch
            {
                return View();
            }

        }
        [HttpPost]
        public IActionResult Run14(KioskRun14CreateUserViewModel kioskRun14CreateUserView)
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            if (ModelState.IsValid)
            {
                try
                {
                    var model = new KioskRun14CreateUserViewModel
                    {
                        Rodo = kioskRun14CreateUserView.Rodo,
                        OriginalKioskID = tempModel.OriginalKioskID,
                        EmailAddress = tempModel.EmailAddress,
                        Password = tempModel.Password,
                        Firstname = tempModel.Firstname,
                        Lastname = tempModel.Lastname,
                        AllowAddress = tempModel.AllowAddress,
                        Street = tempModel.Street,
                        BuildingNumber = tempModel.BuildingNumber,
                        ApartmentNumber = tempModel.ApartmentNumber,
                        PostalCode = tempModel.PostalCode,
                        City = tempModel.City,
                        Country = tempModel.Country
                    };
                    TempData["LoyaltyUser"] = JsonSerializer.Serialize(model);
                    return View(kioskRun14CreateUserView);
                }
                catch
                {
                    return View(kioskRun14CreateUserView);
                }
            }
            else
            {
                return View(kioskRun14CreateUserView);
            }
        }

            [HttpGet]
        public IActionResult RunYes()
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            _kioskService.CreateUser(tempModel);
            TempData["LoyaltyUser"] = JsonSerializer.Serialize(tempModel);
            return RedirectToAction(nameof(Run15));
        }

        [HttpGet]
        public IActionResult RunNo()
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            int temp = tempModel.OriginalKioskID;
            TempData.Remove("LoyaltyUser");
            return RedirectToAction(nameof(Run), new { KioskID = temp });

        }


        [HttpGet]
        public IActionResult Run15()
        {
            LoyaltyUsersModel tempModel = JsonSerializer.Deserialize<LoyaltyUsersModel>((string)TempData["LoyaltyUser"]);
            try
            {
                var updatedUserModel = tempModel;
                updatedUserModel.LoyaltyID = 10700 + updatedUserModel.ID;
                _kioskService.UpdateUser(updatedUserModel);
                var kioskToBeShown = new KioskRun15CreateUserViewModel
                {
                    OriginalKioskID = tempModel.OriginalKioskID,
                    LoyaltyID = updatedUserModel.LoyaltyID
                };
                return View(kioskToBeShown);
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Run2(int KioskID)
        {
            try
            {
                var runKiosk = _kioskService.Get(KioskID);
                var result = new KioskRun2ViewModelPart1
                {
                    MapName = _kioskService.GetMapNameByID(KioskID)
                };
                return View(result);
            }
            catch (Exception e)
            {
                //return Content(e.ToString());
            }
            return View();
        }
    }
}
